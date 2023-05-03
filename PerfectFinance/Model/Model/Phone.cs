namespace Logic.Model
{
    public class Phone : IModel
    {
        public int Id { get => _id; set => _id = value; }
        private int _id;

        public int Code { get => _code; set => _code = value; }
        private int _code;

        public string Country { get => _country; set => _country = value; }
        private string _country;

        public new string ToString => "+" + Code;
    }
}
