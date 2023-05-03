namespace Exceptions.PasswordExceptions
{
    public class PasswordInvalideLength : PasswordException
    {
        public PasswordInvalideLength() : base("Password must contain at least 8 characters") { }
    }
}
