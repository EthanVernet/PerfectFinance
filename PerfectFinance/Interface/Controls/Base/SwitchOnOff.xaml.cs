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
    /// Logique d'interaction pour SwitchOnOff.xaml
    /// </summary>
    public partial class SwitchOnOff : UserControl
    {
        private bool _isOff = true;
        public SwitchOnOff()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(_isOff)
            {
                Btn.Style = (Style)Application.Current.Resources["SwitchOnButton"];
                _isOff = false;
            }
            else
            {
                Btn.Style = (Style)Application.Current.Resources["SwitchOffButton"];
                _isOff = true;
            }
        }
    }
}
