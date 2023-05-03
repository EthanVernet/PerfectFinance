using Exceptions;
using Logic.Model;
using System.Windows.Controls;

namespace Interface.Pages
{
    /// <summary>
    /// Logique d'interaction pour StatPage.xaml
    /// </summary>
    public partial class StatPage : Page
    {
        private User _user;

        public StatPage(User user)
        {
            _user = user;
            InitializeComponent();

        }
    }
}
