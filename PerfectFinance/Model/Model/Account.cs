using System.Runtime.CompilerServices;

namespace Logic.Model
{
    public class Account : IModel
    {
        public int Id { get => _id; set => _id = value; }
        private int _id;

        public string Name { get => _name; set => _name = value; }
        private string _name;

        public decimal Amount { get => _amount; set => _amount = value; }
        private decimal _amount;
    }
}
