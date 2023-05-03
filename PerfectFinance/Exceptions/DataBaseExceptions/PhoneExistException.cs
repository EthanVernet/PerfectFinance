namespace Exceptions.DataBaseExceptions
{
    public class PhoneExistException : DatabaseUserFieldExist
    {
        public PhoneExistException() : base("Phone number") { }
    }
}
