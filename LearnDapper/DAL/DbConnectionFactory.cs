using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;

namespace LearnDapper.DAL
{
    public class DbConnectionFactory: IDisposable
    {
        private readonly string _connectionString;
        private SqlConnection _sqlConnection;

        public DbConnectionFactory(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("TrainerDbConnection");
            _sqlConnection = new SqlConnection(_connectionString);
        }

        public void Dispose()
        {
            _sqlConnection.Dispose();
        }

        public IDbConnection GetConnection()
        {
            if (_sqlConnection == null)
                _sqlConnection = new SqlConnection(_connectionString);

            return _sqlConnection;
        }
    }
}
