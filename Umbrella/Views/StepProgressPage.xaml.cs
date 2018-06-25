using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Threading;

namespace Umbrella.Views
{
    public partial class StepProgressPage : ContentPage
    {
        public StepProgressPage()
        {
            InitializeComponent();
            customProgbar.Progress = 0;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
           
        }
        private void NextTapped(object sender, EventArgs args){
            if(customProgbar.Progress <= 1.0){
                customProgbar.Progress += 0.2;
                double percent = customProgbar.Progress;
                percentText.Text = (int)(percent*100) + "%";

            }
        }
        private void ClearTapped(object sender, EventArgs args)
        {
            customProgbar.Progress = 0;
            percentText.Text = "0%";
        }
    }
}
