namespace Exceptions.EmptyFieldExceptions
{
    public class PasswordFieldException : EmptyFieldException
    {
        public PasswordFieldException() : base("Password") { }
    }
}
