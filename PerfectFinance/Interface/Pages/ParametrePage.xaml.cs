using Exceptions;
using Logic.Model;
using System.Windows.Controls;

namespace Interface.Pages
{
    /// <summary>
    /// Logique d'interaction pour ParametrePage.xaml
    /// </summary>
    public partial class ParametrePage : Page
    {
        private User _user;

        public ParametrePage(User user)
        {
            _user = user;
            InitializeComponent();
        }
    }
}
