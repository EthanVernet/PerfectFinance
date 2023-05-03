using Logic.Model;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Interface.Controls
{
    /// <summary>
    /// Logique d'interaction pour VisualContainerAccount.xaml
    /// </summary>
    public partial class VisualContainerAccount : UserControl
    {
        private User _user;
        public User User { get => _user; set => _user = value; }

        public List<Account> Accounts
        {
            get
            {
                List<Account> tmp = new();
                foreach (ItemAccount item in Main.Children)
                {
                    tmp.Add(item.Account);
                }
                return tmp;
            }
            set
            {
                List<Account> tmp = value;
                Main.Children.Clear();

                foreach (Account account in tmp)
                {
                    Main.Children.Add(new ItemAccount() { Account = account });
                }
            }
        }

        public VisualContainerAccount()
        {
            InitializeComponent();
        }
    }
}
