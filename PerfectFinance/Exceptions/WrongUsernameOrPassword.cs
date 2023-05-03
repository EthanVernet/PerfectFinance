namespace Exceptions
{
    public class WrongUsernameOrPassword : Exception
    {
        public WrongUsernameOrPassword() : base("Username or Password is incorrect") { }
    }
}
