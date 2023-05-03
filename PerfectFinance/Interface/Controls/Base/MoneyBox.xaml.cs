using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Logique d'interaction pour MoneyBox.xaml
    /// </summary>
    public partial class MoneyBox : UserControl
    {
        public string Text { get => textBox.Text; set => textBox.Text = value; }
        public new object Tag { get => (string)textBox.Tag; set => textBox.Tag = value; }
        public new Style Style { get => textBox.Style; set => textBox.Style = value; }

        public MoneyBox()
        {
            InitializeComponent();
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (!Regex.IsMatch(textBox.Text, @"^[0-9]+(\.[0-9]{1,2})?$"))
                {
                    textBox.Text = textBox.Text.Remove(textBox.Text.Length - 1);
                    textBox.SelectionStart = textBox.Text.Length;
                }
            }
            catch (Exception ex)
            {
                textBox.Text = "";
            }
        }
    }
}
