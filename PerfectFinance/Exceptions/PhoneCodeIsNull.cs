namespace Exceptions
{
    public class PhoneCodeIsNull : Exception
    {
        public PhoneCodeIsNull() : base("The phone Code of your country was not selected !") { }
    }
}
