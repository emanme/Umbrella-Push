using System;
using Umbrella.Controls;
using Xamarin.Forms;

namespace Umbrella.Helpers
{
    public class SegmentedTabManager
    {
        private const string NormalColorString = "PrimaryColor";
        private const string SelectedColorString = "MainWhiteColor";
        public SegmentedTabManager()
        {
        }
        public static void SelectTab(SegmentedTab tabButton)
        {
            Color normalColor = (Color)Application.Current.Resources[NormalColorString];
            Color selectedColor = (Color)Application.Current.Resources[SelectedColorString];

            tabButton.Color = Color.White;
            tabButton.BorderColor = Color.White;
            tabButton.LabelColor = normalColor;
        }

        public static void SelectTab(Label tabLabel)
        {
            Color normalColor = (Color)Application.Current.Resources[NormalColorString];
            Color selectedColor = (Color)Application.Current.Resources[SelectedColorString];

            tabLabel.BackgroundColor = selectedColor;
            tabLabel.TextColor = normalColor;
        }

        public static void DeselectTab(SegmentedTab tabButton)
        {
            Color normalColor = (Color)Application.Current.Resources[NormalColorString];
            Color selectedColor = (Color)Application.Current.Resources[SelectedColorString];

            tabButton.Color = normalColor;
            tabButton.BorderColor = Color.White;
            tabButton.LabelColor = selectedColor;
        }

        public static void DeselectTab(Label tabLabel)
        {
            Color normalColor = (Color)Application.Current.Resources[NormalColorString];
            Color selectedColor = (Color)Application.Current.Resources[SelectedColorString];

            tabLabel.BackgroundColor = normalColor;
            tabLabel.TextColor = selectedColor;
        }
    }
}
