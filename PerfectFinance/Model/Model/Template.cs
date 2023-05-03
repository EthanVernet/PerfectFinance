namespace Logic.Model
{
    public class Template : IModel
    {
        public int Id { get => _id; set => _id = value; }
        private int _id;

        public List<Account> Accounts { get => _accounts; set => _accounts = value; }
        private List<Account> _accounts = new();

        public List<Category> Categories { get => _categories; set => _categories = value; }
        private List<Category> _categories = new();
    }
}
