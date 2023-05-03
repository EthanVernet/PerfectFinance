using Interface.Dialogs;
using Logic;
using Logic.Model;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Interface.Controls
{
    /// <summary>
    /// Logique d'interaction pour VisualItemTransaction.xaml
    /// </summary>
    public partial class ItemTransaction : UserControl
    {
        private int _id;
        private Account _account;
        private Category _category;

        public Transaction Transaction
        {
            get
            {
                Transaction transaction = new()
                {
                    Id = _id,
                    Nature = Nature,
                    Account = _account,
                    Name = TransactionName.Text,
                    Amount = Convert.ToDecimal(Amount.Text),
                    Category = _category,
                };
                return transaction;
            }
            set
            {
                Transaction tmp = value;
                _id = tmp.Id;
                Nature = tmp.Nature;
                AccountName.Text = tmp.Account.ToString();
                TransactionName.Text = tmp.Name;
                Amount.Text = tmp.Amount.ToString();
                CategoryName.Text = tmp.Category.ToString();

                _account = tmp.Account;
                _category = tmp.Category;
            }
        }

        public ItemTransaction()
        {
            InitializeComponent();
        }


        private void Edit_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.ShowUpdateDeleteDialog(TypeDialog.CATEGORY_UPDATE, _category);
        }

        private void Delete_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.ShowUpdateDeleteDialog(TypeDialog.CATEGORY_DELETE, _category);
        }

        public Nature Nature
        {
            get => _nature;
            set
            {
                _nature = value;
                BitmapImage tmp = new();
                switch (value)
                {
                    case Nature.CHEQUE:
                        tmp.UriSource = new Uri(@"\Ressource\cheque.png", UriKind.Relative);
                        NatureImage.Source = tmp;
                        break;
                    case Nature.ESPECE:
                        tmp.UriSource = new Uri(@"\Ressource\cash.png", UriKind.Relative);
                        NatureImage.Source = tmp;
                        break;
                    case Nature.CARTE:
                        tmp.UriSource = new Uri(@"\Ressource\card.png", UriKind.Relative);
                        NatureImage.Source = tmp;
                        break;
                }
            }
        }
        private Nature _nature;
    }
}
