using Xamarin.Forms;

namespace Umbrella.Controls
{
    public partial class DropdownView : ContentView
    {
        public string Label
        {
            get { return DropdownLabel.Text; }
            set { DropdownLabel.Text = value; }
        }

        public Color LabelColor
        {
            get { return DropdownLabel.TextColor; }
            set { DropdownLabel.TextColor = value; }
        }

        public DropdownView()
        {
            InitializeComponent();
        }
    }
}
