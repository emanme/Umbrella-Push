using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Umbrella.Views
{
    public partial class CallTimeSchedulePage : ContentPage
    {
        private List<string> timeStrings;
        public CallTimeSchedulePage()
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

               

            };
            dateNow.Text = DateTime.Now.ToString("yyyy-MM-dd");
            var secondCount = 0;
            var lastTap = "";
            var isThereTap = false;
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) => {
                var fr = (Frame)s;
                var label = (Label)fr.Content;
                if(!isThereTap){
                    timeEntry.Text = label.Text;
                    lastTap = label.Text;
                    fr.BackgroundColor = Color.Gray;
                    isThereTap = true;
                }
                else{
                    if(label.Text == lastTap){
                        fr.BackgroundColor = Color.FromHex("#363636");
                        timeEntry.Text = "";
                        lastTap = "";
                        isThereTap = false;
                    }
                }
               
            };
            for (int i = 0; i < timeStrings.Count; i++)
            {
                string time = timeStrings[i];
                if (i <= 2)
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
                else{
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
