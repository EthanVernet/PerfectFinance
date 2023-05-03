using System.Windows.Controls;

namespace Interface.Controls
{
    /// <summary>
    /// Logique d'interaction pour ErrorFieldBox.xaml
    /// </summary>
    public partial class ErrorFieldBox : UserControl
    {
        public string Text { get => TextBlock.Text; set => TextBlock.Text = value; }

        public ErrorFieldBox()
        {
            InitializeComponent();
        }
    }
}
