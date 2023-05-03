using Interface.Pages;
using Logic.Dao;
using Logic.Model;
using Storage;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Logique d'interaction pour CreateCategory.xaml
    /// </summary>
    public partial class CreateCategoryDialog : Page
    {
        private readonly BasePageContentMiddle _base;
        private readonly User _user;
        private readonly ICategoryDao _categoryDao;

        public CreateCategoryDialog(User user)
        {
            _user = user;

            _categoryDao = new CategoryDao();
            InitializeComponent();

            _base = new(Main, LeftColumn, RightColumn);
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            _base.InitializeResponsive(mainWindow.Width);

            LabelTitle.Content = "Create category";
            Valider.Content = "Create";
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _base.Page_Loaded(this);
        }

        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            Category category = new()
            {
                Name = CategoryName.Text,
                PreviewAmount = Convert.ToDecimal(PreviewAmount.Text),
            };

            _categoryDao.Create(category, _user);

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
