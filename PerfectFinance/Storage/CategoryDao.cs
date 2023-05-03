using Logic.Dao;
using Logic.Model;
using System.Data.SQLite;
using System.Security.Principal;

namespace Storage
{
    public class CategoryDao : BaseDao, ICategoryDao
    {
        private List<Category>? _categories; 

        public void Create(Category category, User user)
        {
            Dictionary<string, object> accountParameters = new()
            {
                { "@name", category.Name },
                { "@previewAmount", category.PreviewAmount },
            };

            Connection.Open();
            ExecuteNonQuery
            (
                "INSERT INTO Category(name, previewAmount) VALUES(@name, @previewAmount)",
                accountParameters
            );

            long newAccountId = (long)ExecuteScalar("SELECT last_insert_rowid()");
            Connection.Close();

            Dictionary<string, object> userAccountParameters = new()
            {
                { "@fkUser", user.Id },
                { "@fkCategory", newAccountId },
            };

            Connection.Open();
            ExecuteNonQuery
            (
                "INSERT INTO UserCategory(fkUser, fkCategory) VALUES(@fkUser, @fkcategory)",
                userAccountParameters
            );
            Connection.Close();
            _categories = null;
        }

        public void Update(Category category, User user)
        {
            Dictionary<string, object> parameters = new()
            {
                { "@idCategory", category.Id },
                { "@name", category.Name },
                {"@previewAmount", category.PreviewAmount },
            };

            Connection.Open();
            ExecuteNonQuery
            (
                "UPDATE Category SET name = @name, previewAmount = @previewAmount WHERE idCategory = @idCategory",
                parameters
            );
            Connection.Close();
            _categories = null;
        }

        public void Delete(Category category, User user)
        {
            Dictionary<string, object> parameters = new()
            {
                { "@fkCategory", category.Id },
                { "@fkUser", user.Id }
            };

            Connection.Open();
            ExecuteNonQuery
            (
                "DELETE FROM UserCategory WHERE fkCategory = @fkCategory AND fkUser = @fkUser",
                parameters
            );
            Connection.Close();
            _categories = null;
        }

        public List<Category> List(User user)
        {
            if (_categories is null)
            {
                Connection.Open();
                List<Category> accounts = new();

                var command = Connection.CreateCommand();
                command.CommandText =
                    "SELECT Category.idcategory, Category.name, Category.previewAmount " +
                    "FROM Category " +
                    "JOIN UserCategory ON category.idcategory = UserCategory.fkCategory " +
                    "JOIN User ON User.idUser = UserCategory.fkUser " +
                    "WHERE idUser = @idUser";
                command.Parameters.AddWithValue("@idUser", user.Id);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        accounts.Add(Reader2Category(reader));
                    }
                }
                Connection.Close();
                _categories = accounts;
            }
            return _categories;
        }

        private static Category Reader2Category(SQLiteDataReader reader)
        {
            Category category = new()
            {
                Id = Convert.ToInt32(reader["idCategory"]),
                Name = Convert.ToString(reader["name"]),
                PreviewAmount = Convert.ToDecimal(reader["previewAmount"])
            };
            return category;
        }
    }
}
