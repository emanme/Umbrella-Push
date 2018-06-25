using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Umbrella.Views
{
    public partial class LaterTimePage : ContentPage
    {
        private List<string> timeStrings;
        public LaterTimePage()
        {
            InitializeComponent();
            timeStrings = new List<string>()
            {
                "9:00 AM",
                "9:20 AM",
                "9:40 AM",
                "10:00 AM",
                "10:20 AM",
                "10:40 AM",


                "01:00 PM",
                "01:20 PM",
                "01:40 PM",
                "02:00 PM",
                "02:20 PM",
                "02:40 PM",

                "11:00 AM",
                "11:20 AM",
                "11:40 AM",
                "12:00 PM",
                "12:20 PM",
                "12:40 PM",


                "03:00 PM",
                "03:20 PM",
                "03:40 PM",
                "04:00 PM",
                "04:20 PM",
                "04:40 PM",

            };
            dateNow.Text = DateTime.Now.ToString("yyyy-MM-dd");
            var secondCount = 0;
            var tapCount = 0;
            var lastTap = new List<string>();
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) => {
                var fr = (Frame)s;
                if (fr.BackgroundColor == Color.FromHex("#363636"))
                {
                    tapCount += 1;
                    fr.BackgroundColor = Color.Gray;
                    var label = (Label)fr.Content;
                    timeEntry.Text = label.Text;
                    lastTap.Add(label.Text);
                }
                else
                {
                    tapCount -= 1;
                    var label = (Label)fr.Content;
                    if (tapCount == 0)
                    {
                        timeEntry.Text = "";
                        lastTap.Remove(label.Text);
                    }
                    else
                    {
                        lastTap.Remove(label.Text);
                        timeEntry.Text = lastTap.FirstOrDefault();
                    }
                    fr.BackgroundColor = Color.FromHex("#363636");
                }
            };
            for (int i = 0; i < timeStrings.Count; i++)
            {
                string time = timeStrings[i];
                if (i <= 9)
                {
                    var frame = new Frame()
                    {
                        Content = new Label()
                        {
                            Text = time,
                            HorizontalTextAlignment = TextAlignment.Center,
                            FontSize = 15,
                            TextColor = Color.White,
                            FontAttributes = FontAttributes.Bold
                        },
                        HasShadow = false,
                        CornerRadius = 17,
                        Padding = new Thickness(10),
                        BackgroundColor = Color.FromHex("#363636"),
                    };
                    frame.GestureRecognizers.Add(tapGestureRecognizer);
                    timeGrid.Children.Add(frame, 0, i);
                }
                else
                {
                    var frame = new Frame()
                    {
                        Content = new Label()
                        {
                            Text = time,
                            HorizontalTextAlignment = TextAlignment.Center,
                            FontSize = 15,
                            TextColor = Color.White,
                            FontAttributes = FontAttributes.Bold
                        },
                        HasShadow = false,
                        CornerRadius = 17,
                        Padding = new Thickness(10),
                        BackgroundColor = Color.FromHex("#363636"),
                    };
                    frame.GestureRecognizers.Add(tapGestureRecognizer);
                    timeGrid.Children.Add(frame, 1, secondCount);
                    secondCount += 1;
                }

            }
        }
    }
}
