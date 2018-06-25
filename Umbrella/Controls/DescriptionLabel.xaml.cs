using Xamarin.Forms;

namespace Umbrella.Controls
{
    public partial class DescriptionLabel : ContentView
    {
        public string Text
        {
            get { return TextLabel.Text; }
            set { TextLabel.Text = value; }
        }

        public DescriptionLabel()
        {
            InitializeComponent();
        }
    }
}
