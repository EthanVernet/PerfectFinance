using Exceptions;
using Logic.Model;
using System.Windows.Controls;

namespace Interface.Pages
{
    /// <summary>
    /// Logique d'interaction pour PretPage.xaml
    /// </summary>
    public partial class PretPage : Page
    {
        private User _user;
        public PretPage(User user)
        {
            _user = user;
            InitializeComponent();
            
        }
    }
}
