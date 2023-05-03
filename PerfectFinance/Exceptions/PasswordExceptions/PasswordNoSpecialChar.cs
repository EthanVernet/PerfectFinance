namespace Exceptions.PasswordExceptions
{
    public class PasswordNoSpecialChar : PasswordException
    {
        public PasswordNoSpecialChar() : base("Password must contain at least one special character") { }
    }
}
