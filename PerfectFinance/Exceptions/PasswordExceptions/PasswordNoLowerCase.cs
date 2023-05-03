namespace Exceptions.PasswordExceptions
{
    public class PasswordNoLowerCase : PasswordException
    {
        public PasswordNoLowerCase() : base("Password must contain at least one lowercase letter") { }
    }
}
