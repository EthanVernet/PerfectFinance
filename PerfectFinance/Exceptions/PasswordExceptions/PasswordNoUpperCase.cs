namespace Exceptions.PasswordExceptions
{
    public class PasswordNoUpperCase : PasswordException
    {
        public PasswordNoUpperCase() : base("Password must contain at least one capital letter") { }
    }
}
