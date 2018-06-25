using System;
using Xamarin.Forms;

namespace Umbrella.Controls
{
    public delegate void DateSelectedEventHandler(object sender, DateChangedEventArgs args);

    public partial class CustomDatePicker : ContentView
    {
        public DateTime Date
        {
            get { return DatePicker.Date; }
            set { DatePicker.Date = value; }
        }

        public string Format
        {
            get { return DatePicker.Format; }
            set { DatePicker.Format = value; }
        }

        public Color TextColor
        {
            get { return DatePicker.TextColor; }
            set { DatePicker.TextColor = value; }
        }

        public Color Color
        {
            get { return DatePicker.BackgroundColor; }
            set { DatePicker.BackgroundColor = value; }
        }

        public event DateSelectedEventHandler DateSelected;

        public CustomDatePicker()
        {
            InitializeComponent();
        }

        private void DatePickerDateSelected(object sender, DateChangedEventArgs args)
        {
            DateSelected?.Invoke(sender, args);
        }
    }
}
