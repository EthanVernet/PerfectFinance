using Exceptions;
using Logic.Dao;
using Logic.Model;
using Storage;
using System.Windows.Controls;

namespace Interface.Pages
{
    /// <summary>
    /// Logique d'interaction pour TransactionPage.xaml
    /// </summary>
    public partial class TransactionPage : Page
    {
        private readonly User _user;

        private readonly ITransactionDao _transactionDao;

        public TransactionPage(User user)
        {
            _user = user;
            _transactionDao = new TransactionDao();
            InitializeComponent();
        }
    }
}
