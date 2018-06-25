using Xamarin.Forms;

namespace Umbrella.Controls
{
    public partial class MultilineLabel : Label
    {
        private static int _defaultLineSetting = -1;

        public static readonly BindableProperty LinesProperty =
            BindableProperty.Create(nameof(Lines), typeof(int),
                typeof(MultilineLabel), _defaultLineSetting);
        public int Lines
        {
            get { return (int) GetValue(LinesProperty); }
            set { SetValue(LinesProperty, value); }
        }

        public MultilineLabel()
        {
            InitializeComponent();
        }
    }
}
