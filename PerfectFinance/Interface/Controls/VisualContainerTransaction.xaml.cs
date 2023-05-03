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
    /// Logique d'interaction pour VisualContainerTransaction.xaml
    /// </summary>
    public partial class VisualContainerTransaction : UserControl
    {
        public List<Transaction> Transactions
        {
            get
            {
                List<Transaction> tmp = new();
                foreach (ItemTransaction item in Main.Children)
                {
                    tmp.Add(item.Transaction);
                }
                return tmp;
            }
            set
            {
                List<Transaction> tmp = value;
                Main.Children.Clear();

                foreach (Transaction transaction in tmp)
                {
                    Main.Children.Add(new ItemTransaction() { Transaction = transaction });
                }
            }
        }

        public VisualContainerTransaction()
        {
            InitializeComponent();
        }
    }
}
