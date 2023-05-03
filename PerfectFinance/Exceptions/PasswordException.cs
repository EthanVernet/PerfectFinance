namespace Exceptions
{
    public abstract class PasswordException : Exception
    {
        public PasswordException(string message) : base(message) { }
    }
}
