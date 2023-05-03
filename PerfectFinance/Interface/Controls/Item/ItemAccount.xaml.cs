using Interface.Dialogs;
using Interface.Pages;
using Logic.Dao;
using Logic.Model;
using Storage;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Interface.Controls
{
    /// <summary>
    /// Logique d'interaction pour ItemAccount.xaml
    /// </summary>
    public partial class ItemAccount : UserControl
    {
        private int _id;

        public Account Account
        {
            get
            {
                Account account = new()
                {
                    Id = _id,
                    Name = AccountName.Content.ToString(),
                };
                return account;
            }
            set
            {
                Account tmp = value;
                _id = tmp.Id;
                AccountName.Content = tmp.Name;
                Amount.Content = tmp.Amount.ToString() + " €";
            }
        }

        public ItemAccount()
        {
            InitializeComponent();
        }

        private void Edit_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.ShowUpdateDeleteDialog(TypeDialog.ACCOUNT_UPDATE, Account);
        }

        private void Delete_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.ShowUpdateDeleteDialog(TypeDialog.ACCOUNT_DELETE, Account);
        }
    }
}
