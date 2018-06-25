using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;

using Android.Graphics;
using Android.Support.V7.App;
using Android.Views;
using Java.Util;

using Com.Mapbox.Mapboxsdk.Annotations;
using Com.Mapbox.Mapboxsdk.Camera;
using Com.Mapbox.Mapboxsdk.Geometry;
using Com.Mapbox.Mapboxsdk.Maps;
using Com.Mapbox.Mapboxsdk.Style.Sources;
using Com.Mapbox.Services.Commons.Geojson;
using Naxam.Controls.Mapbox.Platform.Droid;
using Naxam.Controls.Mapbox.Forms;

using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Annotation = Naxam.Controls.Mapbox.Forms.Annotation;
using Bitmap = Android.Graphics.Bitmap;
using MapView = Naxam.Controls.Mapbox.Forms.MapView;
using Point = Xamarin.Forms.Point;
using Sdk = Com.Mapbox.Mapboxsdk;
using View = Android.Views.View;

namespace Naxam.Controls.Mapbox.Platform.Droid
{
    public partial class MapViewRenderer
        : ViewRenderer<MapView, View>, MapboxMap.ISnapshotReadyCallback, IOnMapReadyCallback
    {
        MapboxMap _map;

        MapViewFragment _fragment;
        private const int SizeZoom = 13;
        private Position _currentCamera;
        private INotifyCollectionChanged _notifyCollectionChanged;

        readonly Dictionary<string, Sdk.Annotations.Annotation> _annotationDictionaries =
            new Dictionary<string, Sdk.Annotations.Annotation>();

        protected override void OnElementChanged(
            ElementChangedEventArgs<MapView> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                if (e.OldElement?.TakeSnapshotFunc != null)
                    // ReSharper disable once DelegateSubtraction
                    e.OldElement.TakeSnapshotFunc -= TakeMapSnapshot;
                if (e.OldElement?.GetFeaturesAroundPointFunc != null)
                    // ReSharper disable once DelegateSubtraction
                    e.OldElement.GetFeaturesAroundPointFunc -= GetFeaturesAroundPoint;
            }

            if (e.NewElement == null)
                return;

            if (Control != null)
                return;

            var activity = (AppCompatActivity)Context;
            var view = new Android.Widget.FrameLayout(activity)
            {
                Id = GenerateViewId()
            };

            SetNativeControl(view);

            _fragment = new MapViewFragment();

            activity.SupportFragmentManager.BeginTransaction()
                .Replace(view.Id, _fragment)
                .Commit();

            _fragment.GetMapAsync(this);
            _currentCamera = new Position();
        }

        private void SetupFunctions()
        {
            Element.TakeSnapshotFunc += TakeMapSnapshot;
            Element.GetFeaturesAroundPointFunc += GetFeaturesAroundPoint;

            Element.ResetPositionAction = () =>
            {
                //TODO handle reset position call
                //map.ResetNorth();
                //map.AnimateCamera(CameraUpdateFactory.ZoomTo(Element.ZoomLevel));
            };

            Element.UpdateLayerFunc = (string layerId, bool isVisible, bool isCustom) =>
            {
                if (string.IsNullOrEmpty(layerId)) return false;

                var layerIdStr = isCustom ? layerId.Prefix() : layerId;
                var layer = _map.GetLayer(layerIdStr);

                if (layer == null) return false;

                layer.SetProperties(layer.Visibility, 
                    isVisible ? Sdk.Style.Layers.PropertyFactory.Visibility(Sdk.Style.Layers.Property.Visible) 
                        : Sdk.Style.Layers.PropertyFactory.Visibility(Sdk.Style.Layers.Property.None));

                if (!isCustom || Element.MapStyle.CustomLayers == null) return true;

                var count = Element.MapStyle.CustomLayers.Count();
                for (var i = 0; i < count; i++)
                {
                    if (Element.MapStyle.CustomLayers.ElementAt(i).Id != layerId) continue;

                    Element.MapStyle.CustomLayers.ElementAt(i).IsVisible = isVisible;
                    break;
                }

                return true;
            };

            Element.UpdateShapeOfSourceFunc = (Annotation annotation, string sourceId) =>
            {
                if (annotation == null || string.IsNullOrEmpty(sourceId)) return false;

                var shape = annotation.ToFeatureCollection();

                if (!(_map.GetSource(sourceId.Prefix()) is GeoJsonSource source)) return false;

                Device.BeginInvokeOnMainThread(() =>
                {
                    source.SetGeoJson(shape);
                });

                if (Element.MapStyle.CustomSources == null) return true;

                var count = Element.MapStyle.CustomSources.Count();
                for (var i = 0; i < count; i++)
                {
                    if (Element.MapStyle.CustomSources.ElementAt(i).Id != sourceId) continue;

                    Element.MapStyle.CustomSources.ElementAt(i).Shape = annotation;
                    break;
                }
                return true;
            };

            Element.ReloadStyleAction = () => {
                //https://github.com/mapbox/mapbox-gl-native/issues/9511
				_map.SetStyleUrl(_map.StyleUrl, null);
            };

            Element.UpdateViewPortAction = (Position centerLocation, double? zoomLevel, double? bearing, bool animated, Action completionHandler) => {
                var newPosition = new CameraPosition.Builder()
                                                    .Bearing(bearing ?? _map.CameraPosition.Bearing)
                                                    .Target(centerLocation?.ToLatLng() ?? _map.CameraPosition.Target)
                                                    .Zoom(zoomLevel ?? _map.CameraPosition.Zoom)
                                                    .Build();
                var callback = completionHandler == null ? null : new CancelableCallback()
                {
                    FinishHandler = completionHandler,
                    CancelHandler = completionHandler
                };
                var update = CameraUpdateFactory.NewCameraPosition(newPosition);
                if (animated) {
					_map.AnimateCamera(update, callback);
                }
                else {
					_map.MoveCamera(update, callback);
				}
            };
        }

        byte[] TakeMapSnapshot()
        {
            //TODO
            _map.Snapshot(this);
            return _result;
        }

        IFeature[] GetFeaturesAroundPoint(Point point, double radius, string[] layers)
        {
            var output = new List<IFeature>();
            RectF rect = point.ToRect(Context.ToPixels(radius));
            var listFeatures = _map.QueryRenderedFeatures(rect, layers);
            return listFeatures.Select(x => x.ToFeature())
                               .Where(x => x != null)
                               .ToArray();
        }

        protected override void Dispose(bool disposing)
        {
            if (_fragment != null)
            {
                RemoveMapEvents();
                _notifyCollectionChanged.CollectionChanged -= OnAnnotationsCollectionChanged;

                if (_fragment.StateSaved)
                {
                    var activity = (AppCompatActivity)Context;
                    var fm = activity.SupportFragmentManager;

                    fm.BeginTransaction()
                        .Remove(_fragment)
                        .Commit();
                }

                _fragment.Dispose();
                _fragment = null;
            }

            base.Dispose(disposing);
        }

        private Dictionary<string, object> ConvertToDictionary(string featureProperties)
        {
            Dictionary<string, object> objectFeature = JsonConvert.DeserializeObject<Dictionary<string, object>>(featureProperties);
            return JsonConvert.DeserializeObject<Dictionary<string, object>>(objectFeature["properties"].ToString()); ;
        }

        private void FocustoLocation(LatLng latLng)
        {
            if (_map == null) { return; }

            CameraPosition position = new CameraPosition.Builder().Target(latLng).Zoom(SizeZoom).Build();
            ICameraUpdate camera = CameraUpdateFactory.NewCameraPosition(position);
            _map.AnimateCamera(camera);
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == MapView.CenterProperty.PropertyName)
            {
                if (!ReferenceEquals(Element.Center, _currentCamera))
                {
                    if (Element.Center == null) return;
                    FocustoLocation(Element.Center.ToLatLng());
                }
            }
            else if (e.PropertyName == MapView.MapStyleProperty.PropertyName && _map != null)
            {
                UpdateMapStyle();
            }
            else if (e.PropertyName == MapView.PitchEnabledProperty.PropertyName)
            {
                if (_map != null)
                {
                    _map.UiSettings.TiltGesturesEnabled = Element.PitchEnabled;
                }
            }
            else if (e.PropertyName == MapView.RotateEnabledProperty.PropertyName)
            {
                if (_map != null)
                {
                    _map.UiSettings.RotateGesturesEnabled = Element.RotateEnabled;
                }
            }
            else if (e.PropertyName == MapView.AnnotationsProperty.PropertyName)
            {
                SetAnnotations();
            }
            else if (e.PropertyName == MapView.ZoomLevelProperty.PropertyName && _map != null) {
                var dif = Math.Abs(_map.CameraPosition.Zoom - Element.ZoomLevel);
                System.Diagnostics.Debug.WriteLine($"Current zoom: {_map.CameraPosition.Zoom} - New zoom: {Element.ZoomLevel}");
                if (dif >= 0.01) {
                    System.Diagnostics.Debug.WriteLine("Updating zoom level");  
                    _map.AnimateCamera(CameraUpdateFactory.ZoomTo(Element.ZoomLevel));
                }
            }
        }

        void UpdateMapStyle()
        {
            if (Element.MapStyle != null && !string.IsNullOrEmpty(Element.MapStyle.UrlString))
            {
                _map.StyleUrl = Element.MapStyle.UrlString;
                Element.MapStyle.PropertyChanging += OnMapStylePropertyChanging;
                Element.MapStyle.PropertyChanged += OnMapStylePropertyChanged;
            }

        }

        void OnMapStylePropertyChanging(object sender, Xamarin.Forms.PropertyChangingEventArgs e)
        {
            if (e.PropertyName != MapStyle.CustomSourcesProperty.PropertyName ||
                (sender as MapStyle)?.CustomSources == null) return;

            if (((MapStyle) sender).CustomSources is INotifyCollectionChanged notifiyCollection)
            {
                notifiyCollection.CollectionChanged -= OnShapeSourcesCollectionChanged;
            }

            RemoveSources(Element.MapStyle.CustomSources.ToList());
        }

        void OnMapStylePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (!(sender is MapStyle style)) return;

            if (e.PropertyName == MapStyle.CustomSourcesProperty.PropertyName
                && style.CustomSources != null)
            {
                if (style.CustomSources is INotifyCollectionChanged notifiyCollection)
                {
                    notifiyCollection.CollectionChanged += OnShapeSourcesCollectionChanged;
                }

                AddSources(style.CustomSources.ToList());
            }
            else if (e.PropertyName == MapStyle.CustomLayersProperty.PropertyName
                     && style.CustomLayers != null)
            {
                if (Element.MapStyle.CustomLayers is INotifyCollectionChanged notifiyCollection)
                {
                    notifiyCollection.CollectionChanged += OnLayersCollectionChanged;
                }

                AddLayers(Element.MapStyle.CustomLayers.ToList());
            }
        }

        void OnShapeSourcesCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                AddSources(e.NewItems.Cast<ShapeSource>().ToList());
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                RemoveSources(e.OldItems.Cast<ShapeSource>().ToList());
            }
            else if (e.Action == NotifyCollectionChangedAction.Reset)
            {
                var sources = _map.Sources;
                foreach (var s in sources)
				{
					if (s.Id.HasPrefix())
					{
                        _map.RemoveSource(s);
					}
				}
            }
            else if (e.Action == NotifyCollectionChangedAction.Replace)
            {
                RemoveSources(e.OldItems.Cast<ShapeSource>().ToList());
                AddSources(e.NewItems.Cast<ShapeSource>().ToList());
            }
        }

        void AddSources(List<ShapeSource> sources)
        {
            if (sources == null || _map == null)
            {
                return;
            }

            foreach (ShapeSource ss in sources)
            {
                if (ss.Id != null && ss.Shape != null)
                {
                    var shape = ss.Shape.ToFeatureCollection();

                    if (!(_map.GetSource(ss.Id.Prefix()) is GeoJsonSource source))
                    {
                        source = new Sdk.Style.Sources.GeoJsonSource(ss.Id.Prefix(), shape);
                        _map.AddSource(source);
                    }
                    else {
                        source.SetGeoJson(shape);
                    }
                }
            }
        }

        void RemoveSources(List<ShapeSource> sources)
        {
            if (sources == null)
            {
                return;
            }
            foreach (ShapeSource source in sources)
            {
                if (source.Id != null)
                {
                    _map.RemoveSource(source.Id.Prefix());
                }
            }
        }

        void OnLayersCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                AddLayers(e.NewItems.Cast<Layer>().ToList());
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                RemoveLayers(e.OldItems);
            }
            else if (e.Action == NotifyCollectionChangedAction.Reset)
            {
                var layers = _map.Layers;
                foreach (var layer in layers)
                {
                    if (layer.Id.HasPrefix())
                    {
                        _map.RemoveLayer(layer);
                    }
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Replace)
            {
                RemoveLayers(e.OldItems);

                AddLayers(e.NewItems.Cast<Layer>().ToList());
            }
        }

        void RemoveLayers(System.Collections.IList layers)
        {
            if (layers == null)
            {
                return;
            }
            foreach (Layer layer in layers)
            {
                var native = _map.GetLayer(layer.Id.Prefix());

                if (native != null)
                {
                    _map.RemoveLayer(native);
                }
            }
        }

        void AddLayers(List<Layer> layers)
        {
            if (layers == null)
            {
                return;
            }
            foreach (var layer in layers)
            {
                if (string.IsNullOrEmpty(layer.Id))
                {
                    continue;
                }

                _map.RemoveLayer(layer.Id.Prefix());

                switch (layer)
                {
                    case CircleLayer cross1:
                    {
                        var source = _map.GetSource(cross1.SourceId.Prefix());
                        if (source == null)
                        {
                            continue;
                        }

                        _map.AddLayer(cross1.ToNative());
                        break;
                    }
                    case LineLayer cross:
                    {
                        var source = _map.GetSource(cross.SourceId.Prefix());
                        if (source == null)
                        {
                            continue;
                        }

                        _map.AddLayer(cross.ToNative());
                        break;
                    }
                }
            }
        }

        private void OnAnnotationsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (Annotation annot in e.NewItems)
                    {
                        AddAnnotation(annot);
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    var items = new List<Annotation>();
                    foreach (Annotation annot in e.OldItems)
                    {
                        items.Add(annot);
                    }
                    RemoveAnnotations(items.ToArray());
                    foreach (var item in items)
                    {
                        _annotationDictionaries.Remove(item.Id);
                    }
                    break;
                case NotifyCollectionChangedAction.Reset:
                    _map.RemoveAnnotations();
                    _annotationDictionaries.Clear();
                    break;
                case NotifyCollectionChangedAction.Replace:
                    var itemsToRemove = new List<Annotation>();
                    foreach (Annotation annot in e.OldItems)
                    {
                        itemsToRemove.Add(annot);
                    }
                    RemoveAnnotations(itemsToRemove.ToArray());

                    var itemsToAdd = new List<Annotation>();
                    foreach (Annotation annot in e.NewItems)
                    {
                        itemsToAdd.Add(annot);
                    }
                    AddAnnotations(itemsToAdd.ToArray());
                    break;
            }
        }

        void RemoveAnnotations(Annotation[] annotations)
        {
            var currentAnnotations = _map.Annotations;
            if (currentAnnotations == null)
            {
                return;
            }
            var annots = new List<Sdk.Annotations.Annotation>();
            foreach (Annotation at in annotations)
            {
                if (_annotationDictionaries.ContainsKey(at.Id))
                {
                    annots.Add(_annotationDictionaries[at.Id]);
                }
            }
            _map.RemoveAnnotations(annots.ToArray());
        }

        void AddAnnotations(Annotation[] annotations)
        {
            foreach (Annotation at in annotations)
            {
                AddAnnotation(at);
            }
        }

        private Sdk.Annotations.Annotation AddAnnotation(Annotation at)
        {
            Sdk.Annotations.Annotation options = null;

            switch (at)
            {
                case PointAnnotation pointAnnotation:
                    var marker = new MarkerOptions();
                    marker.SetTitle(pointAnnotation.Title);
                    marker.SetSnippet(pointAnnotation.Title);
                    marker.SetPosition(pointAnnotation.Coordinate.ToLatLng());

                    if (!string.IsNullOrEmpty(pointAnnotation.Icon))
                    {
                        var imageName = pointAnnotation.Icon
                            .Replace(".png", string.Empty)
                            .Replace(".jpg", string.Empty)
                            .Replace(".gif", string.Empty);

                        var resId = Context.Resources.GetIdentifier(imageName, "drawable", Context.PackageName);

                        var iconFactory = IconFactory.GetInstance(Context);
                        var icon = iconFactory.FromResource(resId);
                        marker.SetIcon(icon);
                    }

                    options = _map.AddMarker(marker);
                    break;
                case PolylineAnnotation polylineAnnotation:
                {
                    if (polylineAnnotation?.Coordinates ==null || 
                        polylineAnnotation?.Coordinates?.Count() == 0)
                    {
                        return null;
                    }

                    if (polylineAnnotation.Coordinates is INotifyCollectionChanged notifyCollection)
                    {
                        notifyCollection.CollectionChanged += (s, e) =>
                        {
                            if (e.Action == NotifyCollectionChangedAction.Add)
                            {
                                if (_annotationDictionaries.ContainsKey(at.Id))
                                {
                                    var poly = _annotationDictionaries[at.Id] as Polyline;
                                    poly?.AddPoint(polylineAnnotation.Coordinates.ElementAt(e.NewStartingIndex)
                                        .ToLatLng());
                                }
                                else
                                {
                                    var coords = new ArrayList();
                                    for (var i = 0; i < polylineAnnotation.Coordinates.Count(); i++)
                                    {
                                        coords.Add(polylineAnnotation.Coordinates.ElementAt(i).ToLatLng());
                                    }
                                    var polylineOpt = new PolylineOptions();
                                    polylineOpt.Polyline.Width = Context.ToPixels(1);
                                    polylineOpt.Polyline.Color = Android.Graphics.Color.Blue;
                                    polylineOpt.AddAll(coords);
                                    options = _map.AddPolyline(polylineOpt);
                                    _annotationDictionaries.Add(at.Id, options);
                                }
                            }
                            else if (e.Action == NotifyCollectionChangedAction.Remove)
                            {
                                if (!_annotationDictionaries.ContainsKey(at.Id)) return;

                                var poly = _annotationDictionaries[at.Id] as Polyline;
                                poly?.Points.Remove(polylineAnnotation.Coordinates.ElementAt(e.OldStartingIndex)
                                    .ToLatLng());
                            }
                        };
                    }
                    break;
                }
                case MultiPolylineAnnotation multiPolyline:
                {
                    if (multiPolyline?.Coordinates == null || 
                        multiPolyline.Coordinates.Length == 0)
                    {
                        return null;
                    }

                    var lines = new List<PolylineOptions>();

                    for (var i = 0; i < multiPolyline.Coordinates.Length; i++)
                    {
                        if (multiPolyline.Coordinates[i].Length == 0)
                        {
                            continue;
                        }
                        var coords = new PolylineOptions();
                        for (var j = 0; j < multiPolyline.Coordinates[i].Length; j++)
                        {
                            coords.Add(new LatLng(multiPolyline.Coordinates[i][j].Lat, multiPolyline.Coordinates[i][j].Long));
                        }
                        lines.Add(coords);
                    }

                    _map.AddPolylines(lines);
                    break;
                }
            }

            if (options == null) return options;

            if (at.Id != null)
            {
                _annotationDictionaries.Add(at.Id, options);
            }

            return options;
        }

        void RemoveAllAnnotations()
        {
            if (_map.Annotations != null)
            {
                _map.RemoveAnnotations(_map.Annotations);
            }
        }

        private byte[] _result;
        void MapboxMap.ISnapshotReadyCallback.OnSnapshotReady(Bitmap bmp)
        {
            MemoryStream stream = new MemoryStream();
            bmp.Compress(Bitmap.CompressFormat.Png, 0, stream);
            _result = stream.ToArray();
        }

        public void OnMapReady(MapboxMap p0)
        {
            _map = p0;

            _map.MyLocationEnabled = true;
            _map.UiSettings.RotateGesturesEnabled = Element.RotateEnabled;
            _map.UiSettings.TiltGesturesEnabled = Element.PitchEnabled;

            if (Element.Center != null) {
				_map.CameraPosition = new CameraPosition.Builder()
                    .Target(Element.Center.ToLatLng())
			   .Zoom(Element.ZoomLevel)
			   .Build();
            }
            else {
				_map.CameraPosition = new CameraPosition.Builder()
                    .Target(_map.CameraPosition.Target)
			   .Zoom(Element.ZoomLevel)
			   .Build();
            }

            AddMapEvents();

            SetupFunctions();
            UpdateMapStyle();
            SetAnnotations();
        }

        private void SetAnnotations()
        {
            RemoveAllAnnotations();
            if (Element.Annotations != null)
            {
                AddAnnotations(Element.Annotations.Cast<Annotation>().ToArray());

                if (!(Element.Annotations is INotifyCollectionChanged notifyCollection)) return;

                if (_notifyCollectionChanged != null)
                {
                    _notifyCollectionChanged.CollectionChanged -= OnAnnotationsCollectionChanged;
                }

                _notifyCollectionChanged = notifyCollection;
                _notifyCollectionChanged.CollectionChanged += OnAnnotationsCollectionChanged;
            }
        }
    }
}
