namespace Logic.Model
{
    public class Transaction : IModel
    {
        public int Id { get => _id; set => _id = value; }
        private int _id;

        public Nature Nature { get => _nature; set => _nature = value; }
        private Nature _nature;

        public Account Account { get => _account; set => _account = value; }
        private Account _account;

        public DateTime Date { get => _date; set => _date = value; }
        private DateTime _date;

        public string Name { get => _name; set => _name = value; }
        private string _name;

        public decimal Amount { get => _amount; set => _amount = value; }
        private decimal _amount;

        public Category Category { get => _category; set => _category = value; }
        private Category _category;

        public bool IsPositive { get => _isPositive; set => _isPositive = value; }
        private bool _isPositive;

        public bool IsMensual { get => _isMensual; set => _isMensual = value; }
        private bool _isMensual;

        public bool IsAnnual { get => _isAnnual; set => _isAnnual = value; }
        private bool _isAnnual;
    }
}