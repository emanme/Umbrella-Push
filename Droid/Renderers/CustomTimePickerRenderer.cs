﻿using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Umbrella.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Xamarin.Forms.TimePicker), typeof(CustomTimePickerRenderer))]
namespace Umbrella.Droid
{
    public class CustomTimePickerRenderer : TimePickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.TimePicker> e)
        {
            base.OnElementChanged(e);
            TimePickerDialogIntervals timePickerDlg = new TimePickerDialogIntervals(
                Context, new EventHandler<TimePickerDialogIntervals.TimeSetEventArgs>(UpdateDuration),
                Element.Time.Hours, Element.Time.Minutes, false);

            var control = new EditText(Context);
            control.Focusable = false;
            control.FocusableInTouchMode = false;
            control.Clickable = false;
            control.Click += (sender, ea) => timePickerDlg.Show();
            control.Text = Element.Time.Hours.ToString("00") + ":" + Element.Time.Minutes.ToString("00");

            SetNativeControl(control);
        }

        private void UpdateDuration(object sender, TimePickerDialog.TimeSetEventArgs e)
        {
            Element.Time = new TimeSpan(e.HourOfDay, e.Minute, 0);
            Control.Text = Element.Time.Hours.ToString("00") + ":" + Element.Time.Minutes.ToString("00");
        }
    }

    public class TimePickerDialogIntervals : TimePickerDialog
    {
        public const int TimePickerInterval = 15;

        public TimePickerDialogIntervals(Context context, EventHandler<TimeSetEventArgs> callBack, int hourOfDay, int minute, bool is24HourView)
            : base(context, (sender, e) =>
        {
            callBack(sender, new TimeSetEventArgs(e.HourOfDay, (e.Minute % 4) * TimePickerInterval));
        }, hourOfDay, minute / TimePickerInterval, is24HourView)
        {
        }

        protected TimePickerDialogIntervals(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public override void SetView(Android.Views.View view)
        {
            SetupMinutePicker(view);
            base.SetView(view);
        }

        void SetupMinutePicker(Android.Views.View view)
        {
            var numberPicker = FindMinuteNumberPicker(view as ViewGroup);
            if (numberPicker != null)
            {
                numberPicker.MinValue = 0;
                numberPicker.MaxValue = 7;
                numberPicker.SetDisplayedValues(new string[] { "00", "15", "30", "45", "00", "15", "30", "45" });
            }
        }

        protected override void OnCreate(Android.OS.Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            GetButton((int)DialogButtonType.Negative).Visibility = ViewStates.Gone;
            SetCanceledOnTouchOutside(false);
        }

        private NumberPicker FindMinuteNumberPicker(ViewGroup viewGroup)
        {
            for (var i = 0; i < viewGroup.ChildCount; i++)
            {
                var child = viewGroup.GetChildAt(i);
                var numberPicker = child as NumberPicker;
                if (numberPicker != null)
                {
                    if (numberPicker.MaxValue == 59)
                    {
                        return numberPicker;
                    }
                }

                var childViewGroup = child as ViewGroup;
                if (childViewGroup != null)
                {
                    var childResult = FindMinuteNumberPicker(childViewGroup);
                    if (childResult != null)
                    {
                        return childResult;
                    }
                }
            }
            return null;
        }
    }
}
