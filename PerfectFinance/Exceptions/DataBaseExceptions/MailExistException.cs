namespace Exceptions.DataBaseExceptions
{
    public class MailExistException : DatabaseUserFieldExist
    {
        public MailExistException() : base("Mail") { }
    }
}
