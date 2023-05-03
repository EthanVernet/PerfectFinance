using Exceptions;
using Logic.Model;
using System.Windows.Controls;

namespace Interface.Pages
{
    /// <summary>
    /// Logique d'interaction pour TemplatePage.xaml
    /// </summary>
    public partial class TemplatePage : Page
    {
        private readonly User _user;

        public TemplatePage(User user)
        {
            _user = user;
            InitializeComponent();
        }
    }
}
