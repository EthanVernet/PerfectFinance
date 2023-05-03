using System.Windows;
using System.Windows.Controls;

namespace Interface.Controls
{
    /// <summary>
    /// Logique d'interaction pour ProPassBox.xaml
    /// </summary>
    public partial class VisualPasswordBox : UserControl
    {
        private readonly FieldBox _passwordBox;
        private readonly FieldBox _textBox;

        public VisualPasswordBox()
        {
            _passwordBox = new()
            {
                TypeBox = TypeBox.PASSWORD,
                Margin = new Thickness(0, 0, 10, 0),
                PlaceholderText = "Password"
            };

            _textBox = new()
            {
                TypeBox = TypeBox.TEXT,
                Margin = new Thickness(0, 0, 10, 0),
                PlaceholderText = "Password"
            };

            InitializeComponent();

            Main.Children.Add(_passwordBox);
        }

        public string Text
        {
            get
            {
                if (Main.Children.Contains(_passwordBox))
                {
                    return _passwordBox.Text;
                }
                return _textBox.Text;
            }
            set
            {
                _textBox.Text = value;
                _passwordBox.Text = value;
            }
        }

        public string Error
        {
            set
            {
                _textBox.Error = value;
                _passwordBox.Error = value;
            }
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (Main.Children.Contains(_passwordBox))
            {
                _textBox.Text = Text;
                Main.Children.Remove(_passwordBox);
                Main.Children.Add(_textBox);
                Btn.Style = (Style)Application.Current.Resources["ShowPassword"];

            }
            else if (Main.Children.Contains(_textBox))
            {
                _passwordBox.Text = Text;
                Main.Children.Remove(_textBox);
                Main.Children.Add(_passwordBox);
                Btn.Style = (Style)Application.Current.Resources["HidePassword"];
            }
        }
    }
}
