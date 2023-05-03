namespace Exceptions.EmptyFieldExceptions
{
    public class MailFieldException : EmptyFieldException
    {
        public MailFieldException() : base("Mail") { }
    }
}
