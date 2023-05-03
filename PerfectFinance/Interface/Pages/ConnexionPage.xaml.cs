using Exceptions;
using Interface.Controls;
using Logic.Dao;
using Logic.Model;
using Storage;
using System.Windows;
using System.Windows.Controls;

namespace Interface.Pages
{
    /// <summary>
    /// Logique d'interaction pour ConnexionPage.xaml
    /// </summary>
    public partial class ConnexionPage : Page
    {
        private readonly IUserDao _userDao;
        private readonly BasePageContentMiddle _base;

        public ConnexionPage(string error)
        {
            _userDao = new UserDao();
            InitializeComponent();
            _base = new(ContentGrid, LeftColumn, RightColumn);
            _base.InitializeResponsive(Application.Current.MainWindow.Width);

            ErrorFieldBox.Text = error;
            ErrorFieldBox.Visibility = Visibility.Visible;
        }

        public ConnexionPage()
        {
            _userDao = new UserDao();
            InitializeComponent();
            _base = new(ContentGrid, LeftColumn, RightColumn);
            _base.InitializeResponsive(Application.Current.MainWindow.Width);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _base.Page_Loaded(this);
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            Password.Error = "";
            ErrorFieldBox.Visibility = Visibility.Hidden;
            try
            {
                MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
                mainWindow.CurrentUser = _userDao.Read(Username.Text, Password.Text);
                mainWindow.ShowPage(TypePage.HOME);
            }
            catch (WrongUsernameOrPassword ex) { Password.Error = ex.Message; }
        }
    }
}
