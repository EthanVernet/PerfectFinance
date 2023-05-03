using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Interface
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region 4PasswordBox
        private void PasswordBox_Loaded(object sender, RoutedEventArgs e)
        {
#pragma warning disable CS8600 // Conversion de littéral ayant une valeur null ou d'une éventuelle valeur null en type non-nullable.
            PasswordBox passwordBox = sender as PasswordBox;
#pragma warning restore CS8600 // Conversion de littéral ayant une valeur null ou d'une éventuelle valeur null en type non-nullable.
#pragma warning disable CS8604 // Existence possible d'un argument de référence null.
            TextBlock placeholder = FindVisualChildByName<TextBlock>(passwordBox, "Placeholder");
#pragma warning restore CS8604 // Existence possible d'un argument de référence null.
            if (placeholder != null)
            {
                placeholder.Visibility = passwordBox.Password.Length > 0 ? Visibility.Collapsed : Visibility.Visible;
            }
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
#pragma warning disable CS8600 // Conversion de littéral ayant une valeur null ou d'une éventuelle valeur null en type non-nullable.
            PasswordBox passwordBox = sender as PasswordBox;
#pragma warning restore CS8600 // Conversion de littéral ayant une valeur null ou d'une éventuelle valeur null en type non-nullable.
#pragma warning disable CS8604 // Existence possible d'un argument de référence null.
            TextBlock placeholder = FindVisualChildByName<TextBlock>(passwordBox, "Placeholder");
#pragma warning restore CS8604 // Existence possible d'un argument de référence null.
            if (placeholder != null)
            {
                placeholder.Visibility = passwordBox.Password.Length > 0 ? Visibility.Collapsed : Visibility.Visible;
            }
        }

        private T FindVisualChildByName<T>(DependencyObject parent, string name) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
#pragma warning disable CS8602 // Déréférencement d'une éventuelle référence null.
                if (child is T typedChild && (typedChild as FrameworkElement).Name == name)
                {
                    return typedChild;
                }
#pragma warning restore CS8602 // Déréférencement d'une éventuelle référence null.

                T resultInChildren = FindVisualChildByName<T>(child, name);
                if (resultInChildren != null)
                {
                    return resultInChildren;
                }
            }

#pragma warning disable CS8603 // Existence possible d'un retour de référence null.
            return null;
#pragma warning restore CS8603 // Existence possible d'un retour de référence null.
        }

        #endregion
    }
}
