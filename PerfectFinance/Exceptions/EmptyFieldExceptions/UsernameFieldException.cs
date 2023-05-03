namespace Exceptions.EmptyFieldExceptions
{
    public class UsernameFieldException : EmptyFieldException
    {
        public UsernameFieldException() : base("Name") { }
    }
}
