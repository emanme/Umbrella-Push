using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace Umbrella.Controls
{
    public delegate void TimeSelectedEventHandler(object sender, PropertyChangedEventArgs args);

    public partial class CustomTimePicker : ContentView
    {
        public TimeSpan Time
        {
            get { return TimePicker.Time; }
            set { TimePicker.Time = value; }
        }

        public string Format
        {
            get { return TimePicker.Format; }
            set { TimePicker.Format = value; }
        }

        public Color TextColor
        {
            get { return TimePicker.TextColor; }
            set { TimePicker.TextColor = value; }
        }

        public Color Color
        {
            get { return TimePicker.BackgroundColor; }
            set { TimePicker.BackgroundColor = value; }
        }

        public event TimeSelectedEventHandler TimeSelected;

        public CustomTimePicker()
        {
            InitializeComponent();
        }

        private void TimePickerTimeSelected(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == TimePicker.TimeProperty.PropertyName)
            {
                TimeSelected?.Invoke(sender, args);
            }
        }
    }
}
