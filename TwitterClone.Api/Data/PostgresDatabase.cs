using Npgsql;

namespace TwitterClone.Api.Data
{
    public static class PostgresDatabase
    {
        public static void EnsureDatabaseExists(string connectionString)
        {
            var builder = new NpgsqlConnectionStringBuilder(connectionString);
            var databaseName = builder.Database;
            if (string.IsNullOrWhiteSpace(databaseName))
            {
                throw new InvalidOperationException("Connection string is missing a Database name.");
            }

            builder.Database = "postgres";

            using var connection = new NpgsqlConnection(builder.ConnectionString);
            connection.Open();

            using (var existsCommand = new NpgsqlCommand("SELECT 1 FROM pg_database WHERE datname = @name", connection))
            {
                existsCommand.Parameters.AddWithValue("name", databaseName);
                if (existsCommand.ExecuteScalar() is not null)
                {
                    return;
                }
            }

            using var createCommand = new NpgsqlCommand($"CREATE DATABASE \"{databaseName.Replace("\"", "")}\"", connection);
            createCommand.ExecuteNonQuery();
        }
    }
}
