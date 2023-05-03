using Logic.Dao;
using Logic.Model;
using System.Data.SQLite;
using System.IO.Pipes;

namespace Storage
{
    public class AccountDao : BaseDao, IAccountDao
    {
        private List<Account>? _accounts;

        public void Create(Account account, User user)
        {
            Dictionary<string, object> accountParameters = new()
            {
                { "@name", account.Name },
            };

            Connection.Open();
            ExecuteNonQuery
            (
                "INSERT INTO Account(name) VALUES(@name)",
                accountParameters
            );

            long newAccountId = (long)ExecuteScalar("SELECT last_insert_rowid()");
            Connection.Close();

            Dictionary<string, object> userAccountParameters = new()
            {
                { "@fkUser", user.Id },
                { "@fkAccount", newAccountId },
            };

            Connection.Open();
            ExecuteNonQuery
            (
                "INSERT INTO UserAccount(fkUser, fkAccount) VALUES(@fkUser, @fkAccount)",
                userAccountParameters
            );
            Connection.Close();
            _accounts = null;
        }

        public void Update(Account account, User user)
        {
            Dictionary<string, object> parameters = new()
            {
                { "@idAccount", account.Id },
                { "@name", account.Name },
            };

            Connection.Open();
            ExecuteNonQuery
            (
                "UPDATE Account SET name = @name WHERE idAccount = @idAccount",
                parameters
            );
            Connection.Close();
            _accounts = null;
        }


        public void Delete(Account account, User user)
        {
            Dictionary<string, object> parameters = new()
            {
                { "@fkAccount", account.Id },
                { "@fkUser", user.Id }
            };

            Connection.Open();
            ExecuteNonQuery
            (
                "DELETE FROM UserAccount WHERE fkAccount = @fkAccount AND fkUser = @fkUser",
                parameters
            );
            Connection.Close();
            _accounts = null;
        }


        public List<Account> List(User user)
        {
            if (_accounts is null)
            {
                Connection.Open();
                List<Account> accounts = new();

                var command = Connection.CreateCommand();
                command.CommandText = 
                    "SELECT Account.idAccount, Account.name " +
                    "FROM Account " +
                    "JOIN UserAccount ON Account.idAccount = UserAccount.fkAccount " + 
                    "JOIN User ON User.idUser = UserAccount.fkUser " +
                    "WHERE idUser = @idUser";
                command.Parameters.AddWithValue("@idUser", user.Id);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        accounts.Add(Reader2Account(reader));
                    }
                }
                Connection.Close();
                _accounts = accounts;
            }
            return _accounts;
        }

        private static Account Reader2Account(SQLiteDataReader reader)
        {
            Account account = new()
            {
                Id = Convert.ToInt32(reader["idAccount"]),
                Name = Convert.ToString(reader["name"]),
            };
            return account;
        }
    }
}
