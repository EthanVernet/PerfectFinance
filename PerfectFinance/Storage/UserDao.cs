using Exceptions;
using Logic.Dao;
using Logic.Model;
using System.Data.SQLite;

namespace Storage
{
    public class UserDao : BaseDao, IUserDao
    {
        private User _user;

        public bool UsernameExist(string username)
        {

            Connection.Open();
            Dictionary<string, object> parameters = new() { { "@username", username } };
            var reader = ExecuteQuery("SELECT username FROM User WHERE username = @username", parameters);
            if (!reader.Read()) { Connection.Close(); return false; }
            Connection.Close();
            return true;
        }

        public bool MailExist(string mail)
        {

            Connection.Open();
            Dictionary<string, object> parameters = new() { { "@mail", mail } };
            var reader = ExecuteQuery("SELECT mail FROM User WHERE mail = @mail", parameters);
            if (!reader.Read()) { Connection.Close(); return false; }
            Connection.Close();
            return true;
        }

        public bool PhoneNumberExist(string phone)
        {
            Connection.Open();
            Dictionary<string, object> parameters = new() { { "@phone", phone } };
            var reader = ExecuteQuery("SELECT phone FROM User WHERE phone = @phone", parameters);
            if (!reader.Read()) { Connection.Close(); return false; }
            Connection.Close();
            return true;
        }


        public void Create(User user)
        {
            Dictionary<string, object> parameters = new()
            {
                { "@username", user.Username },
                { "@password", user.Password },
                { "@email", user.Email },
                { "@fkPhoneCode", user.Phone.Id },
                { "@phone", user.PhoneNumber }
            };

            Connection.Open();
            ExecuteNonQuery
            (
                "INSERT INTO User(username,hashPassword,mail,fkPhoneCode,phone) VALUES(@username, @password, @email, @fkPhoneCode, @phone)",
                parameters
            );
            Connection.Close();
        }

        public void Update(User user) { throw new NotImplementedException(); }

        public void Delete(User user)
        {
            //Dictionary<string, object> parameters = new()
            //{
            //    { "@username", user.Username },
            //    { "@password", user.Password },
            //    { "@email", user.Email },
            //    { "@fkPhoneCode", user.Phone.Id },
            //    { "@phone", user.PhoneNumber }
            //};
        }

        public User Read(string username, string password)
        {
            if (_user is null)
            {
                Dictionary<string, object> parameters = new() { { "@username", username }, { "@password", password } };

                Connection.Open();
                var reader = ExecuteQuery
                (
                    "SELECT User.idUser, User.username, User.hashPassword, User.mail, User.fkPhoneCode, User.phone, PhoneCode.idPhoneCode, PhoneCode.code, PhoneCode.country " +
                    "FROM User " +
                    "JOIN PhoneCode ON User.fkPhoneCode = PhoneCode.idPhoneCode " +
                    "WHERE User.username = @username AND User.hashPassword = @password", 
                    parameters
                );

                if (!reader.Read())
                {
                    Connection.Close();
                    throw new WrongUsernameOrPassword();
                }

                User user = Reader2User(reader);

                Connection.Close();
                _user = user;
            }
            return _user;

        }

        private static User Reader2User(SQLiteDataReader reader)
        {
            User user = new()
            {
                Id = Convert.ToInt32(reader["idUser"]),
                Username = Convert.ToString(reader["username"]),
                Password = Convert.ToString(reader["hashPassword"]),
                Email = Convert.ToString(reader["mail"]),
                PhoneNumber = Convert.ToString(reader["phone"]),
                Phone = new()
                {
                    Id = Convert.ToInt32(reader["idPhoneCode"]),
                    Code = Convert.ToInt32(reader["code"]),
                    Country = Convert.ToString(reader["country"])
                }
            };

            return user;
        }
    }
}
