namespace Exceptions
{
    public class DatabaseUserFieldExist : Exception
    {
        public DatabaseUserFieldExist(string fieldName) : base(String.Format("{0} is already used", fieldName)) { }
    }
}
