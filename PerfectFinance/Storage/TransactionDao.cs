using Logic;
using Logic.Dao;
using Logic.Model;
using System.Data.SQLite;
using System.Linq;
using System.Security.Policy;
using System.Security.Principal;

namespace Storage
{
    public class TransactionDao : BaseDao, ITransactionDao
    {

        public void Create(Transaction transaction)
        {
            Dictionary<string, object> transactionParameters = new()
            {
                { "@name", transaction.Name },
                { "@amount", transaction.Amount },
                { "@date", transaction.Date.ToString("yyyy-MM-dd") },
                { "@fkAccount", transaction.Account.Id },
                { "@fkCategory", transaction.Category.Id }
            };

            Connection.Open();
            ExecuteNonQuery(
                "INSERT INTO Transaction(name, amount, date, fkAccount, fkCategory) VALUES(@name, @amount, @date, @fkAccount, @fkCategory)",
                transactionParameters
            );
            Connection.Close();
        }

        public void Update(Transaction transaction)
        {
            Dictionary<string, object> transactionParameters = new()
            {
                { "@idTransaction", transaction.Id },
                { "@name", transaction.Name },
                { "@amount", transaction.Amount },
                { "@date", transaction.Date.ToString("yyyy-MM-dd") },
                { "@fkAccount", transaction.Account.Id },
                { "@fkCategory", transaction.Category.Id }
            };

            Connection.Open();
            ExecuteNonQuery(
                "UPDATE Transaction SET name = @name, amount = @amount, date = @date, fkAccount = @fkAccount, fkCategory = @fkCategory WHERE idTransaction = @idTransaction",
                transactionParameters
            );
            Connection.Close();
        }

        public void Delete(Transaction transaction)
        {
            Dictionary<string, object> transactionParameters = new()
            {
                { "@idTransaction", transaction.Id }
            };

            Connection.Open();
            ExecuteNonQuery(
                "DELETE FROM Transaction WHERE idTransaction = @idTransaction",
                transactionParameters
            );
            Connection.Close();
        }


        public List<Transaction> ListAll()
        {
            List<Transaction> transactions = new();

            Connection.Open();
            var command = Connection.CreateCommand();
            command.CommandText = "SELECT * FROM Transaction";

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    transactions.Add(Reader2Transaction(reader));
                }
            }
            Connection.Close();

            return transactions;
        }

        public List<Transaction> ListByMixed(int day = -1, int month = -1, int year = -1, Category? category = null, Account? account = null)
        {
            List<Transaction> transactions = new();
            Connection.Open();
            var command = Connection.CreateCommand();

            var conditions = new List<string>();
            if (day != -1 && month != -1 && year != -1)
            {
                DateTime targetDate = new(year, month, day);
                string dateString = targetDate.ToString("yyyy-MM-dd");
                conditions.Add("date(date) = date(@date)");
                command.Parameters.AddWithValue("@date", dateString);
            }
            if (month != -1 && year != -1)
            {
                conditions.Add("strftime('%Y', date) = @year AND strftime('%m', date) = @month");
                command.Parameters.AddWithValue("@year", year.ToString());
                command.Parameters.AddWithValue("@month", month.ToString("00"));
            }
            if (category != null)
            {
                conditions.Add("fkCategory = @fkCategory");
                command.Parameters.AddWithValue("@fkCategory", category.Id);
            }
            if (account != null)
            {
                conditions.Add("fkAccount = @fkAccount");
                command.Parameters.AddWithValue("@fkAccount", account.Id);
            }

            command.CommandText = "SELECT * FROM Transaction";
            if (conditions.Count > 0)
            {
                command.CommandText += " WHERE " + string.Join(" AND ", conditions);
            }

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    transactions.Add(Reader2Transaction(reader));
                }
            }
            Connection.Close();

            return transactions;
        }

        public decimal AmountByAccount(User user, int idAccount)
        {
            decimal amount = 0;

            Dictionary<string, object> parameters = new() { { "@idAccount", idAccount }, { "@idUser", user.Id } };

            Connection.Open();
            var reader = ExecuteQuery("SELECT SUM(\"Transaction\".amount) as amount " +
                "FROM \"Transaction\" " +
                "JOIN UserAccount ON \"Transaction\".fkAccount = UserAccount.fkAccount " +
                "JOIN User ON UserAccount.fkUser = User.idUser " +
                "WHERE \"Transaction\".fkAccount = @idAccount AND User.idUser = @idUser", parameters);

            if (reader.Read())
            {
                if (!reader.IsDBNull(reader.GetOrdinal("amount")))
                {
                    amount = Convert.ToDecimal(reader["amount"]);
                }
                else
                {
                    amount = 0; // Return 0 if the value is NULL
                }
            }
            Connection.Close();
            return amount;
        }

        public decimal AmountByCategory(User user, int idCategory)
        {
            decimal amount = 0;

            Dictionary<string, object> parameters = new() { { "@idCategory", idCategory }, { "@idUser", user.Id } };

            Connection.Open();
            var reader = ExecuteQuery("SELECT SUM(\"Transaction\".amount) as amount " +
                "FROM \"Transaction\" " +
                "JOIN UserCategory ON \"Transaction\".fkCategory = UserCategory.fkCategory " +
                "JOIN User ON UserCategory.fkUser = User.idUser " +
                "WHERE \"Transaction\".fkCategory = @idCategory AND User.idUser = @idUser", parameters);

            if (reader.Read())
            {
                if (!reader.IsDBNull(reader.GetOrdinal("amount")))
                {
                    amount = Convert.ToDecimal(reader["amount"]);
                }
                else
                {
                    amount = 0; // Return 0 if the value is NULL
                }
            }
            Connection.Close();
            return amount;
        }

        private static Transaction Reader2Transaction(SQLiteDataReader reader)
        {
            Transaction transaction = new()
            {
                Id = Convert.ToInt32(reader["idTransaction"]),
                Name = Convert.ToString(reader["name"]),
                Amount = Convert.ToDecimal(reader["amount"]),
                Date = Convert.ToDateTime(reader["date"]),
                Account = new Account { Id = Convert.ToInt32(reader["fkAccount"]) },
                Category = new Category { Id = Convert.ToInt32(reader["fkCategory"]) }
            };
            return transaction;
        }
    }
}
