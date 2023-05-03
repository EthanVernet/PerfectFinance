using Logic.Model;
using System.Collections;
using System.Windows.Controls;

namespace Interface.Controls
{
    /// <summary>
    /// Logique d'interaction pour ProPhoneBox.xaml
    /// </summary>
    public partial class VisualPhoneBox : UserControl
    {
        public string Text { get => Box.Text; set => Box.Text = value; }
        public string Error { set => Box.Error = value; }

        public Phone Item { get => (Phone)ComboBox.SelectedItem; }

        public IEnumerable ItemsSource
        {
            get => ComboBox.ItemsSource;
            set => ComboBox.ItemsSource = value;
        }

        public VisualPhoneBox()
        {
            InitializeComponent();
        }

    }
}
