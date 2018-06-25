﻿﻿using Com.Mapbox.Mapboxsdk.Maps;
using System;
using System.Linq;
using MapView = Com.Mapbox.Mapboxsdk.Maps.MapView;
using Naxam.Controls.Mapbox.Forms;
using System.Collections.Specialized;

namespace Naxam.Controls.Mapbox.Platform.Droid
{
    
    public partial class MapViewRenderer : MapView.IOnMapChangedListener
    {
        void AddMapEvents ()
        {
            _map.MarkerClick += MarkerClicked;
            _map.MapClick += MapClicked;
            _map.MyLocationChange += MyLocationChanged;
            _map.CameraIdle += OnCameraIdle;

            _fragment.OnMapChangedListener = (this);
        }

 
        void RemoveMapEvents ()
        {
            _map.MarkerClick -= MarkerClicked;
            _map.MapClick -= MapClicked;
            _map.MyLocationChange -= MyLocationChanged;
            _map.CameraIdle -= OnCameraIdle;

            _fragment.OnMapChangedListener = null;
        }

		private void OnCameraIdle(object sender, EventArgs e)
		{
            _currentCamera.Lat = _map.CameraPosition.Target.Latitude;
            _currentCamera.Long = _map.CameraPosition.Target.Longitude;
			Element.ZoomLevel = _map.CameraPosition.Zoom;
            Element.Center = _currentCamera;
		}


        void MyLocationChanged (object o, MapboxMap.MyLocationChangeEventArgs args)
        {
            if (Element.UserLocation == null)
                Element.UserLocation = new Position ();

            Element.UserLocation.Lat = args.P0.Latitude;
            Element.UserLocation.Long = args.P0.Longitude;
        }

        void MapClicked (object o, MapboxMap.MapClickEventArgs args)
        {
            Element.IsTouchInMap = false;

            var point = _map.Projection.ToScreenLocation (args.P0);
            var xfPoint = new Xamarin.Forms.Point (point.X, point.Y);
            var xfPosition = new Position (args.P0.Latitude, args.P0.Longitude);

            Element.DidTapOnMapCommand?.Execute (new Tuple<Position, Xamarin.Forms.Point> (xfPosition, xfPoint));
        }

        void MarkerClicked (object o, MapboxMap.MarkerClickEventArgs args)
        {
            Element.Center.Lat = args.P0.Position.Latitude;
            Element.Center.Long = args.P0.Position.Longitude;
            Element.IsMarkerClicked = true;

            var annotationKey = _annotationDictionaries.FirstOrDefault (x => x.Value == args.P0).Key;

            if (Element.CanShowCalloutChecker?.Invoke (annotationKey) == true) {
                args.P0.ShowInfoWindow (_map, _fragment.View as MapView);
            }
        }

        public void OnMapChanged (int p0)
        {
            switch (p0) {
            case MapView.DidFinishLoadingStyle:
                var mapStyle = Element.MapStyle;
                if (mapStyle == null
                    || (!string.IsNullOrEmpty (_map.StyleUrl) && mapStyle.UrlString != _map.StyleUrl)) {
                    mapStyle = new MapStyle (_map.StyleUrl);
                   
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
                    mapStyle.OriginalLayers = _map.Layers.Select((arg) =>
                                                                        new Layer(arg.Id) 
                                                                       ).ToArray();
					Element.MapStyle = mapStyle;
                    Element.DidFinishLoadingStyleCommand?.Execute(mapStyle);
                break;
            case MapView.DidFinishRenderingMap:
					Element.Center = new Position(_map.CameraPosition.Target.Latitude, _map.CameraPosition.Target.Longitude);
                Element.DidFinishRenderingCommand?.Execute (false);
                break;
            case MapView.DidFinishRenderingMapFullyRendered:
                Element.DidFinishRenderingCommand?.Execute (true);
                break;
            case MapView.RegionDidChange:
					Element.RegionDidChangeCommand?.Execute (false);
                break;
            case MapView.RegionDidChangeAnimated:
                Element.RegionDidChangeCommand?.Execute (true);
                break;
            default:
                break;
            }
        }
    }
}