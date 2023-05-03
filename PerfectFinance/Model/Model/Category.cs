namespace Logic.Model
{
    public class Category : IModel
    {
        public int Id { get => _id; set => _id = value; }
        private int _id;

        public string Name { get => _name; set => _name = value; }
        private string _name;

        public decimal PreviewAmount { get => _previewAmount; set => _previewAmount = value; }
        private decimal _previewAmount;

        public decimal Amount { get; set; } 
        public decimal PositiveAmount { get; }
        public decimal NegativeAmount { get; }
    }
}
