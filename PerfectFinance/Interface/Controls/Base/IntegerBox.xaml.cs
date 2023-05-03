using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace Interface.Controls
{
    /// <summary>
    /// Logique d'interaction pour IntegerBox.xaml
    /// </summary>
    public partial class IntegerBox : UserControl
    {
        public string Text { get => textBox.Text; set => textBox.Text = value; }
        public new object Tag { get => (string)textBox.Tag; set => textBox.Tag = value; }
        public new Style Style { get => textBox.Style; set => textBox.Style = value; }

        public IntegerBox()
        {
            InitializeComponent();
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (!Regex.IsMatch(textBox.Text, @"^[0-9]*$"))
            {
                textBox.Text = textBox.Text.Remove(textBox.Text.Length - 1);
                textBox.SelectionStart = textBox.Text.Length;
            }
        }
    }
}
