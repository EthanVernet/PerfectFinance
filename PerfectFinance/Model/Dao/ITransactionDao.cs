using Logic.Model;

namespace Logic.Dao
{
    public interface ITransactionDao
    {
        void Create(Transaction transaction);
        void Update(Transaction transaction);
        void Delete(Transaction transaction);

        List<Transaction> ListAll();
        List<Transaction> ListByMixed(int day = -1, int month = -1, int year = -1, Category category = null, Account account = null);

        decimal AmountByAccount(User user, int idAccount);
        decimal AmountByCategory(User user, int idCategory);
    }
}
