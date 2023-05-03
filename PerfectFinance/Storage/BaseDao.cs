using System.Data.SQLite;

namespace Storage
{
    public class BaseDao
    {
        /// <summary>
        /// Méthode représantant la connection à la base de données 
        /// </summary>
        private readonly SQLiteConnection _connection;
        protected SQLiteConnection Connection { get => _connection; }

        /// <summary>
        /// Constructeur de la classe BaseDAO
        /// </summary>
        /// <param name="fileName"></param>
        public BaseDao()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string databaseFileName = "database.db";
            string databasePath = Path.Combine(basePath, databaseFileName);

            _connection = new SQLiteConnection($"Data Source={databasePath}");
        }

        /// <summary>
        /// Méthode éxécutant une requête ne retournant pas de valeur
        /// </summary>
        /// <param name="query"></param>
        protected void ExecuteNonQuery(string query , Dictionary<string, object>? parameters = null)
        {
            var command = _connection.CreateCommand();
            command.CommandText = query;
            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }
            }
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Méthode éxécutant une requête retournant une valeur
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        protected SQLiteDataReader ExecuteQuery(string query, Dictionary<string, object>? parameters = null)
        {
            var command = _connection.CreateCommand();
            command.CommandText = query;

            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }
            }
            return command.ExecuteReader();
        }

        protected object ExecuteScalar(string query, Dictionary<string, object>? parameters = null)
        {
            var command = _connection.CreateCommand();
            command.CommandText = query;

            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }
            }
            return command.ExecuteScalar();
        }
    }
}