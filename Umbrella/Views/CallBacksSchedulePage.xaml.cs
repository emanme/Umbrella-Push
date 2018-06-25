using System;
using System.ComponentModel;
using Umbrella.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Umbrella.Interfaces;
 

namespace Umbrella.Views
{
    public partial class CallBacksSchedulePage : ContentPage
    {
        private string[] SelectionArray = { "Mobile", "Home", "Office", "Other" };

        private Lead _lead;
        private CallBack _callBack;

        public CallBacksSchedulePage(Lead lead)
        {
            InitializeComponent();
            Title = "Schedule Call Back";

            _lead = lead;
            BindingContext = lead;

            UpdateSummaryText(false);
        }

        public CallBacksSchedulePage(CallBack callBack)
        {
            InitializeComponent();
            Title = "Rechedule Call Back";

            _callBack = callBack;
            BindingContext = callBack;

            ScheduleHeaderLayout.IsVisible = false;
            RescheduleHeaderLayout.IsVisible = true;
            ScheduleFooterLayout.IsVisible = false;
            RescheduleFooterLayout.IsVisible = true;
            DateLabel.Text = "New Date";
            TimeLabel.Text = "New Time";

            DatePicker.Date = callBack.ScheduledDateTime;
            TimePicker.Time = callBack.ScheduledDateTime.TimeOfDay;

            UpdateSummaryText(false);
        }

        private void DatePickerDateSelected(object sender, DateChangedEventArgs e)
        {
            UpdateSummaryText(true);
        }

        private void TimePickerTimeSelected(object sender, PropertyChangedEventArgs e)
        {
            UpdateSummaryText(true);
        }

        private async void DropdownTapped(object sender, EventArgs e)
        {
            var action = await DisplayActionSheet(Dropdown.Label, "Cancel", null, SelectionArray);
            if (!action.Equals("Cancel"))
            {
                Dropdown.Label = action;
                Dropdown.LabelColor = (Color) Application.Current.Resources["PrimaryTextColor"];

                if (!action.Equals("Other"))
                {
                    NumbersEntry.IsEnabled = false;
                    if (action.Equals("Mobile"))
                    {
                        NumbersEntry.Text = _lead.Mobile;
                    }
                    else if (action.Equals("Home"))
                    {
                        NumbersEntry.Text = _lead.Home;
                    }
                    else if (action.Equals("Office"))
                    {
                        NumbersEntry.Text = _lead.Office;
                    }
                }
                else
                {
                    NumbersEntry.IsEnabled = true;
                    NumbersEntry.Text = "";
                }
                UpdateSummaryText(true);
            }
        }

        private void NumbersEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateSummaryText(true);
        }

        private async void BookCallBackNowClicked(object sender, EventArgs e)
        {
            var page = new CallBacksSchedulePage(_lead);
            await Navigation.PushAsync(page);
        }

        private async void NewAppointmentClicked(object sender, EventArgs e)
        {
            var newTime = TimePicker.Time;
            var newdate = DatePicker.Date;
            App.Current.Properties.Add("AppointmentDate", newdate);
            App.Current.Properties.Add("AppointmentTime", newTime);
            await App.Current.SavePropertiesAsync();            
            var page = new AppointmentsPage();
            await Navigation.PushAsync(page);
        }    
        private void UpdateSummaryText(bool IsChanged)
        {                             
            DateTime dateSelected = DatePicker.Date;
            TimeSpan timeSelected = TimePicker.Time;
            DateTime dateTimeValue = new DateTime().Add(timeSelected);
            if (!IsChanged)
            {
                if (App.Current.Properties.ContainsKey("AppointmentDate"))
                {
                    dateSelected = Convert.ToDateTime(App.Current.Properties["AppointmentDate"]);
                    DatePicker.Date = dateSelected;
                }
                if (App.Current.Properties.ContainsKey("AppointmentTime"))
                {
                    timeSelected = TimeSpan.Parse(App.Current.Properties["AppointmentTime"].ToString());
                    TimePicker.Time = timeSelected;
                    dateTimeValue = new DateTime().Add(timeSelected);
                }
            }          
            string dateString = string.Format("{0:ddd d MMM}", dateSelected).ToUpper();
            string timeString = string.Format("{0:h:mm tt}", dateTimeValue).ToUpper();
            if (_lead != null)
            {
                string numberString = NumbersEntry.Text;
                ScheduleSummaryText.Text = $"{timeString} on {dateString} on: {numberString}";
            }
            if (_callBack != null)
            {
                RescheduleSummaryText.Text = $"{timeString} on {dateString}";
            }
        }
    }
}
