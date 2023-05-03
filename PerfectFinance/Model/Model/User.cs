using Exceptions;
using Exceptions.EmptyFieldExceptions;
using Exceptions.PasswordExceptions;
using System.Text.RegularExpressions;
 
namespace Logic.Model
{
    public class User
    {
        public int Id { get => _id; set => _id = value; }
        private int _id;

        public string Username
        {
            get => _username;
            set
            {
                if (string.IsNullOrEmpty(value)) throw new UsernameFieldException();
                _username = value;
            }
        }

        private string _username;

        public string Password
        {
            get => _password;
            set
            {
                if (string.IsNullOrEmpty(value)) throw new PasswordFieldException();
                if (value.Length < 8) throw new PasswordInvalideLength();
                if (!Regex.IsMatch(value, "[a-z]")) throw new PasswordNoLowerCase();
                if (!Regex.IsMatch(value, "[A-Z]")) throw new PasswordNoUpperCase();
                if (!Regex.IsMatch(value, @"\d")) throw new PasswordNoNumber();
                if (!Regex.IsMatch(value, @"[!@#$%^&*(),.?""':{}|<>]")) throw new PasswordNoSpecialChar();

                _password = value;
            }
        }
        private string _password;

        public string Email
        {
            get => email;
            set
            {
                if (string.IsNullOrEmpty(value)) throw new MailFieldException();
                email = value;
            }
        }
        private string email;

        public Phone Phone
        {
            get => _phone;
            set
            {
                if (value is null) throw new PhoneCodeIsNull();
                _phone = value;
            }
        }
        private Phone _phone;


        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                if (string.IsNullOrEmpty(value)) throw new PhoneFieldException();
                _phoneNumber = value;
            }
        }
        private string _phoneNumber;

    }
}
