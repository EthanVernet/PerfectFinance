using Exceptions;
using Interface.Bases;
using Interface.Controls;
using Interface.Dialogs;
using Logic.Dao;
using Logic.Model;
using Storage;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Interface.Pages
{
    /// <summary>
    /// Logique d'interaction pour AccountPage.xaml
    /// </summary>
    public partial class AccountPage : Page
    {
        private  User _user; 
        
        private BasePageContentRight _base;

        private VisualContainerAccount _container;

        private  IAccountDao _accountDao;
        private  ITransactionDao _transactionDao;

        public AccountPage(User user)
        {
            InitializeComponent();
            InitializeProperty(user);
            InitializeBase();
            InitializeContainer();
        }

        private void InitializeProperty(User user)
        {
            _user = user;
            _accountDao = new AccountDao();
            _transactionDao = new TransactionDao();
        }

        private void InitializeBase()
        {
            _base = new BasePageContentRight(Main, LeftColumn, RightColumn);
            _base.InitializeResponsive(Application.Current.MainWindow.Width);
        }

        private void InitializeContainer()
        {            
            List<Account> tmp = new();
            foreach (Account account in _accountDao.List(_user))
            {
                account.Amount = _transactionDao.AmountByAccount(_user, account.Id);
                tmp.Add(account);
            }

            _container = new()
            {
                Margin = new Thickness(20, 0, 20, 20),
                User = _user,
                Accounts = tmp
            };
            _container.SetValue(Grid.RowProperty, 1);
            Main.Children.Add(_container);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _base.Page_Loaded(this);
        }

        private void AddAccount_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.ShowCreateDialog(TypeDialog.ACCOUNT_CREATE);
        }
    }
}
