using System;
using Umbrella.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Umbrella.Services;
using Umbrella.Interfaces;
using Plugin.Connectivity;

namespace Umbrella.Views
{
    public partial class AppointmentsPage : ContentPage
    {
        private AppointmentStoreUpdate _appointModel;
        private AppointmentsService _appointService;
        public AppointmentsPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            _appointService = new AppointmentsService();
            _appointModel = _appointService.GetCallbackHours();
            CrossConnectivity.Current.ConnectivityChanged += (sender, args) =>
            {
                UpdateBtn.IsEnableButton = args.IsConnected ? true : false;
            };

            TimePicker11.Time = ConvertStringToTimespan(_appointModel.Mon_From);
            TimePicker12.Time = ConvertStringToTimespan(_appointModel.Mon_Till);
            TimePicker21.Time = ConvertStringToTimespan(_appointModel.Tue_From);
            TimePicker22.Time = ConvertStringToTimespan(_appointModel.Tue_Till);
            TimePicker31.Time = ConvertStringToTimespan(_appointModel.Wen_From);
            TimePicker32.Time = ConvertStringToTimespan(_appointModel.Wen_Till);
            TimePicker41.Time = ConvertStringToTimespan(_appointModel.Thur_From);
            TimePicker42.Time = ConvertStringToTimespan(_appointModel.Thur_Till);
            TimePicker51.Time = ConvertStringToTimespan(_appointModel.Fri_From);
            TimePicker52.Time = ConvertStringToTimespan(_appointModel.Fri_Till);
            TimePicker61.Time = ConvertStringToTimespan(_appointModel.Sat_From);
            TimePicker62.Time = ConvertStringToTimespan(_appointModel.Sat_Till);
            TimePicker71.Time = ConvertStringToTimespan(_appointModel.Sun_From);
            TimePicker72.Time = ConvertStringToTimespan(_appointModel.Sun_Till);

            //set min and max time
            TimePicker11.MinimumTime = new TimeSpan(8, 0, 0);
            TimePicker11.MaximumTime = new TimeSpan(22, 0, 0);
            TimePicker12.MinimumTime = new TimeSpan(8, 0, 0);
            TimePicker12.MaximumTime = new TimeSpan(22, 0, 0);
            TimePicker21.MinimumTime = new TimeSpan(8, 0, 0);
            TimePicker21.MaximumTime = new TimeSpan(22, 0, 0);
            TimePicker22.MinimumTime = new TimeSpan(8, 0, 0);
            TimePicker22.MaximumTime = new TimeSpan(22, 0, 0);
            TimePicker31.MinimumTime = new TimeSpan(8, 0, 0);
            TimePicker31.MaximumTime = new TimeSpan(22, 0, 0);
            TimePicker32.MinimumTime = new TimeSpan(8, 0, 0);
            TimePicker32.MaximumTime = new TimeSpan(22, 0, 0);
            TimePicker41.MinimumTime = new TimeSpan(8, 0, 0);
            TimePicker41.MaximumTime = new TimeSpan(22, 0, 0);
            TimePicker42.MinimumTime = new TimeSpan(8, 0, 0);
            TimePicker42.MaximumTime = new TimeSpan(22, 0, 0);
            TimePicker51.MinimumTime = new TimeSpan(8, 0, 0);
            TimePicker51.MaximumTime = new TimeSpan(22, 0, 0);
            TimePicker52.MinimumTime = new TimeSpan(8, 0, 0);
            TimePicker52.MaximumTime = new TimeSpan(22, 0, 0);
            TimePicker61.MinimumTime = new TimeSpan(8, 0, 0);
            TimePicker61.MaximumTime = new TimeSpan(22, 0, 0);
            TimePicker62.MinimumTime = new TimeSpan(8, 0, 0);
            TimePicker62.MaximumTime = new TimeSpan(22, 0, 0);
            TimePicker71.MinimumTime = new TimeSpan(8, 0, 0);
            TimePicker71.MaximumTime = new TimeSpan(22, 0, 0);
            TimePicker72.MinimumTime = new TimeSpan(8, 0, 0);
            TimePicker72.MaximumTime = new TimeSpan(22, 0, 0);
            try
            {
                MonSwitch.IsToggled = _appointModel.LabelClose1 == "yes" ? true : false;
                TueSwitch.IsToggled = _appointModel.LabelClose2 == "yes" ? true : false;
                WedSwitch.IsToggled = _appointModel.LabelClose3 == "yes" ? true : false;
                ThuSwitch.IsToggled = _appointModel.LabelClose4 == "yes" ? true : false;
                FriSwitch.IsToggled = _appointModel.LabelClose5 == "yes" ? true : false;
                SatSwitch.IsToggled = _appointModel.LabelClose6 == "yes" ? true : false;
                SunSwitch.IsToggled = _appointModel.LabelClose7 == "yes" ? true : false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ex " + ex.InnerException + " " + ex.Message);
            }
        }
        private TimeSpan ConvertStringToTimespan(string timeString)
        {
            string[] time = timeString.Split(':');
            int hour = Int32.Parse(time[0]);
            int min = Int32.Parse(time[1]);

            return new TimeSpan(hour, min, 0);
        }
        private void SwitchToggled(object sender, ToggledEventArgs e)
        {
            var switchButton = (Switch) sender;
            if (switchButton == MonSwitch)
            {
                ToggleClose(switchButton, 1);
            }
            else if (switchButton == TueSwitch)
            {
                ToggleClose(switchButton, 2);
            }
            else if (switchButton == WedSwitch)
            {
                ToggleClose(switchButton, 3);
            }
            else if (switchButton == ThuSwitch)
            {
                ToggleClose(switchButton, 4);
            }
            else if (switchButton == FriSwitch)
            {
                ToggleClose(switchButton, 5);
            }
            else if (switchButton == SatSwitch)
            {
                ToggleClose(switchButton, 6);
            }
            else if (switchButton == SunSwitch)
            {
                ToggleClose(switchButton, 7);
            }
        }

        protected async void UpdateOpeningHoursClicked(object sender, EventArgs args)
        {
            var Mon_From = TimePicker11.Time.ToString();
            var Mon_Till = TimePicker12.Time.ToString();

            var Tue_From = TimePicker21.Time.ToString();
            var Tue_Till = TimePicker22.Time.ToString();

            var Wen_From = TimePicker31.Time.ToString();
            var Wen_Till = TimePicker32.Time.ToString();

            var Thur_From = TimePicker41.Time.ToString();
            var Thur_Till = TimePicker42.Time.ToString();

            var Fri_From = TimePicker51.Time.ToString();
            var Fri_Till = TimePicker52.Time.ToString();

            var Sat_From = TimePicker61.Time.ToString();
            var Sat_Till = TimePicker62.Time.ToString();

            var Sun_From = TimePicker71.Time.ToString();
            var Sun_Till = TimePicker72.Time.ToString();
            //
            Appointment ap = new Appointment();
            if(!Mon_From.Contains("00:00:00") && !Mon_Till.Contains("00:00:00")) 
            {
                ap.open_from = Mon_From;
                ap.open_to = Mon_Till;                
            }
            else 
            {
                if(Label1.IsVisible)
                {

                }
            }
            if (!Tue_From.Contains("00:00:00") && !Tue_Till.Contains("00:00:00"))
            {
                ap.open_from = Tue_From;
                ap.open_to = Tue_Till;
            }
            else
            {
                if (Label2.IsVisible)
                {

                }
            }
            if (!Wen_From.Contains("00:00:00") && !Wen_Till.Contains("00:00:00"))
            {
                ap.open_from = Wen_From;
                ap.open_to = Wen_Till;
            }
            else
            {
                if (Label3.IsVisible)
                {

                }
            }
            if (!Thur_From.Contains("00:00:00") && !Thur_Till.Contains("00:00:00"))
            {
                ap.open_from = Thur_From;
                ap.open_to = Thur_Till;
            }
            else
            {
                if (Label4.IsVisible)
                {

                }
            }
            if (!Fri_From.Contains("00:00:00") && !Fri_Till.Contains("00:00:00"))
            {
                ap.open_from = Fri_From;
                ap.open_to = Fri_Till;
            }
            else
            {
                if (Label5.IsVisible)
                {

                }
            }
            if (!Sat_From.Contains("00:00:00") && !Sat_Till.Contains("00:00:00"))
            {
                ap.open_from = Sat_From;
                ap.open_to = Sat_Till;
            }
            else
            {
                if (Label6.IsVisible)
                {

                }
            }
            if (!Sun_From.Contains("00:00:00") && !Sun_Till.Contains("00:00:00"))
            {
                ap.open_from = Sun_From;
                ap.open_to = Sun_Till;
            }
            else
            {
                if (Label7.IsVisible)
                {

                }
            }
            var credential = DependencyService.Get<ICredentialRetriever>().GetCredential();
            ap.user_id = credential.User.Id;
            
            AppointmentsService.SaveAppointment(ap);
            var page = new AppointmentsPage();            
            await Navigation.PushAsync(page);
        }
        private void ToggleClose(Switch switchButton, int row)
        {
            if (switchButton.IsToggled)
            {
                this.FindByName<TimePicker>("TimePicker" + row + "1").IsVisible = false;
                this.FindByName<TimePicker>("TimePicker" + row + "2").IsVisible = false;
                this.FindByName<Label>("Label" + row).IsVisible = true;
            }
            else
            {
                this.FindByName<Label>("Label" + row).IsVisible = false;
                this.FindByName<TimePicker>("TimePicker" + row + "1").IsVisible = true;
                this.FindByName<TimePicker>("TimePicker" + row + "2").IsVisible = true;
            }
        }
    }
}
