using System;
using System.Collections.Generic;
using System.Linq;
using CoreGraphics;
using Foundation;
using Mapbox;
using Naxam.Controls.Mapbox.Forms;
using Xamarin.Forms.Platform.iOS;
using CoreLocation;
using FormsMap = Naxam.Controls.Mapbox.Forms.MapView;
using FormsMB = Naxam.Controls.Mapbox.Forms;
using System.Collections.Specialized;
using UIKit;
using Xamarin.Forms;
using System.ComponentModel;
using System.Collections;
using System.Collections.ObjectModel;
using Naxam.Extensions.iOS;
using Naxam.Mapbox.Platform.iOS;

[assembly: Xamarin.Forms.ExportRenderer (typeof (Naxam.Controls.Mapbox.Forms.MapView), typeof (Naxam.Controls.Mapbox.Platform.iOS.MapViewRenderer))]
namespace Naxam.Controls.Mapbox.Platform.iOS
{
    public partial class MapViewRenderer : ViewRenderer<Naxam.Controls.Mapbox.Forms.MapView, MGLMapView>, IMGLMapViewDelegate, IUIGestureRecognizerDelegate
    {
        MGLMapView MapView { get; set; }
       
        protected override void OnElementChanged(ElementChangedEventArgs<MapView> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null || Element == null)
            {
                return;
            }

            try
            {
                if (Control == null)
                {
                    SetupUserInterface();
                    SetupEventHandlers();
                    SetupFunctions();
                    SetNativeControl(MapView);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(@"          ERROR: ", ex.Message);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (MapView == null || Element == null)
            {
                return;
            }

            if (e.PropertyName == FormsMap.CenterProperty.PropertyName)
            {
                UpdateCenter();
            }
            else if (e.PropertyName == FormsMap.ZoomLevelProperty.PropertyName
                     && !Math.Round(Element.ZoomLevel * 100).Equals(Math.Round(MapView.ZoomLevel * 100)))
            {
                //MapView.SetZoomLevel(Element.ZoomLevel, true);
                MapView.ZoomLevel = Element.ZoomLevel;
                MapView.ScrollEnabled = false;
            }
            else if (e.PropertyName == FormsMap.PitchEnabledProperty.PropertyName && MapView.PitchEnabled != Element.PitchEnabled)
            {
                MapView.PitchEnabled = Element.PitchEnabled;
            }
            else if (e.PropertyName == FormsMap.RotateEnabledProperty.PropertyName && MapView.RotateEnabled != Element.RotateEnabled)
            {
                MapView.RotateEnabled = Element.RotateEnabled;
            }
            else if (e.PropertyName == FormsMap.AnnotationsProperty.PropertyName)
            {
                if (Element.Annotations != null)
                {
                    AddAnnotations(Element.Annotations.Cast<Annotation>().ToArray());
                    var notifyCollection = Element.Annotations as INotifyCollectionChanged;
                    if (notifyCollection != null)
                    {
                        notifyCollection.CollectionChanged += OnAnnotationsCollectionChanged;
                    }
                }
            }
            //else if (e.PropertyName == FormsMap.StyleUrlProperty.PropertyName
            //       && !string.IsNullOrEmpty(Element.StyleUrl)
            //         && (MapView.StyleURL == null
            //             || MapView.StyleURL.AbsoluteString != Element.StyleUrl))
            //{
            //  MapView.StyleURL = new NSUrl(Element.StyleUrl);
            //}
            else if (e.PropertyName == FormsMap.MapStyleProperty.PropertyName
                     && Element.MapStyle != null
                     && !string.IsNullOrEmpty(Element.MapStyle.UrlString)
                    && (MapView.StyleURL == null
                        || MapView.StyleURL.AbsoluteString != Element.MapStyle.UrlString))
            {
                UpdateMapStyle();
            }
            else if (e.PropertyName == FormsMap.PitchProperty.PropertyName
                     && !Element.Pitch.Equals(MapView.Camera.Pitch))
            {
                var currentCamera = MapView.Camera;
                var newCamera = MGLMapCamera.CameraLookingAtCenterCoordinate(currentCamera.CenterCoordinate,
                                                                             currentCamera.Altitude,
                                                                              (nfloat)Element.Pitch,
                                                                             currentCamera.Heading);
                MapView.SetCamera(newCamera, true);
            }
            else if (e.PropertyName == FormsMap.RotatedDegreeProperty.PropertyName
                     && !Element.RotatedDegree.Equals(MapView.Camera.Heading))
            {
                var currentCamera = MapView.Camera;
                var newCamera = MGLMapCamera.CameraLookingAtCenterCoordinate(currentCamera.CenterCoordinate,
                                                                              currentCamera.Altitude,
                                                                              currentCamera.Pitch,
                                                                              (nfloat)Element.RotatedDegree);
                MapView.SetCamera(newCamera, true);
            }
        }

        void OnElementPropertyChanging(object sender, Xamarin.Forms.PropertyChangingEventArgs e)
        {
            if (Element == null) return;
            if (e.PropertyName == FormsMap.AnnotationsProperty.PropertyName
                && Element.Annotations != null)
            {
                RemoveAllAnnotations();
                var notifyCollection = Element.Annotations as INotifyCollectionChanged;
                if (notifyCollection != null)
                {
                    notifyCollection.CollectionChanged -= OnAnnotationsCollectionChanged;
                }
            }
            else if (e.PropertyName == FormsMap.MapStyleProperty.PropertyName
                     && Element.MapStyle != null)
            {
                if (Element.MapStyle.CustomSources != null)
                {
                    var notifiyCollection = Element.MapStyle.CustomSources as INotifyCollectionChanged;
                    if (notifiyCollection != null)
                    {
                        notifiyCollection.CollectionChanged -= OnShapeSourcesCollectionChanged;
                    }
                    RemoveSources(Element.MapStyle.CustomSources.ToList());
                }
                if (Element.MapStyle.CustomLayers != null)
                {
                    var notifiyCollection = Element.MapStyle.CustomLayers as INotifyCollectionChanged;
                    if (notifiyCollection != null)
                    {
                        notifiyCollection.CollectionChanged -= OnLayersCollectionChanged;
                    }
                    RemoveLayers(Element.MapStyle.CustomLayers.ToList());
                }

                Element.MapStyle.PropertyChanging -= OnMapStylePropertyChanging;
                Element.MapStyle.PropertyChanged -= OnMapStylePropertyChanged;
            }
        }

        void SetupUserInterface()
        {
            try
            {
                CGRect cgrect = new CGRect(x: 0, y: 0, width: 1, height: 1);
                //System.Diagnostics.Debug.WriteLine("string " + Bounds.X,Bounds.Y,Bounds.Width,Bounds.Height);
                MapView = new MGLMapView(Bounds)
                {
                    ShowsUserLocation = true,
                    WeakDelegate = this,
                    PitchEnabled = Element.PitchEnabled,
                    RotateEnabled = Element.RotateEnabled
                };
                MapView.ZoomLevel = Element.ZoomLevel;
                UpdateMapStyle();
                UpdateCenter();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(@"          ERROR: ", ex.Message);
            }
        }

        void UpdateCenter()
        {
            if (Element.Center != null && MapView != null
                && (!Element.Center.Lat.Equals(MapView.CenterCoordinate.Latitude)
                    || !Element.Center.Long.Equals(MapView.CenterCoordinate.Longitude)))
            {
                MapView.SetCenterCoordinate(new CoreLocation.CLLocationCoordinate2D(Element.Center.Lat, Element.Center.Long), true);
            }
        }

        void UpdateMapStyle()
        {
            if (Element.MapStyle != null && !string.IsNullOrEmpty(Element.MapStyle.UrlString))
            {
                MapView.StyleURL = new NSUrl(Element.MapStyle.UrlString);
                Element.MapStyle.PropertyChanging += OnMapStylePropertyChanging;
                Element.MapStyle.PropertyChanged += OnMapStylePropertyChanged;
            }

        }

        void OnMapStylePropertyChanging(object sender, Xamarin.Forms.PropertyChangingEventArgs e)
        {
            if (e.PropertyName == MapStyle.CustomSourcesProperty.PropertyName
                && (sender as MapStyle).CustomSources != null)
            {
                var notifiyCollection = (sender as MapStyle).CustomSources as INotifyCollectionChanged;
                if (notifiyCollection != null)
                {
                    notifiyCollection.CollectionChanged -= OnShapeSourcesCollectionChanged;
                }
                RemoveSources(Element.MapStyle.CustomSources.ToList());
            }
            else if (e.PropertyName == MapStyle.CustomLayersProperty.PropertyName
                       && (sender as MapStyle).CustomLayers != null)
            {
                var notifiyCollection = Element.MapStyle.CustomLayers as INotifyCollectionChanged;
                if (notifiyCollection != null)
                {
                    notifiyCollection.CollectionChanged -= OnLayersCollectionChanged;
                }
                RemoveLayers(Element.MapStyle.CustomLayers.ToList());
            }
        }

        void OnMapStylePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == MapStyle.CustomSourcesProperty.PropertyName
                && (sender as MapStyle).CustomSources != null)
            {
                var notifiyCollection = Element.MapStyle.CustomSources as INotifyCollectionChanged;
                if (notifiyCollection != null)
                {
                    notifiyCollection.CollectionChanged += OnShapeSourcesCollectionChanged;
                }

                AddSources(Element.MapStyle.CustomSources.ToList());
            }
            else if (e.PropertyName == MapStyle.CustomLayersProperty.PropertyName
                     && (sender as MapStyle).CustomLayers != null)
            {
                var notifiyCollection = Element.MapStyle.CustomLayers as INotifyCollectionChanged;
                if (notifiyCollection != null)
                {
                    notifiyCollection.CollectionChanged += OnLayersCollectionChanged;
                }

                AddLayers(Element.MapStyle.CustomLayers.ToList());
            }
        }

        void SetupEventHandlers()
        {
            var tapGest = new UITapGestureRecognizer();
            tapGest.NumberOfTapsRequired = 1;
            tapGest.CancelsTouchesInView = false;
            tapGest.Delegate = this;
            MapView.AddGestureRecognizer(tapGest);
            tapGest.AddTarget((NSObject obj) => {
                var gesture = obj as UITapGestureRecognizer;
                if (gesture.State == UIGestureRecognizerState.Ended)
                {
                    var point = gesture.LocationInView(MapView);
                    var touchedCooridinate = MapView.ConvertPoint(point, MapView);
                    var position = new Position(touchedCooridinate.Latitude, touchedCooridinate.Longitude);
                    Element.DidTapOnMapCommand?.Execute(new Tuple<Position, Point>(position,
                                                                                   new Point((double)point.X, (double)point.Y)));
                }
            });
            Element.PropertyChanging += OnElementPropertyChanging;
        }

        protected void SetupFunctions()
        {
            Element.TakeSnapshotFunc = () => {
                var image = MapView.Capture(true);
                var imageData = image.AsJPEG();
                Byte[] imgByteArray = new Byte[imageData.Length];
                System.Runtime.InteropServices.Marshal.Copy(imageData.Bytes,
                                                            imgByteArray,
                                                            0,
                                                            Convert.ToInt32(imageData.Length));
                return imgByteArray;
            };

            Element.GetFeaturesAroundPointFunc = (Point point, double radius, string[] layers) => {
                var selectableLayers = SelectableLayersFromSources(layers);
                NSObject[] features;
                var cgPoint = new CGPoint((nfloat)point.X, (nfloat)point.Y);
                if (radius <= 0)
                {
                    features = MapView.VisibleFeaturesAtPoint(cgPoint, selectableLayers);
                }
                else
                {
                    var rect = new CGRect(cgPoint.X - (nfloat)radius, cgPoint.Y - (nfloat)radius, (nfloat)radius * 2, (nfloat)radius * 2);
                    features = MapView.VisibleFeaturesInRect(rect, selectableLayers);
                }

                var output = new List<IFeature>();

                foreach (NSObject obj in features)
                {
                    var feature = obj as IMGLFeature;
                    if (feature == null || feature.Attributes == null)
                    {
                        continue;
                    }
                    string id = null;
                    if (feature.Identifier != null)
                    {
                        if (feature.Identifier is NSNumber)
                        {
                            id = ((NSNumber)feature.Identifier).StringValue;
                        }
                        else
                        {
                            id = feature.Identifier.ToString();
                        }
                    }
                    if (id == null || output.Any((arg) => (arg as Annotation).Id == id))
                    {
                        continue;
                    }


                    var geoData = feature.GeoJSONDictionary;
                    if (geoData == null) continue;

                    IFeature ifeat = null;

                    if (feature is MGLPointFeature)
                    {
                        ifeat = new PointFeature();
                        (ifeat as PointFeature).Title = ((MGLPointFeature)feature).Title;
                        (ifeat as PointFeature).SubTitle = ((MGLPointFeature)feature).Subtitle;
                        (ifeat as PointFeature).Coordinate = TypeConverter.FromCoordinateToPosition(((MGLPointFeature)feature).Coordinate);
                    }
                    else
                    {
                        var geometry = geoData["geometry"];
                        NSArray coorArr = null;
                        var coordinates = (geometry as NSDictionary)["coordinates"];
                        if (coordinates != null && coordinates is NSArray)
                        {
                            coorArr = coordinates as NSArray;
                        }
                        if (feature is MGLPolylineFeature)
                        {
                            ifeat = new PolylineFeature();
                            (ifeat as PolylineFeature).Title = ((MGLPolylineFeature)feature).Title;
                            (ifeat as PolylineFeature).SubTitle = ((MGLPolylineFeature)feature).Subtitle;

                            if (coorArr != null)
                            {
                                var coorsList = new List<Position>();
                                (ifeat as PolylineFeature).Coordinates = new Position[coorArr.Count];
                                for (nuint i = 0; i < coorArr.Count; i++)
                                {
                                    var childArr = coorArr.GetItem<NSArray>(i);
                                    if (childArr != null && childArr.Count == 2)
                                    {
                                        var coord = new Position(childArr.GetItem<NSNumber>(1).DoubleValue, //lat
                                                                childArr.GetItem<NSNumber>(0).DoubleValue); //long
                                        coorsList.Add(coord);
                                    }
                                }
                                (ifeat as PolylineFeature).Coordinates = new ObservableCollection<Position>(coorsList);
                            }

                        }
                        else if (feature is MGLMultiPolylineFeature)
                        {
                            ifeat = new MultiPolylineFeature();
                            (ifeat as MultiPolylineFeature).Title = ((MGLMultiPolylineFeature)feature).Title;
                            (ifeat as MultiPolylineFeature).SubTitle = ((MGLMultiPolylineFeature)feature).Subtitle;
                            if (coorArr != null)
                            {
                                (ifeat as MultiPolylineFeature).Coordinates = new Position[coorArr.Count][];
                                for (nuint i = 0; i < coorArr.Count; i++)
                                {
                                    var childArr = coorArr.GetItem<NSArray>(i);
                                    if (childArr != null)
                                    {
                                        (ifeat as MultiPolylineFeature).Coordinates[i] = new Position[childArr.Count];
                                        for (nuint j = 0; j < childArr.Count; j++)
                                        {
                                            var anscArr = childArr.GetItem<NSArray>(j);
                                            if (anscArr != null && anscArr.Count == 2)
                                            {
                                                (ifeat as MultiPolylineFeature).Coordinates[i][j] = new Position(anscArr.GetItem<NSNumber>(1).DoubleValue, //lat
                                                                                                                anscArr.GetItem<NSNumber>(0).DoubleValue);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (ifeat != null)
                    {
                        (ifeat as Annotation).Id = id;
                        ifeat.Attributes = ConvertDictionary(feature.Attributes);


                        output.Add(ifeat);
                    }
                }

                return output.ToArray();
            };

            Element.ResetPositionAction = () => {
                MapView.ResetPosition();
            };

            Element.ReloadStyleAction = () =>
            {
                MapView.ReloadStyle(MapView);
            };

            Element.UpdateShapeOfSourceFunc = (Annotation annotation, string sourceId) => {
                if (annotation != null && !string.IsNullOrEmpty(sourceId))
                {
                    var mglSource = MapView.Style.SourceWithIdentifier(sourceId.ToCustomId());
                    if (mglSource != null && mglSource is MGLShapeSource)
                    {
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            (mglSource as MGLShapeSource).Shape = ShapeFromAnnotation(annotation);
                        });
                        if (Element.MapStyle.CustomSources != null)
                        {
                            var count = Element.MapStyle.CustomSources.Count();
                            for (var i = 0; i < count; i++)
                            {
                                if (Element.MapStyle.CustomSources.ElementAt(i).Id == sourceId)
                                {
                                    Element.MapStyle.CustomSources.ElementAt(i).Shape = annotation;
                                    break;
                                }
                            }
                        }
                        return true;
                    }
                }
                return false;
            };

            Element.UpdateLayerFunc = (string layerId, bool isVisible, bool IsCustom) => {
                if (!string.IsNullOrEmpty(layerId))
                {
                    NSString layerIdStr = IsCustom ? layerId.ToCustomId() : (NSString)layerId;
                    var layer = MapView.Style.LayerWithIdentifier(layerIdStr);
                    if (layer != null)
                    {
                        layer.Visible = isVisible;
                        if (IsCustom && Element.MapStyle.CustomLayers != null)
                        {
                            var count = Element.MapStyle.CustomLayers.Count();
                            for (var i = 0; i < count; i++)
                            {
                                if (Element.MapStyle.CustomLayers.ElementAt(i).Id == layerId)
                                {
                                    Element.MapStyle.CustomLayers.ElementAt(i).IsVisible = isVisible;
                                    break;
                                }
                            }
                        }
                        return true;
                    }
                }
                return false;
            };

            Element.UpdateViewPortAction = (Position centerLocation, double? zoomLevel, double? bearing, bool animated, Action completionBlock) => {
                MapView.SetCenterCoordinate(
                    centerLocation?.ToCLCoordinate() ?? MapView.CenterCoordinate,
                    zoomLevel ?? MapView.ZoomLevel,
                    bearing ?? MapView.Direction,
                    animated,
                    completionBlock
                );
            };

            //Element.GetMapScaleReciprocalFunc = () => {
            //             if (MapView == null) return 500000000;
            //             System.Diagnostics.Debug.WriteLine($"Center latitude: {MapView.CenterCoordinate.Latitude}");
            //  var metersPerPoint = MapView.MetersPerPointAtLatitude(MapView.CenterCoordinate.Latitude);
            //  System.Diagnostics.Debug.WriteLine($"metersPerPoint: {metersPerPoint}");
            //  var resolution = metersPerPoint / Math.Pow(2, MapView.ZoomLevel);
            //             System.Diagnostics.Debug.WriteLine($"resolution: {resolution}");
            //  var output = UIDeviceExtensions.DPI() * 39.37 * resolution;
            //  return output;
            //};

            Element.ToggleScaleBarFunc = (bool show) => {
                if (MapView == null || MapView.ScaleBar == null) return false;
                InvokeOnMainThread(() => {
                    System.Diagnostics.Debug.WriteLine($"Toggle scale bar: {show}");
                    MapView.ScaleBar.Hidden = !show;
                });

                return true;
            };

            Element.GetStyleImageFunc = (imageName) => {
                if (string.IsNullOrEmpty(imageName)
                    || MapView == null
                    || MapView.Style == null) return null;
                return MapView.Style.ImageForName(imageName)?.AsPNG().ToArray();
            };

            Element.GetStyleLayerFunc = (string layerId, bool isCustom) => {
                if (string.IsNullOrEmpty(layerId)
                    || MapView == null
                    || MapView.Style == null) return null;
                NSString layerIdStr = isCustom ? layerId.ToCustomId() : (NSString)layerId;
                var layer = MapView.Style.LayerWithIdentifier(layerIdStr);
                if (layer is MGLVectorStyleLayer vLayer) return CreateStyleLayer(vLayer, layerId);

                return null;
            };
        }

        NSSet<NSString> SelectableLayersFromSources(string[] layersId)
        {
            if (layersId == null)
            {
                return null;
            }

            NSMutableSet<NSString> output = new NSMutableSet<NSString>();
            foreach (string layerId in layersId)
            {
                var acceptedId = layerId.Replace("_", "-");
                output.Add((NSString)acceptedId);
                output.Add((NSString)(acceptedId + " (1)"));
            }
            return new NSSet<NSString>(output);
        }

        void AddAnnotation(Annotation annotation)
        {
            var shape = ShapeFromAnnotation(annotation);
            if (shape != null)
            {
                MapView.AddAnnotation(shape);
            }
        }

        void AddAnnotations(Annotation[] annotations)
        {

            var annots = new List<IMGLAnnotation>();
            foreach (Annotation at in annotations)
            {
                var shape = ShapeFromAnnotation(at);
                if (shape == null)
                {
                    continue;
                }
                annots.Add(shape);
            }
            MapView.AddAnnotations(annots.ToArray());
        }

        void RemoveAnnotations(Annotation[] annotations)
        {
            var currentAnnotations = MapView.Annotations;
            if (currentAnnotations == null)
            {
                return;
            }
            var annots = new List<MGLShape>();
            foreach (Annotation at in annotations)
            {
                foreach (NSObject curAnnot in currentAnnotations)
                {
                    if (curAnnot is MGLShape)
                    {
                        var shape = curAnnot as MGLShape;
                        if (string.IsNullOrEmpty(shape.Id()))
                        {
                            continue;
                        }
                        if (shape.Id() == at.Id)
                        {
                            annots.Add(shape);
                        }
                    }
                }
            }
            MapView.RemoveAnnotations(annots.ToArray());
        }

        void RemoveAllAnnotations()
        {
            if (MapView == null) return;
            if (MapView.Annotations != null)
            {
                MapView.RemoveAnnotations(MapView.Annotations);
            }
        }

        private void OnAnnotationsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                var annots = new List<MGLShape>();
                foreach (Annotation annot in e.NewItems)
                {
                    var shape = ShapeFromAnnotation(annot);
                    if (shape != null)
                    {
                        annots.Add(shape);
                    }
                }
                MapView.AddAnnotations(annots.ToArray());
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                var items = new List<Annotation>();
                foreach (Annotation annot in e.OldItems)
                {
                    items.Add(annot);
                }
                RemoveAnnotations(items.ToArray());
            }
            else if (e.Action == NotifyCollectionChangedAction.Reset) //The content of the collection was cleared.
            {
                RemoveAllAnnotations();
            }
            else if (e.Action == NotifyCollectionChangedAction.Replace)
            {
                var itemsToRemove = new List<Annotation>();
                foreach (Annotation annot in e.OldItems)
                {
                    itemsToRemove.Add(annot);
                }
                RemoveAnnotations(itemsToRemove.ToArray());
                var annots = new List<MGLShape>();
                foreach (Annotation annot in e.NewItems)
                {
                    var shape = ShapeFromAnnotation(annot);
                    if (shape != null)
                    {
                        annots.Add(shape);
                    }
                }
                MapView.AddAnnotations(annots.ToArray());
            }
        }
        void OnLayersCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    AddLayers(e.NewItems);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    RemoveLayers(e.OldItems);
                    break;
                case NotifyCollectionChangedAction.Reset:
                    var layersToRemove = new List<MGLStyleLayer>();
                    foreach (MGLStyleLayer layer in MapView.Style.Layers)
                    {
                        if (layer.Identifier.IsCustomId())
                        {
                            layersToRemove.Add(layer);
                        }
                    }
                    foreach (MGLStyleLayer layer in layersToRemove)
                    {
                        MapView.Style.RemoveLayer(layer);

                    }
                    layersToRemove.Clear();
                    break;
                case NotifyCollectionChangedAction.Replace:
                    RemoveLayers(e.OldItems);

                    AddLayers(e.NewItems);
                    break;
                default:
                    break;
            }
        }

        void AddLayers(System.Collections.IList layers)
        {
            if (layers == null)
            {
                return;
            }
            foreach (Layer layer in layers)
            {
                if (string.IsNullOrEmpty(layer.Id))
                {
                    continue;
                }
                NSString id = layer.Id.ToCustomId();
                var oldLayer = MapView.Style.LayerWithIdentifier(id);
                if (oldLayer != null)
                {
                    MapView.Style.RemoveLayer(oldLayer);
                }
                if (layer is StyleLayer sl)
                {
                    var newLayer = GetStyleLayer(sl, id);
                    if (newLayer != null)
                    {
                        MapView.Style.AddLayer(newLayer);
                    }
                }
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
                if (string.IsNullOrEmpty(layer.Id))
                {
                    continue;
                }
                NSString id = layer.Id.ToCustomId();
                var oldLayer = MapView.Style.LayerWithIdentifier(id);
                if (oldLayer != null)
                {
                    MapView.Style.RemoveLayer(oldLayer);
                }
            }
        }

        void OnShapeSourcesCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                AddSources(e.NewItems);
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                RemoveSources(e.OldItems);
            }
            else if (e.Action == NotifyCollectionChangedAction.Reset)
            {
                var sourcesToRemove = new List<MGLSource>();
                foreach (MGLSource source in MapView.Style.Sources)
                {
                    if (source.Identifier.IsCustomId())
                    {
                        sourcesToRemove.Add(source);
                    }
                }
                foreach (MGLSource source in sourcesToRemove)
                {
                    MapView.Style.RemoveSource(source);

                }
                sourcesToRemove.Clear();
            }
            else if (e.Action == NotifyCollectionChangedAction.Replace)
            {
                RemoveSources(e.OldItems);
                AddSources(e.NewItems);
            }
        }

        void AddSources(System.Collections.IList sources)
        {
            if (sources == null || MapView == null || MapView.Style == null)
            {
                return;
            }
            foreach (ShapeSource source in sources)
            {
                if (source.Id != null && source.Shape != null)
                {
                    var shape = ShapeFromAnnotation(source.Shape);
                    var sourceId = source.Id.ToCustomId();
                    var oldSource = MapView.Style?.SourceWithIdentifier(sourceId);
                    if (oldSource != null && oldSource is MGLShapeSource)
                    {
                        (oldSource as MGLShapeSource).Shape = shape;
                    }
                    else
                    {
                        var mglSource = new MGLShapeSource(sourceId, shape, null);
                        MapView.Style.AddSource(mglSource);
                    }
                }
            }
        }

        void RemoveSources(System.Collections.IList sources)
        {
            if (sources == null)
            {
                return;
            }
            foreach (ShapeSource source in sources)
            {
                if (source.Id != null)
                {
                    var oldSource = MapView.Style.SourceWithIdentifier(source.Id.ToCustomId()) as MGLShapeSource;
                    if (oldSource != null)
                    {
                        MapView.Style.RemoveSource(oldSource);
                    }
                }
            }
        }
       
        MGLShape ShapeFromAnnotation(FormsMB.Annotation annotation)
        {
            MGLShape shape = null;
            if (annotation is PointAnnotation)
            {
                shape = new MGLPointAnnotation()
                {
                    Coordinate = ((PointAnnotation)annotation).Coordinate.ToCLCoordinate(),
                };
            }
            else if (annotation is PolylineAnnotation)
            {
                var polyline = annotation as PolylineAnnotation;
                shape = PolyLineWithCoordinates(polyline.Coordinates.ToArray());
                var notifiyCollection = polyline.Coordinates as INotifyCollectionChanged;
                if (notifiyCollection != null)
                {
                    notifiyCollection.CollectionChanged += (sender, e) => {
                        //TODO Move to a separated method
                        if (e.Action == NotifyCollectionChangedAction.Add)
                        {
                            foreach (Position pos in e.NewItems)
                            {
                                var coord = TypeConverter.FromPositionToCoordinate(pos);
                                NSArray nsarray = NSArray.FromObjects(coord);
                                (shape as MGLPolyline).AppendCoordinates(nsarray, 1);
                            }
                        }
                        else if (e.Action == NotifyCollectionChangedAction.Remove)
                        {
                            (shape as MGLPolyline).RemoveCoordinatesInRange(new NSRange(e.OldStartingIndex, e.OldItems.Count));
                        }
                    };
                }

            }
            else if (annotation is MultiPolylineAnnotation)
            {
                var polyline = annotation as MultiPolylineAnnotation;
                if (polyline.Coordinates == null || polyline.Coordinates.Length == 0)
                {
                    return null;
                }
                var lines = new MGLPolyline[polyline.Coordinates.Length];
                for (var i = 0; i < polyline.Coordinates.Length; i++)
                {
                    if (polyline.Coordinates[i].Length == 0)
                    {
                        continue;
                    }
                    lines[i] = PolyLineWithCoordinates(polyline.Coordinates[i]);
                }
                shape = MGLMultiPolyline.MultiPolylineWithPolylines(lines);
            }
            if (shape != null)
            {
                if (annotation.Title != null)
                {
                    shape.Title = annotation.Title;
                }
                if (annotation.SubTitle != null)
                {
                    shape.Subtitle = annotation.SubTitle;
                }
                if (!string.IsNullOrEmpty(annotation.Id))
                {
                    shape.SetId(annotation.Id);
                }
            }

            return shape;
        }

        MGLPolyline PolyLineWithCoordinates(Position[] positions)
        {
            if (positions == null || positions.Length == 0)
            {
                return null;
            }
            var first = positions[0].ToCLCoordinate();
            var output = MGLPolyline.PolylineWithCoordinates(ref first, 1);
            var i = 1;
            while (i < positions.Length)
            {
                var coord = positions[i].ToCLCoordinate();
                NSArray nsarray = NSArray.FromObjects(coord);
                output.AppendCoordinates(nsarray, 1);
                i++;
            }
            return output;
        }

        #region MGLMapViewDelegate
        [Export("mapViewDidFinishRenderingMap:fullyRendered:"),]
        void DidFinishRenderingMap(MGLMapView mapView, bool fullyRendered)
        {
            Element.DidFinishRenderingCommand?.Execute(
                fullyRendered);
        }

        [Export("mapView:didUpdateUserLocation:"),]
        void DidUpdateUserLocation(MGLMapView mapView, MGLUserLocation userLocation)
        {
            if (userLocation != null)
            {
                Element.UserLocation = new Position(
                    userLocation.Location.Coordinate.Latitude,
                    userLocation.Location.Coordinate.Longitude
                );
            }
        }
        [Export("mapView:viewForAnnotation:")]
        MGLAnnotationView MapView_ImageForAnnotation(MGLMapView mapView, IMGLAnnotation annotation)
        {
            MapView.ScrollEnabled = false;
            var mapAnnotation = mapView.Annotations;
            var itemAnnotation = Element.Annotations.Cast<Annotation>().ToArray();
            var title = annotation.GetTitle();
            var mapType = "";
            var color = "";
            foreach (var item in itemAnnotation)
            {
                var itemAnn = item as PointAnnotation;
                if(title.Equals(itemAnn.Title)){
                    color = itemAnn.Color;
                    mapType = itemAnn.MapType;
                }
            }
            var imageName = "";
            if(color == "red" && mapType == "comrades"){
                imageName = "map_army_red_small";
            }
            if(color == "yellow" && mapType == "comrades"){
                imageName = "map_army_yellow_small";
            }
            if (color == "green" && mapType == "comrades")
            {
                imageName = "map_army_green_small";
            }
            if (color == "red" && mapType == "recruit")
            {
                imageName = "map_red_small";
            }
            if (color == "yellow" && mapType == "recruit")
            {
                imageName = "map_yellow_small";
            }
            if (color == "green" && mapType == "recruit")
            {
                imageName = "map_green_small";
            }
            var annotationImage = MapView.DequeueReusableAnnotationViewWithIdentifier(title);
            if(annotationImage == null){
                var iosImage = new UIImage(imageName);
                if (iosImage != null)
                {
                    iosImage = iosImage.ImageWithAlignmentRectInsets(new UIEdgeInsets(0, 0, iosImage.Size.Height / 2, 0));
                    //return MGLAnnotationImage.AnnotationImageWithImage(iosImage, title);
                    var customMGL = new CustomMGLPolyline(title, iosImage);
                    //customMGL.CenterOffset = new CGVector(-8, 0);
                    return customMGL;
                }
                      
            }
            return annotationImage;
        }
       
        [Export("mapView:didFinishLoadingStyle:"),]
        void DidFinishLoadingStyle(MGLMapView mapView, MGLStyle style)
        {
            MapStyle newStyle;
            if (Element.MapStyle == null)
            {
                newStyle = new MapStyle(mapView.StyleURL.AbsoluteString);
                newStyle.Name = style.Name;
                Element.MapStyle = newStyle;
            }
            else
            {
                if (Element.MapStyle.UrlString == null
                || Element.MapStyle.UrlString != mapView.StyleURL.AbsoluteString)
                {
                    Element.MapStyle.SetUrl(mapView.StyleURL.AbsoluteString);
                    Element.MapStyle.Name = style.Name;
                }
                newStyle = Element.MapStyle;
            }
            if (Element.MapStyle.CustomSources != null)
            {
                var notifiyCollection = Element.MapStyle.CustomSources as INotifyCollectionChanged;
                if (notifiyCollection != null)
                {
                    notifiyCollection.CollectionChanged += OnShapeSourcesCollectionChanged;
                }

                AddSources(Element.MapStyle.CustomSources.ToList());
            }
            if (Element.MapStyle.CustomLayers != null)
            {
                if (Element.MapStyle.CustomLayers is INotifyCollectionChanged notifiyCollection)
                {
                    notifiyCollection.CollectionChanged += OnLayersCollectionChanged;
                }

                AddLayers(Element.MapStyle.CustomLayers.ToList());
            }

            newStyle.OriginalLayers = style.Layers.Select((MGLStyleLayer arg) => new Layer(arg.Identifier)
            {
                IsVisible = arg.Visible
            }
                                                         ).ToArray();
            newStyle.Name = style.Name;
            Element.DidFinishLoadingStyleCommand?.Execute(newStyle);
        }

        [Export("mapViewRegionIsChanging:"),]
        void RegionIsChanging(MGLMapView mapView)
        {
            Element.Center = new Position(mapView.CenterCoordinate.Latitude, mapView.CenterCoordinate.Longitude);
        }

        [Export("mapView:regionDidChangeAnimated:"),]
        void RegionDidChangeAnimated(MGLMapView mapView, bool animated)
        {
            Element.ZoomLevel = mapView.ZoomLevel;
            Element.Pitch = (double)mapView.Camera.Pitch;
            Element.RotatedDegree = (double)mapView.Camera.Heading;
            Element?.RegionDidChangeCommand?.Execute(animated);
        }

        [Export("mapView:annotationCanShowCallout:"),]
        bool AnnotationCanShowCallout(MGLMapView mapView, NSObject annotation)
        {
            if (annotation is MGLShape && Element.CanShowCalloutChecker != null)
            {
                return Element.CanShowCalloutChecker.Invoke(((MGLShape)annotation).Id());
            }
            return true;
        }
        #endregion

        #region UIGestureRecognizerDelegate
        [Export("gestureRecognizer:shouldRecognizeSimultaneouslyWithGestureRecognizer:")]
        public bool ShouldRecognizeSimultaneously(UIGestureRecognizer gestureRecognizer, UIGestureRecognizer otherGestureRecognizer)
        {
            return true;
        }

        #endregion

        Dictionary<string, object> ConvertDictionary(NSDictionary fromDict)
        {
            var output = new Dictionary<string, object>();
            foreach (NSString key in fromDict.Keys)
            {
                if (fromDict[key] is NSString)
                {
                    var str = fromDict[key] as NSString;
                    if (str == "<NULL>")
                    {
                        continue;
                    }
                    output[key] = (string)str;
                }
                else if (fromDict[key] is NSNumber)
                {
                    output[key] = (fromDict[key] as NSNumber).DoubleValue;
                }
                else if (fromDict[key] is NSDate)
                {
                    output[key] = (fromDict[key] as NSDate).ToDateTimeOffset();
                }
                else
                {
                    output[key] = fromDict[key].ToString();
                }
            }
            return output;
        }
    }

    public static class NSDateExtensions
    {
        private static DateTime _nsRef = new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Local); // last zero is millisecond

        public static DateTimeOffset ToDateTimeOffset(this NSDate date)
        {
            var interval = date.SecondsSinceReferenceDate;
            return _nsRef.AddSeconds(interval);
        }
    }

    public static class stringExtensions
    {
        static string CustomPrefix = "NXCustom_";
        public static NSString ToCustomId(this string str)
        {
            if (str == null) return null;
            return (NSString)(CustomPrefix + str);
        }

        public static bool IsCustomId(this string str)
        {
            if (str == null) return false;
            return str.StartsWith(CustomPrefix, StringComparison.OrdinalIgnoreCase);
        }

        public static string TrimCustomId(this string str)
        {
            if (str.StartsWith(CustomPrefix, StringComparison.OrdinalIgnoreCase))
            {
                return str.Substring(CustomPrefix.Length);
            }
            return str;
        }
    }
}
