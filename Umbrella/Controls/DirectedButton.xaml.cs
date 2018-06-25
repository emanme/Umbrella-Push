using System;
using Umbrella.Constants;
using Umbrella.Enums;
using Xamarin.Forms;

namespace Umbrella.Controls
{
    public delegate void ButtonClickedEventHandler(object sender, EventArgs args);

    public partial class DirectedButton : ContentView
    {
        public const double LEFT_POSITION = 0.02;
        public const double RIGHT_POSITION = 0.98;

        private static string _defaultText = "";

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string),
                typeof(DirectedButton), _defaultText, BindingMode.TwoWay, null,
                (bindable, oldValue, newValue) =>
                {
                    var control = (DirectedButton) bindable;
                    control.Text = (string) newValue;
                });
        public string Text
        {
            get { return (string) GetValue(TextProperty); }
            set
            {
                SetValue(TextProperty, value);
                ButtonLabel.Text = value;
            }
        }

        public ArrowDirection Direction
        {
            get
            {
                if (ButtonDirection.Text.Equals(FontIcon.ANGLE_UP))
                {
                    return ArrowDirection.Up;
                }
                else if (ButtonDirection.Text.Equals(FontIcon.ANGLE_DOWN))
                {
                    return ArrowDirection.Down;
                }
                else if (ButtonDirection.Text.Equals(FontIcon.ANGLE_RIGHT))
                {
                    return ArrowDirection.Right;
                }
                else if (ButtonDirection.Text.Equals(FontIcon.ANGLE_LEFT))
                {
                    return ArrowDirection.Left;
                }
                else if (ButtonDirection.Text.Equals(FontIcon.ANGLE_DOUBLE_UP))
                {
                    return ArrowDirection.DoubleUp;
                }
                else if (ButtonDirection.Text.Equals(FontIcon.ANGLE_DOUBLE_DOWN))
                {
                    return ArrowDirection.DoubleDown;
                }
                else if (ButtonDirection.Text.Equals(FontIcon.ANGLE_DOUBLE_RIGHT))
                {
                    return ArrowDirection.DoubleRight;
                }
                else if (ButtonDirection.Text.Equals(FontIcon.ANGLE_DOUBLE_LEFT))
                {
                    return ArrowDirection.DoubleLeft;
                }
                else
                {
                    return ArrowDirection.Default;
                }

            }
            set
            {
                if (value.Equals(ArrowDirection.Up))
                {
                    ButtonDirection.Text = FontIcon.ANGLE_UP;
                }
                else if (value.Equals(ArrowDirection.Down))
                {
                    ButtonDirection.Text = FontIcon.ANGLE_DOWN;
                }
                else if (value.Equals(ArrowDirection.Right))
                {
                    ButtonDirection.Text = FontIcon.ANGLE_RIGHT;
                }
                else if (value.Equals(ArrowDirection.Left))
                {
                    ButtonDirection.Text = FontIcon.ANGLE_LEFT;
                }
                else if (value.Equals(ArrowDirection.DoubleUp))
                {
                    ButtonDirection.Text = FontIcon.ANGLE_DOUBLE_UP;
                }
                else if (value.Equals(ArrowDirection.DoubleDown))
                {
                    ButtonDirection.Text = FontIcon.ANGLE_DOUBLE_DOWN;
                }
                else if (value.Equals(ArrowDirection.DoubleRight))
                {
                    ButtonDirection.Text = FontIcon.ANGLE_DOUBLE_RIGHT;
                }
                else if (value.Equals(ArrowDirection.DoubleLeft))
                {
                    ButtonDirection.Text = FontIcon.ANGLE_DOUBLE_LEFT;
                }
                else
                {
                    ButtonDirection.Text = FontIcon.ANGLE_RIGHT;
                }
            }
        }

        public ArrowPosition Position
        {
            get
            {
                if (AbsoluteLayout.GetLayoutBounds(ButtonDirection).X == LEFT_POSITION)
                {
                    return ArrowPosition.Left;
                }
                else if (AbsoluteLayout.GetLayoutBounds(ButtonDirection).X == RIGHT_POSITION)
                {
                    return ArrowPosition.Right;
                }
                else
                {
                    return ArrowPosition.Default;
                }
            }
            set
            {
                if (value.Equals(ArrowPosition.Left))
                {
                    AbsoluteLayout.SetLayoutBounds(ButtonDirection, new Rectangle(LEFT_POSITION, 0.5, 30, 30));
                }
                else if (value.Equals(ArrowPosition.Right))
                {
                    AbsoluteLayout.SetLayoutBounds(ButtonDirection, new Rectangle(RIGHT_POSITION, 0.5, 30, 30));
                }
                else
                {
                    AbsoluteLayout.SetLayoutBounds(ButtonDirection, new Rectangle(RIGHT_POSITION, 0.5, 30, 30));
                }
            }
        }

        public Color Color
        {
            get { return ButtonLabel.BackgroundColor; }
            set { ButtonLabel.BackgroundColor = value; }
        }
        public static readonly BindableProperty IsEnableButtonProperty =
                 BindableProperty.Create(nameof(IsEnableButton), typeof(bool),
                     typeof(DirectedButton), true, BindingMode.TwoWay, null,
                     (bindable, oldValue, newValue) =>
                     {
                         var control = (DirectedButton)bindable;
                         control.IsEnableButton = (bool)newValue;
                     });
        public bool IsEnableButton
        {
            get { return (bool)GetValue(IsEnableButtonProperty); }
            set
            {
                SetValue(IsEnableButtonProperty, value);
                ButtonLabel.IsEnabled = value;
            }
        }

        public event ButtonClickedEventHandler Clicked;

        public DirectedButton()
        {
            InitializeComponent();
        }

        private void DirectedButtonClicked(object sender, EventArgs args)
        {
            Clicked?.Invoke(sender, args);
        }
    }
}
