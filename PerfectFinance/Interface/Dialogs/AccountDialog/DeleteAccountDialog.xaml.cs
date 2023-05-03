using Interface.Pages;
using Logic;
using Logic.Dao;
using Logic.Model;
using Storage;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Interface.Dialogs
{
    /// <summary>
    /// Logique d'interaction pour DialogWindow.xaml
    /// </summary>
    public partial class DeleteAccountDialog : Page
    {
        private readonly User _user;
        private readonly IAccountDao _accountDao;
        private readonly BasePageContentMiddle _base;
    
        private readonly Account _account;

        public DeleteAccountDialog(User user, IModel account)
        {
            _user = user;
            if (account is Account tmp) { _account = tmp; }
            _accountDao = new AccountDao();

            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            InitializeComponent();

            _base = new BasePageContentMiddle(Main, LeftColumn, RightColumn);
            _base.InitializeResponsive(mainWindow.Width);

            LabelTitle.Content = "Delete Account";
            Label.Content = "Are you sure you want to delete this account";
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _base.Page_Loaded(this);
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.ShowPage(TypePage.ACCOUNT);
        }

        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            _accountDao.Delete(_account, _user);

            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.ShowPage(TypePage.ACCOUNT);
        }
    }
}
