using Interface.Pages;
using Logic.Dao;
using Logic.Model;
using Storage;
using System.Windows;
using System.Windows.Controls;

namespace Interface.Dialogs
{
    /// <summary>
    /// Logique d'interaction pour CreateUpdateAccountDialog.xaml
    /// </summary>
    public partial class CreateAccountDialog : Page
    {
        private readonly BasePageContentMiddle _base;
        private readonly User _user;
        private readonly IAccountDao _accountDao;

        public CreateAccountDialog(User user)
        {
            _user = user;

            _accountDao = new AccountDao();
            InitializeComponent();
            
            _base = new(Main, LeftColumn, RightColumn);
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow; 
            _base.InitializeResponsive(mainWindow.Width);

            
            LabelTitle.Content = "Create account";
            Valider.Content = "Create";

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _base.Page_Loaded(this);
        }

        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            Account account = new()
            {
                Name = AccountName.Text
            };

            _accountDao.Create(account, _user);

            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.ShowPage(TypePage.ACCOUNT);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.ShowPage(TypePage.ACCOUNT);
        }
    }
}
