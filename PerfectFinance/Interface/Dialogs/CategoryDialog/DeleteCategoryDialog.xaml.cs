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
    /// Logique d'interaction pour DeleteCategoryDialog.xaml
    /// </summary>
    public partial class DeleteCategoryDialog : Page
    {
        private readonly User _user;
        private readonly ICategoryDao _categoryDao;
        private readonly BasePageContentMiddle _base;

        private readonly Category _category;

        public DeleteCategoryDialog(User user, IModel category)
        {
            _user = user;
            if (category is Category) { _category = category as Category; }
            _categoryDao = new CategoryDao();
            InitializeComponent();

            _base = new BasePageContentMiddle(Main, LeftColumn, RightColumn);

            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            _base.InitializeResponsive(mainWindow.Width);

            LabelTitle.Content = "Delete Category";
            Label.Content = "Are you sure you want to delete this category";
        }


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _base.Page_Loaded(this);
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.ShowPage(TypePage.CATEGORY);
        }

        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            _categoryDao.Delete(_category, _user);

            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.ShowPage(TypePage.CATEGORY);
        }
    }
}
