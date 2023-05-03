using Logic.Dao;
using Logic.Model;
using System.Data;
using System.Data.SQLite;

namespace Storage
{
    public class PhoneDao : BaseDao, IPhoneDao
    {

        public List<Phone> List()
        {
            List<Phone> phones = new();
            string query = "SELECT idPhoneCode, country, code FROM PhoneCode";

            Connection.Open();
            using (var reader = ExecuteQuery(query))
            {
                while (reader.Read())
                {
                    phones.Add(Reader2Phone(reader));
                }
                reader.Close();
            }
            Connection.Close();
            return phones;
        }

        private Phone Reader2Phone(SQLiteDataReader reader)
        {
            Phone phone = new()
            {
                Id = Convert.ToInt32(reader["idPhoneCode"]),
                Country = reader["country"].ToString(),
                Code = Convert.ToInt32(reader["code"]),
            };
            return phone;
        }
    }
}
