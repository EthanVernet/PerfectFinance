using Interface.Pages;
using Logic;
using Logic.Dao;
using Logic.Model;
using Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Interface.Dialogs
{
    /// <summary>
    /// Logique d'interaction pour UpdateCategoryDialog.xaml
    /// </summary>
    public partial class UpdateCategoryDialog : Page
    {
        private readonly BasePageContentMiddle _base;
        private readonly User _user;
        private readonly Category _category;
        private readonly ICategoryDao _categoryDao;

        public UpdateCategoryDialog(User user, IModel category)
        {
            _user = user;

            _categoryDao = new CategoryDao();
            InitializeComponent();

            _base = new(Main, LeftColumn, RightColumn);
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            _base.InitializeResponsive(mainWindow.Width);

            if (category is Category tmp)
            {
                _category = tmp;
                CategoryName.Text = _category.Name;
                PreviewAmount.Text = _category.PreviewAmount.ToString();
            }

            LabelTitle.Content = "Update account";
            Valider.Content = "Update";
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _base.Page_Loaded(this);
        }

        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            _category.Name = CategoryName.Text;
            _category.PreviewAmount = Convert.ToDecimal(PreviewAmount.Text);
            _categoryDao.Update(_category, _user);

            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.ShowPage(TypePage.CATEGORY);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.ShowPage(TypePage.CATEGORY);
        }
    }
}
