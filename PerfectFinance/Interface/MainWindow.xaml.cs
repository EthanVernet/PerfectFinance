using Interface.Dialogs;
using Interface.Pages;
using Logic;
using Logic.Model;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace Interface
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int WIDTH_THRESHOLD_MIN = 500;

        public new string Title { get => Bar.Title; set => Bar.Title = value; }


        private User _currentUser;
        public User CurrentUser
        {
            get => _currentUser;
            set => _currentUser = value;
        }

        public MainWindow()
        {
            InitializeComponent();
            Bar.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#42BFDD"));
            InitializeResponsive(Application.Current.MainWindow.ActualWidth);

            MainFrame.Navigate(new Uri("Pages/InscriptionPage.xaml", UriKind.Relative));
            Main.Title = "Connexion";
        }

        public void ShowPage(TypePage type, string error = "")
        {
            switch (type)
            {
                case TypePage.ACCOUNT:     MainFrame.Navigate(new AccountPage(CurrentUser));  break;
                case TypePage.CATEGORY:    MainFrame.Navigate(new CategoryPage(CurrentUser)); break;
                case TypePage.CONNEXION:   MainFrame.Navigate(new ConnexionPage(error));   break;
                case TypePage.HOME:        MainFrame.Navigate(new HomePage(CurrentUser));   break;
                case TypePage.PARAMETRE:   MainFrame.Navigate(new ParametrePage(CurrentUser));    break;
                case TypePage.INSCRIPTION: MainFrame.Navigate(new InscriptionPage());  break;
                case TypePage.PRET:        MainFrame.Navigate(new PretPage(CurrentUser)); break;
                case TypePage.STAT:        MainFrame.Navigate(new StatPage(CurrentUser)); break;
                case TypePage.TEMPLATE:    MainFrame.Navigate(new StatPage(CurrentUser));break;
                case TypePage.TRANSACTION: MainFrame.Navigate(new TransactionPage(CurrentUser));  break;
            }
        }

        public void ShowCreateDialog(TypeDialog type)
        {   
            switch(type)
            {
                case TypeDialog.ACCOUNT_CREATE: MainFrame.Navigate(new CreateAccountDialog(CurrentUser)); break;
                case TypeDialog.CATEGORY_CREATE: MainFrame.Navigate(new CreateCategoryDialog(CurrentUser)); break;
                
            }
        }

        public void ShowUpdateDeleteDialog(TypeDialog type, IModel model)
        { 
            switch(type)
            {
                case TypeDialog.ACCOUNT_UPDATE: MainFrame.Navigate(new UpdateAccountDialog(CurrentUser, model)); break;
                case TypeDialog.ACCOUNT_DELETE: MainFrame.Navigate(new DeleteAccountDialog(CurrentUser, model)); break;

                case TypeDialog.CATEGORY_UPDATE: MainFrame.Navigate(new UpdateCategoryDialog(CurrentUser, model)); break;
                case TypeDialog.CATEGORY_DELETE: MainFrame.Navigate(new DeleteCategoryDialog(CurrentUser, model)); break;
            }
        }

        private void ResizeThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            if (sender is not Thumb thumb) return;

            double deltaHorizontal = e.HorizontalChange;
            double deltaVertical = e.VerticalChange;

            switch (thumb.Name)
            {
                case "TopLeftThumb":
                    Left += deltaHorizontal;
                    Top += deltaVertical;
                    Width = Math.Max(Width - deltaHorizontal, MinWidth);
                    Height = Math.Max(Height - deltaVertical, MinHeight);
                    break;
                case "TopRightThumb":
                    Top += deltaVertical;
                    Width = Math.Max(Width + deltaHorizontal, MinWidth);
                    Height = Math.Max(Height - deltaVertical, MinHeight);
                    break;
                case "BottomLeftThumb":
                    Left += deltaHorizontal;
                    Width = Math.Max(Width - deltaHorizontal, MinWidth);
                    Height = Math.Max(Height + deltaVertical, MinHeight);
                    break;
                case "BottomRightThumb":
                    Width = Math.Max(Width + deltaHorizontal, MinWidth);
                    Height = Math.Max(Height + deltaVertical, MinHeight);
                    break;
                case "LeftThumb":
                    Left += deltaHorizontal;
                    Width = Math.Max(Width - deltaHorizontal, MinWidth);
                    break;
                case "TopThumb":
                    Top += deltaVertical;
                    Height = Math.Max(Height - deltaVertical, MinHeight);
                    break;
                case "RightThumb":
                    Width = Math.Max(Width + deltaHorizontal, MinWidth);
                    break;
                case "BottomThumb":
                    Height = Math.Max(Height + deltaVertical, MinHeight);
                    break;
            }
        }

        #region Navigation Event
        private void Category_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentUser == null)
            {
                ShowPage(TypePage.CONNEXION);
            }
            else
            {
                ShowPage(TypePage.CATEGORY);
            }
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentUser == null)
            {
                ShowPage(TypePage.CONNEXION);
            }
            else
            {
                ShowPage(TypePage.HOME);
            }
        }

        private void Account_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentUser == null)
            {
                ShowPage(TypePage.CONNEXION);
            }
            else
            {
                ShowPage(TypePage.ACCOUNT);
            }
        }

        private void Transaction_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentUser == null)
            {
                ShowPage(TypePage.CONNEXION);
            }
            else
            {
                ShowPage(TypePage.TRANSACTION);
            }
        }

        private void Pret_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentUser == null)
            {
                ShowPage(TypePage.CONNEXION);
            }
            else
            {
                ShowPage(TypePage.PRET);
            }
        }

        private void Stat_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentUser == null)
            {
                ShowPage(TypePage.CONNEXION);
            }
            else
            {
                ShowPage(TypePage.STAT);
            }
        }

        private void Template_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentUser == null)
            {
                ShowPage(TypePage.CONNEXION);
            }
            else
            {
                ShowPage(TypePage.TEMPLATE);
            }
        }

        private void Setting_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentUser == null)
            {
                ShowPage(TypePage.CONNEXION);
            }
            else
            {
                ShowPage(TypePage.PARAMETRE);
            }
        }
        #endregion

        #region Responsive Event
        public event EventHandler<SizeChangedEventArgs> MainWindowSizeChanged;
        private void MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            MainWindowSizeChanged?.Invoke(sender, e);
            InitializeResponsive(this.Width);

        }

        private void InitializeResponsive(double windowWidth)
        {
            if (windowWidth <= WIDTH_THRESHOLD_MIN)
            {
                Menu.SetValue(Grid.RowProperty, 8);
                Account.SetValue(Grid.RowProperty, 8);
                Category.SetValue(Grid.RowProperty, 8);
                Transaction.SetValue(Grid.RowProperty, 8);
                Pret.SetValue(Grid.RowProperty, 8);
                Stat.SetValue(Grid.RowProperty, 8);
                Template.SetValue(Grid.RowProperty, 8);
                Setting.SetValue(Grid.RowProperty, 8);

                Menu.SetValue(Grid.ColumnProperty, 0);
                Account.SetValue(Grid.ColumnProperty, 1);
                Category.SetValue(Grid.ColumnProperty, 2);
                Transaction.SetValue(Grid.ColumnProperty, 3);
                Pret.SetValue(Grid.ColumnProperty, 4);
                Stat.SetValue(Grid.ColumnProperty, 5);
                Template.SetValue(Grid.ColumnProperty, 6);
                Setting.SetValue(Grid.ColumnProperty, 8);

                MainFrame.SetValue(Grid.ColumnProperty, 0);
                MainFrame.SetValue(Grid.RowSpanProperty, 8);
                MainFrame.SetValue(Grid.ColumnSpanProperty, 9);
            }
            else
            {
                Menu.SetValue(Grid.RowProperty, 0);
                Account.SetValue(Grid.RowProperty, 1);
                Category.SetValue(Grid.RowProperty, 2);
                Transaction.SetValue(Grid.RowProperty, 3);
                Pret.SetValue(Grid.RowProperty, 4);
                Stat.SetValue(Grid.RowProperty, 5);
                Template.SetValue(Grid.RowProperty, 6);
                Setting.SetValue(Grid.RowProperty, 8);

                Menu.SetValue(Grid.ColumnProperty, 0);
                Account.SetValue(Grid.ColumnProperty, 0);
                Category.SetValue(Grid.ColumnProperty, 0);
                Transaction.SetValue(Grid.ColumnProperty, 0);
                Pret.SetValue(Grid.ColumnProperty, 0);
                Stat.SetValue(Grid.ColumnProperty, 0);
                Template.SetValue(Grid.ColumnProperty, 0);
                Setting.SetValue(Grid.ColumnProperty, 0);

                MainFrame.SetValue(Grid.ColumnProperty, 1);
                MainFrame.SetValue(Grid.RowSpanProperty, 9);
                MainFrame.SetValue(Grid.ColumnSpanProperty, 8);
            }
        }
        #endregion

    }
}
