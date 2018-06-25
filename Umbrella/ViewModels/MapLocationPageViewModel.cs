using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Naxam.Controls.Mapbox.Forms;
using Umbrella.Helpers;
using Xamarin.Forms;

namespace Umbrella.ViewModels
{
    public class MapLocationPageViewModel : ObservableBase
    {
        bool _isScaleBarShown = false;

        private ObservableCollection<Annotation> _annotations;

        public MapLocationPageViewModel()
        {
            DidFinishRenderingCommand = new Command((obj) =>
            {
                if (_isScaleBarShown == false && CenterLocation != null)
                {
                    _isScaleBarShown = ToggleScaleBarFunc?.Invoke(true) ?? false;
                    System.Diagnostics.Debug.WriteLine("Did toggle scale bar");
                }

            }, (arg) => true);

           
            ZoomLevel = 5.17159761572925;

        }

        private MapStyle _currentMapStyle = new MapStyle("cjbw6jtgs66xv2rpkekky39zo", "Streets", null, "winston-gubantes");

        public MapStyle CurrentMapStyle
        {
            get { return _currentMapStyle; }
            set
            {
                _currentMapStyle = value;
                OnPropertyChanged("CurrentMapStyle");
            }
        }

        private double _zoomLevel = 5.17159761572925;

        public double ZoomLevel
        {
            get { return _zoomLevel; }
            set
            {
                _zoomLevel = value;
                OnPropertyChanged("ZoomLevel");
                var scale = GetMapScaleReciprocalFunc?.Invoke();
                System.Diagnostics.Debug.WriteLine($"Zoom level: {ZoomLevel})");
                System.Diagnostics.Debug.WriteLine($"Scale: 1 : {scale}");
            }
        }

        public Action<Position, double?, double?, bool, Action> UpdateViewPortAction
        {
            get;
            set;
        }


        private ICommand _zoomCommand;

        public ICommand ZoomCommand
        {
            get
            {
                return _zoomCommand = _zoomCommand
                        ?? new Command<int>((int step) => ZoomLevel += step);
            }
            set
            {
                _zoomCommand = value;
                OnPropertyChanged("ZoomLevel");
            }
        }

        public Func<double> GetMapScaleReciprocalFunc
        {
            get; set;
        }

        private Func<bool, bool> _toggleScaleBarFunc;

        public Func<bool, bool> ToggleScaleBarFunc
        {
            get => _toggleScaleBarFunc;
            set
            {
                _toggleScaleBarFunc = value;
            }
        }

        private Position _centerLocation;

        public Position CenterLocation
        {
            get { return _centerLocation; }
            set
            {
                _centerLocation = value;
                OnPropertyChanged("CenterLocation");
            }
        }

        public ICommand DidFinishRenderingCommand { get; set; }

        public ObservableCollection<Annotation> Annotations
        {
            get { return _annotations; }
            set
            {
                _annotations = value;
                OnPropertyChanged("Annotations");
            }
        }

        public void InitializeMap()
        {
            CurrentMapStyle = new MapStyle("cjbw6jtgs66xv2rpkekky39zo", "Streets", null, "winston-gubantes");
            CenterLocation = new Position(54.401181, -3.585862);
            ZoomLevel = 4.17159761572925;
        }
    }
}
