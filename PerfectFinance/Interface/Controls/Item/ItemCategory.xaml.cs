using Interface.Dialogs;
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

namespace Interface.Controls
{
    /// <summary>
    /// Logique d'interaction pour ItemCategory.xaml
    /// </summary>
    public partial class ItemCategory : UserControl
    {
        private int _id;

        public Category Category
        {
            get
            {
                Category category = new()
                {
                    Id = _id,
                    Name = CategoryName.Content.ToString(),
                    PreviewAmount = Convert.ToDecimal(PreviewAmount.Content.ToString()[..^2]),
                };
                return category;
            }
            set
            {
                Category tmp = value;
                _id = tmp.Id;
                CategoryName.Content = tmp.Name;
                PreviewAmount.Content = tmp.PreviewAmount.ToString() + " €";
                Amount.Content = tmp.Amount.ToString() + " €";
            }
        }

        public ItemCategory()
        {
            InitializeComponent();
        }

        private void Edit_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.ShowUpdateDeleteDialog(TypeDialog.CATEGORY_UPDATE, Category);
        }

        private void Delete_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.ShowUpdateDeleteDialog(TypeDialog.CATEGORY_DELETE, Category);
        }
    }
}
