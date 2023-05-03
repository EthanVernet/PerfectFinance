using Exceptions;
using Logic.Model;
using System.Windows.Controls;

namespace Interface.Pages
{
    /// <summary>
    /// Logique d'interaction pour HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        private User _user;

        public HomePage(User user)
        {
            _user = user;
            InitializeComponent();

        }
    }
}
