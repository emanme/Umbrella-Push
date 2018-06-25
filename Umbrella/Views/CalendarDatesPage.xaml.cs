using Syncfusion.SfCalendar.XForms;
using Umbrella.Utilities;
using Umbrella.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Umbrella.Views
{
    public partial class CalendarDatesPage : ContentPage
    {
        public CalendarDatesPage()
        {
            InitializeComponent();

            Color primaryColor = (Color) Application.Current.Resources["PrimaryColor"];
            Color mainWhiteColor = (Color) Application.Current.Resources["MainWhiteColor"];
            Color mainBlackColor = (Color) Application.Current.Resources["MainBlackColor"];
            Color mainGrayColor = (Color) Application.Current.Resources["MainGrayColor"];

            MonthLabelSettings labelSettings = new MonthLabelSettings();
            labelSettings.DayFormat = "EEE";
            labelSettings.DayLabelSize = 20;
            labelSettings.DateFormat = "dd";
            labelSettings.DateLabelSize = 20;
            MonthViewSettings monthViewSettings = new MonthViewSettings();
            monthViewSettings.HeaderTextColor = mainBlackColor;
            monthViewSettings.HeaderBackgroundColor = mainGrayColor;
            monthViewSettings.DayHeaderTextColor = mainBlackColor;
            monthViewSettings.DayHeaderBackgroundColor = mainWhiteColor;
            monthViewSettings.PreviousMonthBackgroundColor = mainBlackColor;
            monthViewSettings.TodayTextColor = primaryColor;
            monthViewSettings.DateSelectionColor = primaryColor;
            monthViewSettings.SelectedDayTextColor = mainWhiteColor;
            monthViewSettings.CurrentMonthTextColor = mainWhiteColor;
            monthViewSettings.CurrentMonthBackgroundColor = mainBlackColor;
            monthViewSettings.WeekEndTextColor = mainWhiteColor;
            monthViewSettings.InlineTextColor = mainWhiteColor;
            monthViewSettings.InlineBackgroundColor = primaryColor;
            monthViewSettings.MonthLabelSettings = labelSettings;
            Calendar.MonthViewSettings = monthViewSettings;

            PopulateCalendar();
        }

        private void PopulateCalendar()
        {
            Color mainYellowColor = (Color) Application.Current.Resources["MainYellowColor"];
            var eventList = new CalendarEventCollection();
            // var source = ((CalendarEventsViewModel) BindingContext).CalendarEvents;
            var source = Global.GetCalendarWeek();
            foreach (var item in source)
            {
                var inlineEvent = new CalendarInlineEvent();
                inlineEvent.Subject = item.Subject;
                inlineEvent.StartTime = item.StartEventDateTime;
                inlineEvent.EndTime = item.EndEventDateTime;
                inlineEvent.Color = mainYellowColor;
                eventList.Add(inlineEvent);
            }
            var sourceM = Global.GetCalendarMonth();
            foreach (var item in sourceM)
            {
                var inlineEvent = new CalendarInlineEvent();
                inlineEvent.Subject = item.Subject;
                inlineEvent.StartTime = item.StartEventDateTime;
                inlineEvent.EndTime = item.EndEventDateTime;
                inlineEvent.Color = mainYellowColor;
                eventList.Add(inlineEvent);
            }
            var sourceY = Global.GetCalendarYear();
            foreach (var item in sourceY)
            {
                var inlineEvent = new CalendarInlineEvent();
                inlineEvent.Subject = item.Subject;
                inlineEvent.StartTime = item.StartEventDateTime;
                inlineEvent.EndTime = item.EndEventDateTime;
                inlineEvent.Color = mainYellowColor;
                eventList.Add(inlineEvent);
            }
            Calendar.DataSource = eventList;
        }
    }
}
