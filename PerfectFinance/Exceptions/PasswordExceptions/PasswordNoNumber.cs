namespace Exceptions.PasswordExceptions
{
    public class PasswordNoNumber : PasswordException
    {
        public PasswordNoNumber() : base("Password must contain at least one number") { }
    }
}
