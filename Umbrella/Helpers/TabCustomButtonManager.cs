using System;
using Umbrella.Controls;
using Xamarin.Forms;

namespace Umbrella.Helpers
{
    public class TabCustomButtonManager
    {

        private const string NormalColorString = "PrimaryColor";
        private const string SelectedColorString = "MainWhiteColor";

        public static void SelectTab(TabCustomButton tabButton)
        {
            Color normalColor = (Color)Application.Current.Resources[NormalColorString];
            Color selectedColor = (Color)Application.Current.Resources[SelectedColorString];

            tabButton.Color = selectedColor;
            tabButton.BorderColor = Color.Black;
            tabButton.LabelColor = normalColor;
        }

        public static void SelectTab(Label tabLabel)
        {
            Color normalColor = (Color)Application.Current.Resources[NormalColorString];
            Color selectedColor = (Color)Application.Current.Resources[SelectedColorString];

            tabLabel.BackgroundColor = selectedColor;
            tabLabel.TextColor = normalColor;
        }

        public static void DeselectTab(TabCustomButton tabButton)
        {
            Color normalColor = (Color)Application.Current.Resources[NormalColorString];
            Color selectedColor = (Color)Application.Current.Resources[SelectedColorString];

            tabButton.Color = normalColor;
            tabButton.BorderColor = normalColor;
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
