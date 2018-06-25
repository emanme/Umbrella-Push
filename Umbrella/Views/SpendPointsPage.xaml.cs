using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Umbrella.Helpers;
using Umbrella.Interfaces;
using Umbrella.Models;
using Umbrella.Utilities;
using Xamarin.Forms;
using Plugin.Vibrate;
using Umbrella.ViewModels;
using System.Linq;

namespace Umbrella.Views
{
    public partial class SpendPointsPage : ContentPage
    {
        public SpendPointsPage(Message msg)
        {
            InitializeComponent();
            HandleTimer();
            this.BindingContext = msg;
            fingerPrintPage.RaiseChild(imageFingerPrint);
            var ver = DependencyService.Get<IDeviceChecker>().GetDeviceVersion();
            System.Diagnostics.Debug.WriteLine("ver" + ver);
            if(ver == 5){
                stack2.Padding = new Thickness(20, 35, 30, 30);
                stack.Padding = new Thickness(30, 5, 33, 30);
                subimageFingeprint.WidthRequest = 315;
                reqThumb.WidthRequest = 112.17213;
                imageFingerPrint.WidthRequest = 204.20;
                imageFingerPrint.Margin = new Thickness(0, 0, 25, 0);
            }
            else if(ver == 6){
                stack2.Padding = new Thickness(50, 35, 30, 30);
                stack.Padding = new Thickness(30, 5, 33, 30);
                subimageFingeprint.WidthRequest = 372;
                reqThumb.WidthRequest = 132;
                imageFingerPrint.WidthRequest = 242;
            }
            else if (ver == 61)
            {
                stack2.Padding = new Thickness(50, 35, 30, 30);
                stack.Padding = new Thickness(30, 5, 33, 30);
                subimageFingeprint.WidthRequest = 413;
                reqThumb.WidthRequest = 148;
                imageFingerPrint.WidthRequest = 270;
            }
            stack.Opacity = 0;
            stack2.Opacity = 0;
        }
        void HandleTimer()
        {
            MessagingCenter.Subscribe<TickedListMessages>(this, "TickedListMessages", message => {
                Device.BeginInvokeOnMainThread(() => {
                    timeText.Text = message.Message;
                });
            });
                
            MessagingCenter.Subscribe<CancelledMessage>(this, "CancelledMessage", message => {
                Device.BeginInvokeOnMainThread(async ()  => {
                    try{    
                        var image = new FFImageLoading.Forms.CachedImage();
                        image.Source = "explosion";
                        image.Aspect = Aspect.Fill;
                        image.HorizontalOptions = LayoutOptions.FillAndExpand;
                        image.VerticalOptions = LayoutOptions.FillAndExpand;
                        if(Global.GetNum() == 1){
                            stackExplosion.Children.Add(image);
                            timeText.Text = "0";

                        }
                        else{
                            await Task.Delay(850);
                            stackExplosion.Children.Add(image);
                            timeText.Text = "0";
                        }
                        if (Global.GetNum() == 1)
                        {
                            await Task.Delay(800);
                        }
                        stack.IsVisible = false;
                        stack2.IsVisible = false;
                        messg.IsVisible = false;
                        var v = CrossVibrate.Current;
                        var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
                        player.Load("iphone_mp3.mp3");
                        player.Play();
                        v.Vibration();
                        await Task.Delay(2000);
                        player.Stop();
                        await Navigation.PopAsync();
                       

                    }
                    catch(Exception ex){
                        System.Diagnostics.Debug.WriteLine("Pop Modal " + ex.Message);
                    }
                });
            });
          
        }
        private async void CloseModal()
        {
            await Navigation.PopModalAsync();
        }
        private async void FadeFingerPrint(){
            stack.Opacity = 1;
            stack2.Opacity = 1;
            await fingerPrintPage.FadeTo(0, 200);
            var list = Global.GetTopUnreadTest();
            list.FirstOrDefault().Read = true;
            Global.SetTopUnreadTest(list);
            var message = new StartCustomerMessage();
            MessagingCenter.Send(message, "StartCustomerMessage");
        }
        protected override void OnAppearing(){
            base.OnAppearing();
        }
        private async void TapGestureRecognizer_Tapped(object sender, PointEventArgs e){
            if(fingerPrintPage.Children.Contains(imageFingerPrint)){
                fingerPrintPage.Children.Remove(imageFingerPrint);
                fingerPrintPage.Children.Remove(reqThumb);
                var ver = DependencyService.Get<IDeviceChecker>().GetDeviceVersion();
                subImage.IsVisible = true;
                var image = new FFImageLoading.Forms.CachedImage();
                image.Source = "fingerprint";
                if(ver == 5){
                    image.HeightRequest = 162;
                    image.WidthRequest = 315;
                }
                else if(ver == 6){
                    image.HeightRequest = 162;
                    image.WidthRequest = 372;
                }
                else if (ver == 61)
                {
                    image.HeightRequest = 162;
                    image.WidthRequest = 413;
                }
                image.Aspect = Aspect.AspectFit;
                fingerPrintPage.Children.Add(image);
                await Task.Delay(6000);
                subImage.IsVisible = false;
                await Task.Run(new Action(() => FadeFingerPrint()));
            }
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
           
        }
    }
}
