using Exceptions;
using Exceptions.DataBaseExceptions;
using Exceptions.EmptyFieldExceptions;
using Logic.Dao;
using Logic.Model;
using Storage;
using System.Windows;
using System.Windows.Controls;

namespace Interface.Pages
{
    /// <summary>
    /// Logique d'interaction pour InscriptionPage.xaml
    /// </summary>
    public partial class InscriptionPage : Page
    {
        private readonly IUserDao _userDao;
        private readonly IPhoneDao _phoneDao;
        private readonly BasePageContentMiddle _base;

        public InscriptionPage()
        {
            _userDao = new UserDao();
            _phoneDao = new PhoneDao();

            InitializeComponent();

            _base = new(Main, LeftColumn, RightColumn);
            _base.InitializeResponsive(Application.Current.MainWindow.Width);

            Phone.ItemsSource = _phoneDao.List();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _base.Page_Loaded(this);
        }

        private void Login_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            User user = new();
            Username.Error = "";
            Password.Error = "";
            Mail.Error = "";
            Phone.Error = "";

            try
            {
                user.Username = Username.Text;
                if (_userDao.UsernameExist(Username.Text)) throw new UsernameExistException();

                user.Password = Password.Text;

                user.Email = Mail.Text;
                if (_userDao.MailExist(Mail.Text)) throw new MailExistException();

                user.PhoneNumber = Phone.Text;
                if (_userDao.PhoneNumberExist(Phone.Text)) throw new PhoneExistException();

                user.Phone = Phone.Item;

                _userDao.Create(user);
                MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
                mainWindow.ShowPage(TypePage.CONNEXION);
            }
            catch (UsernameFieldException ex) { Username.Error = ex.Message; }
            catch (UsernameExistException ex) { Username.Error = ex.Message; }

            catch (PasswordFieldException ex) { Password.Error = ex.Message; }
            catch (PasswordException ex) { Password.Error = ex.Message; }

            catch (MailFieldException ex) { Mail.Error = ex.Message; }
            catch (MailExistException ex) { Mail.Error = ex.Message; }

            catch (PhoneFieldException ex) { Phone.Error = ex.Message; }
            catch (PhoneExistException ex) { Phone.Error = ex.Message; }

            catch (PhoneCodeIsNull ex) { Phone.Error = ex.Message; }
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.ShowPage(TypePage.CONNEXION);
        }
    }
}
