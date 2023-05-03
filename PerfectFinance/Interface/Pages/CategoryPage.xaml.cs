using Exceptions;
using Interface.Bases;
using Interface.Dialogs;
using Logic.Dao;
using Logic.Model;
using Storage;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Interface.Pages
{
    /// <summary>
    /// Logique d'interaction pour CategoryPage.xaml
    /// </summary>
    public partial class CategoryPage : Page
    {
        private readonly User _user;

        private readonly BasePageContentRight _base;
        private readonly ICategoryDao _categoryDao;
        private readonly ITransactionDao _transactionDao;

        public CategoryPage(User user)
        {
            _user = user;
            _categoryDao = new CategoryDao();
            _transactionDao = new TransactionDao();
            InitializeComponent();

            _base = new BasePageContentRight(Main, LeftColumn, RightColumn);
            _base.InitializeResponsive(Application.Current.MainWindow.Width);

            List<Category> tmp = new();
            foreach (Category category in _categoryDao.List(_user))
            {
                category.Amount = _transactionDao.AmountByCategory(_user, category.Id);
                tmp.Add(category);
            }
            Container.Categories = tmp;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _base.Page_Loaded(this);
        }

        private void AddCategory_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.ShowCreateDialog(TypeDialog.CATEGORY_CREATE);
        }
    }
}
