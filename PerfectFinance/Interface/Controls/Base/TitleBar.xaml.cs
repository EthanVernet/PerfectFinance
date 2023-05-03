using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Interface.Controls
{
    /// <summary>
    /// Logique d'interaction pour TitleBar.xaml
    /// </summary>
    public partial class TitleBar : UserControl
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

        public TitleBar()
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

            MinimizeButton.Style = this.FindResource($"Minimize{colorSuffix}Button") as Style;
            MaximizeButton.Style = this.FindResource($"Restore{colorSuffix}Button") as Style;
            CloseButton.Style = this.FindResource($"Close{colorSuffix}Button") as Style;
            TitleText.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(IsColorDark(_background) ? "#000000" : "#FFFFFF"));
        }

        private void UpdateWindowState(Window parentWindow)
        {
            parentWindow.WindowState = parentWindow.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
            string colorSuffix = IsColorDark(Main.Background) ? "Black" : "White";
            bool isMaximized = parentWindow.WindowState == WindowState.Maximized;

            MaximizeButton.Style = this.FindResource($"{(isMaximized ? "Restore" : "Maximize")}{colorSuffix}Button") as Style;

            if (isMaximized)
            {
                TitleText.Margin = new Thickness(14, 6, 0, 0);
                MaximizeButton.Margin = new Thickness(0, 6, 4, 0);
                MinimizeButton.Margin = new Thickness(0, 6, 4, 0);
                CloseButton.Margin = new Thickness(0, 6, 4, 0);
            }
            else
            {
                TitleText.Margin = new Thickness(10, 0, 0, 0);
                MaximizeButton.Margin = new Thickness(0, 0, 0, 0);
                MinimizeButton.Margin = new Thickness(0, 0, 0, 0);
                CloseButton.Margin = new Thickness(0 , 0, 0, 0);
            }
        }
        #region event
        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            parentWindow.WindowState = WindowState.Minimized;
        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            if (parentWindow != null)
            {
                UpdateWindowState(parentWindow);
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            parentWindow?.Close();
        }

        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                Window parentWindow = Window.GetWindow(this);
                if (parentWindow != null)
                {
                    UpdateWindowState(parentWindow);
                }
            }
            else
            {
                Window parentWindow = Window.GetWindow(this);
                if (parentWindow != null && e.ButtonState == MouseButtonState.Pressed)
                {
                    parentWindow.DragMove();
                }
            }
        }
        #endregion
    }
}