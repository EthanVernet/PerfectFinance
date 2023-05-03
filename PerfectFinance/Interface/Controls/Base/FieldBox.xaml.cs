using System.Windows;
using System.Windows.Controls;

namespace Interface.Controls
{
    /// <summary>
    /// Logique d'interaction pour FieldBox.xaml
    /// </summary>
    public partial class FieldBox : UserControl
    {
        private readonly TextBox _textBox;
        private readonly IntegerBox _integerBox;
        private readonly PasswordBox _passwordBox;
        private readonly MoneyBox _moneyBox;
        private readonly ErrorFieldBox _errorFieldBox;

        public TypeBox TypeBox
        {
            set
            {
                switch (value)
                {
                    case TypeBox.INTEGER: Main.Children.Add(_integerBox); break;
                    case TypeBox.PASSWORD: Main.Children.Add(_passwordBox); break;
                    case TypeBox.MONEY: Main.Children.Add(_moneyBox); break;
                    default: Main.Children.Add(_textBox); break;

                };
            }
        }

        public FieldBox()
        {
            _errorFieldBox = new() { VerticalContentAlignment = VerticalAlignment.Top };
            _errorFieldBox.SetValue(Grid.RowProperty, 1);

            InitializeComponent();

            _textBox = new() { Style = (Style)FieldBoxControl.FindResource("FieldBoxStyle") };
            _integerBox = new() { Style = (Style)FieldBoxControl.FindResource("FieldBoxStyle") };
            _passwordBox = new() { Style = (Style)Application.Current.Resources["PasswordBox"] };
            _moneyBox = new() { Style = (Style)FieldBoxControl.FindResource("FieldBoxStyle") };
        }

        public string Text
        {
            get
            {
                if (Main.Children.Contains(_integerBox)) { return _integerBox.Text; }
                if (Main.Children.Contains(_passwordBox)) { return _passwordBox.Password; }
                if (Main.Children.Contains(_moneyBox)) { return _moneyBox.Text; }
                return _textBox.Text;
            }
            set
            {
                _textBox.Text = value;
                _integerBox.Text = value;
                _passwordBox.Password = value;
                _moneyBox.Text = value;
            }
        }

        public string Error
        {
            set
            {
                _errorFieldBox.Text = value;
                if (string.IsNullOrEmpty(value) && Main.Children.Contains(_errorFieldBox))
                {
                    Main.Children.Remove(_errorFieldBox);
                }
                else if (!string.IsNullOrEmpty(value) && !Main.Children.Contains(_errorFieldBox))
                {
                    Main.Children.Add(_errorFieldBox);
                }
            }
        }

        public static readonly DependencyProperty PlaceholderTextProperty = DependencyProperty.Register(
            "PlaceholderText",
            typeof(string),
            typeof(FieldBox),
            new PropertyMetadata(string.Empty)
        );

        public string PlaceholderText
        {
            get => (string)GetValue(PlaceholderTextProperty);
            set => SetValue(PlaceholderTextProperty, value);
        }
    }

    public enum TypeBox
    {
        TEXT,
        INTEGER,
        PASSWORD,
        MONEY
    }
}
