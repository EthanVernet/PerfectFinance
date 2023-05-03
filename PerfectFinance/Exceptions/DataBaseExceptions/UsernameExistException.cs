namespace Exceptions.DataBaseExceptions
{
    public class UsernameExistException : DatabaseUserFieldExist
    {
        public UsernameExistException() : base("Username") { }
    }
}
