namespace Exceptions.EmptyFieldExceptions
{
    public class PhoneFieldException : EmptyFieldException
    {
        public PhoneFieldException() : base("Phone") { }
    }
}
