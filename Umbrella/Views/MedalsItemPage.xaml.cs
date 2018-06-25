using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbrella.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Umbrella.Views
{
    public partial class MedalsItemPage : ContentPage
    {
        private Medal _medal;
        public MedalsItemPage(Medal medal)
        {
            InitializeComponent();
            _medal = medal;
            this.BindingContext = _medal;
            var source = new HtmlWebViewSource();
            string text = "<p align='justify' style='font-size:16px;font-family:Arial'>" + _medal.Description + "</p>";
            source.Html = text;
            HtmlWebView.Source = source;
        }
    }
}
