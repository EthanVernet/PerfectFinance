namespace Logic.Model
{
    public class Pret : IModel
    {
        public decimal Amount { get => _amount; set => _amount = value; }
        private decimal _amount;

        public int DurationMonth { get => _durationMonth; set => _durationMonth = value; }
        private int _durationMonth;

        public decimal InterestRate { get => _interestRate; set => _interestRate = value; }
        private decimal _interestRate;

        public Category Category { get => _category; set => _category = value; }
        private Category _category;

        public DateTime StartDate { get => _startDate; set => _startDate = value; }
        private DateTime _startDate;

        public List<Transaction> ToTransactions()
        {
            throw new NotImplementedException();
        }
    }
}
