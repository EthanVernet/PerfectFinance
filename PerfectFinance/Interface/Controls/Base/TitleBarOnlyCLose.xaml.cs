using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Interface.Controls
{
    /// <summary>
    /// Logique d'interaction pour TitleBarOnlyCLose.xaml
    /// </summary>
    public partial class TitleBarOnlyCLose : UserControl
    {
        private Brush _background;

        public string Title { get => TitleText.Text; set => TitleText.Text = value; }

        public new Brush Background
        {
            get => Main.Background;
            set
            {
                _background = value;
                SetButtonStyles();
                Main.Background = _background;
            }
        }

        public TitleBarOnlyCLose()
        {
            InitializeComponent();
            this.MouseLeftButtonDown += TitleBar_MouseLeftButtonDown;
        }

        public bool IsColorDark(Brush brush)
        {
            var solidColorBrush = (SolidColorBrush)brush;
            Color color = solidColorBrush.Color;
            double luminance = (0.299 * color.R) + (0.587 * color.G) + (0.114 * color.B);
            return luminance < 128;
        }

        private void SetButtonStyles()
        {
            string colorSuffix = IsColorDark(_background) ? "Black" : "White";

            CloseButton.Style = this.FindResource($"Close{colorSuffix}Button") as Style;
            TitleText.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(IsColorDark(_background) ? "#000000" : "#FFFFFF"));
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            parentWindow?.Close();
        }

        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 1)
            {
                Window parentWindow = Window.GetWindow(this);
                if (parentWindow != null && e.ButtonState == MouseButtonState.Pressed)
                {
                    parentWindow.DragMove();
                }
            }
        }
    }
}
