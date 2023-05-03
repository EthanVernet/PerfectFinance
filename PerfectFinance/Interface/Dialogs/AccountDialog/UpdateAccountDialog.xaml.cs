using Interface.Pages;
using Logic;
using Logic.Dao;
using Logic.Model;
using Storage;
using System.Windows;
using System.Windows.Controls;

namespace Interface.Dialogs
{
    /// <summary>
    /// Logique d'interaction pour UpdateAccountDialog.xaml
    /// </summary>
    public partial class UpdateAccountDialog : Page
    {
        private readonly BasePageContentMiddle _base;
        private readonly User _user;
        private readonly Account _account;
        private readonly IAccountDao _accountDao;


        public UpdateAccountDialog(User user, IModel account)
        {
            _user = user;
            _accountDao = new AccountDao();
            InitializeComponent();

            if (account is Account tmp)
            {
                _account = tmp;
                AccountName.Text = _account.Name;
            }

            _base = new(Main, LeftColumn, RightColumn);
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            _base.InitializeResponsive(mainWindow.Width);

            LabelTitle.Content = "Update account";
            Valider.Content = "Update";

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _base.Page_Loaded(this);
        }

        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            _account.Name = AccountName.Text;
            _accountDao.Update(_account, _user);

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
