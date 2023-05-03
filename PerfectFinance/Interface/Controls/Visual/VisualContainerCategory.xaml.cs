using Logic.Model;
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
    /// Logique d'interaction pour VisualContainerCategory.xaml
    /// </summary>
    public partial class VisualContainerCategory : UserControl
    {
        public List<Category> Categories
        {
            get
            {
                List<Category> tmp = new();
                foreach (ItemCategory item in Main.Children)
                {
                    tmp.Add(item.Category);
                }
                return tmp;
            }
            set
            {
                List<Category> tmp = value;
                Main.Children.Clear();

                foreach (Category category in tmp)
                {
                    Main.Children.Add(new ItemCategory() { Category = category });
                }
            }
        }

        public VisualContainerCategory()
        {
            InitializeComponent();
        }
    }
}
