using Logic.Model;

namespace Logic.Dao
{
    public interface IAccountDao
    {
        void Create(Account account, User user);
        void Update(Account account, User user);
        void Delete(Account account, User user);
        List<Account> List(User user);
    }
}
