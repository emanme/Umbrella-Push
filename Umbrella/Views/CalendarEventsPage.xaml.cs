using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Umbrella.Helpers;
using Umbrella.Interfaces;
using Umbrella.Models;
using Umbrella.Services;
using Umbrella.Utilities;
using Umbrella.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Umbrella.Views
{
    public partial class CalendarEventsPage : ContentPage
    {
        public CalendarEventsPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            ShowEventsThisWeek();
            Global.SetCalendarYearNum(0);
            Global.SetCalendarMonthNum(0);
        }
        private void  StartBusyIndicator()
        {
            BusyIndicator.IsVisible = true;
            Indicator.IsBusy = true;
              
        }

        private void StopBusyIndicator()
        {
            BusyIndicator.IsVisible = false;
            Indicator.IsBusy = false;
        }     
        private void WeekButtonTapped(object sender, EventArgs args)
        {
            ShowEventsThisWeek();
        }

        private async void MonthButtonTapped(object sender, EventArgs args)
        {
            Global.SetCalendarMonthAddNum(1);
            if (Global.GetCalendarMonthNum() == 1)
            {
                StartBusyIndicator();
                await Task.Delay(300);
            }
            ShowEventsThisMonth();
        }

        private async void YearButtonTapped(object sender, EventArgs args)
        {
            Global.SetCalendarYearAddNum(1);
            if (Global.GetCalendarYearNum() == 1)
            {
                StartBusyIndicator();
                await Task.Delay(300);
            }
            ShowEventsThisYear();
        }

        private void EventsItemTapped(object sender, ItemTappedEventArgs e)
        {
            // TODO
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

        }

        private void AddEventClicked(object sender, EventArgs e)
        {
            DependencyService.Get<ILaunchCalendar>().OpenCalendar();
        }

        private async void ViewDatesClicked(object sender, EventArgs e)
        {
            var page = new CalendarDatesPage();
            await Navigation.PushAsync(page);
        }

        private void ShowEventsThisWeek()
        {
            TabButtonManager.SelectTab(WeekTab);
            TabButtonManager.DeselectTab(MonthTab);
            TabButtonManager.DeselectTab(YearTab);
            WeekTab.Icon = "week_new_green_bg";
            MonthTab.Icon = "month_new_white_bg";
            YearTab.Icon = "year_new_white_bg";

            EventsListViewWeek.IsVisible = true;
            EventsListViewYear.IsVisible = false;
            EventsListViewMonth.IsVisible = false;
        }

        private void ShowEventsThisMonth()
        {
            var service = new CalendarEventsService();
            if (Global.GetCalendarMonthNum() == 1)
            {
                var resourcesList = service.GetCalendarApiMonth();
                Global.SetCalendarListMonth(resourcesList);
                EventsListViewMonth.ItemsSource = resourcesList;
            }
            TabButtonManager.DeselectTab(WeekTab);
            TabButtonManager.SelectTab(MonthTab);
            TabButtonManager.DeselectTab(YearTab);
            WeekTab.Icon = "week_new_white_bg";
            MonthTab.Icon = "month_new_green_bg";
            YearTab.Icon = "year_new_white_bg";
            StopBusyIndicator();
            EventsListViewWeek.IsVisible = false;
            EventsListViewYear.IsVisible = false;
            EventsListViewMonth.IsVisible = true;
        }

        private void ShowEventsThisYear()
        {
            var service = new CalendarEventsService();
            if (Global.GetCalendarYearNum() == 1)
            {
                var resourcesList = service.GetCalendarApiYear();
                Global.SetCalendarListYear(resourcesList);
                EventsListViewYear.ItemsSource = resourcesList;
            }
            TabButtonManager.DeselectTab(WeekTab);
            TabButtonManager.DeselectTab(MonthTab);
            TabButtonManager.SelectTab(YearTab);
            WeekTab.Icon = "week_new_white_bg";
            MonthTab.Icon = "month_new_white_bg";
            YearTab.Icon = "year_new_green_bg";
            StopBusyIndicator();
            EventsListViewWeek.IsVisible = false;
            EventsListViewYear.IsVisible = true;
            EventsListViewMonth.IsVisible = false;
        }

        private bool DatesAreInTheSameWeek(DateTime firstDate, DateTime secondDate)
        {
            var calendar = System.Globalization.DateTimeFormatInfo.CurrentInfo.Calendar;
            var date1sub = (int)calendar.GetDayOfWeek(firstDate) == 0 ? 1 : (int)calendar.GetDayOfWeek(firstDate);
            var date2sub = (int)calendar.GetDayOfWeek(secondDate) == 0 ? 1 : (int)calendar.GetDayOfWeek(secondDate);
            var date1 = firstDate.Date.AddDays(-1 * date1sub);
            var date2 = secondDate.Date.AddDays(-1 * date2sub);
            return date1 == date2;
        }

        private bool DatesAreInTheSameMonth(DateTime firstDate, DateTime secondDate)
        {
            var calendar = System.Globalization.DateTimeFormatInfo.CurrentInfo.Calendar;
            var date1 = firstDate.Date.Month;
            var date2 = secondDate.Date.Month;
            return date1 == date2;
        }

        private bool DatesAreInTheSameYear(DateTime firstDate, DateTime secondDate)
        {
            var calendar = System.Globalization.DateTimeFormatInfo.CurrentInfo.Calendar;
            var date1 = firstDate.Date.Year;
            var date2 = secondDate.Date.Year;
            return date1 == date2;
        }
    }
}
