namespace Exceptions
{
    public class EmptyFieldException : Exception
    {
        public EmptyFieldException(string propertyName) : base(String.Format("{0} field is empty.", propertyName)) { }
    }
}