using Logic.Model;

namespace Logic.Dao
{
    public interface IUserDao
    {
        bool UsernameExist(string username);
        bool MailExist(string mail);
        bool PhoneNumberExist(string phone);

        void Create(User user);
        void Update(User user);
        void Delete(User user);
        User Read(string idValue, string password);
    }
}
