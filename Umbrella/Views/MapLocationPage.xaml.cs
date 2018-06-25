using Naxam.Controls.Mapbox.Forms;
using Plugin.Badge;
using System.Linq;
using Umbrella.Models;
using Umbrella.Utilities;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using Umbrella.ViewModels;
using Umbrella.Services;
using System.Collections.Generic;
using System;
using Umbrella.Helpers;

namespace Umbrella.Views
{
    public partial class MapLocationPage : ContentPage
    {
        private MapLocationService _mapService;
        private ObservableCollection<Annotation> _annotationsComrades;
        private ObservableCollection<Annotation> _annotationRecruits;
        private List<MapLocation> _mapListRecruits;
        private List<MapLocation> _mapListComrades;
        private string _currentTabString = "Recruits";
        private string _mapType = "";
        public MapLocationPage()
        {
            InitializeComponent();
            HandleReceivedMessages();
            _mapType = "Recruits";
            _mapService = new MapLocationService();
            map.Center = new Position(54.936310, -4.621107);
            map.ZoomLevel = 4.1;
            _annotationRecruits = new ObservableCollection<Annotation>();
            _annotationsComrades = new ObservableCollection<Annotation>();
            _mapListRecruits = _mapService.GetMapRecruits();
            _mapListComrades = _mapService.GetMapComrades();
           
        }
        public MapLocationPage(string mapType)
        {
            InitializeComponent();
            _mapService = new MapLocationService();
            map.Center = new Position(54.936310, -4.621107);
            HandleReceivedMessages();
            _annotationRecruits = new ObservableCollection<Annotation>();
            _annotationsComrades = new ObservableCollection<Annotation>();
            _mapListRecruits = _mapService.GetMapRecruits();
            _mapListComrades = _mapService.GetMapComrades();
            if (mapType.Equals("Recruits"))
            {
                _mapType = mapType;
                ShowRecruitsTab();
            }
            else if(mapType.Equals("Comrades"))
            {
                _mapType = mapType;
                ShowsComradesTab();
               
            }
          
        }
        private void ShowRecruitsTabTapped(object sender, EventArgs args)
        {
            ShowRecruitsTab();
        }
        private void ShowComradesTabTapped(object sender, EventArgs args)
        {
            ShowsComradesTab();
        }
        private void ShowAlliesTabTapped(object sender, EventArgs args)
        {
            ShowAlliesTab();
        }
        private void ShowRecruitsTab()
        {
            SegmentedTabManager.SelectTab(RecruitTab);
            SegmentedTabManager.DeselectTab(ComradesTab);
            SegmentedTabManager.DeselectTab(AlliesTab);
            _currentTabString = "Recruits";
            if (map.ZoomLevel != 4.1)
            {
                map.ZoomLevel = 4.1;
                map.Center = new Position(54.936310, -4.621107);
            }
            _annotationRecruits = new ObservableCollection<Annotation>();
            foreach (var item in _mapListRecruits)
            {
                if (!string.IsNullOrEmpty(item.Longitude) || !string.IsNullOrEmpty(item.Latitude))
                {
                    var point = new PointAnnotation()
                    {

                        Coordinate = new Position(Double.Parse(item.Latitude), Double.Parse(item.Longitude)),
                        Title = item.Fullname,
                        Color = item.Color,
                        MapType = item.Type
                    };
                    _annotationRecruits.Add(point);

                }
            }
            map.Annotations = _annotationRecruits;
        }
        private void ShowsComradesTab()
        {
            SegmentedTabManager.DeselectTab(RecruitTab);
            SegmentedTabManager.SelectTab(ComradesTab);
            SegmentedTabManager.DeselectTab(AlliesTab);
            _currentTabString = "Comrades";
            if (map.ZoomLevel != 4.1)
            {
                map.ZoomLevel = 4.1;
                map.Center = new Position(54.936310, -4.621107);
            }
            _annotationsComrades = new ObservableCollection<Annotation>();
            foreach (var item in _mapListComrades)
            {
                if (!string.IsNullOrEmpty(item.Longitude) || !string.IsNullOrEmpty(item.Latitude))
                {
                    var point = new PointAnnotation()
                    {

                        Coordinate = new Position(Double.Parse(item.Latitude), Double.Parse(item.Longitude)),
                        Title = item.Fullname,
                        Color = item.Color,
                        MapType = item.Type
                    };
                    _annotationsComrades.Add(point);
                }
            }
            map.Annotations = _annotationsComrades;
        }
        private void ShowAlliesTab()
        {
            SegmentedTabManager.DeselectTab(RecruitTab);
            SegmentedTabManager.DeselectTab(ComradesTab);
            SegmentedTabManager.SelectTab(AlliesTab);
            _currentTabString = "Allies";
            if (map.ZoomLevel != 4.1)
            {
                map.ZoomLevel = 4.1;
                map.Center = new Position(54.936310, -4.621107);
            }
            map.Annotations = new ObservableCollection<Annotation>();
        }
        void HandleReceivedMessages()
        {
            MessagingCenter.Subscribe<TickedMessages>(this, "TickedMessages", message => {
                Device.BeginInvokeOnMainThread(() => {
                    MapFooter.BadgeVisibility = 1;
                    var notifList = Global.GetAllTopic();
                    var currentMessageCount = notifList.Where(e => e.Value == "new_message").Count();
                    MapFooter.BadgeCountMessage = currentMessageCount.ToString();
                });
            });
        }
        private async void MapKeyClicked(object sender, EventArgs e){

            if(_currentTabString == "Recruits"){
                await Navigation.PushAsync(new RecruitMapKeyPage());
            }
            else if(_currentTabString == "Comrades"){
                await Navigation.PushAsync(new ComradesMapKeyPage());
            }
            else{
                await Navigation.PushAsync(new AlliesMapKeyPage());
            }

        }
      
        protected override void OnAppearing()
        {
            base.OnAppearing();
            Global.SetNotifBadge(Global.GetNotifCount());
            CrossBadge.Current.SetBadge(Global.GetNotifCount());
            if(_mapType == "Recruits"){
                ShowRecruitsTab();
            }
            else{
                ShowsComradesTab();
            }
            var notifList = Global.GetAllTopic();
            var currentMessageCount = notifList.Where(e => e.Value == "new_message").Count();

            if (currentMessageCount <= 0)
            {
                MapFooter.BadgeVisibility = 0;
            }
            else
            {
                MapFooter.BadgeVisibility = 1;
                MapFooter.BadgeCountMessage = currentMessageCount.ToString();
            }
            map.MapStyle = new MapStyle("cjbw6jtgs66xv2rpkekky39zo", "Streets", null, "winston-gubantes");
            map.ZoomLevel = 4.1;
        }
      
    }
}