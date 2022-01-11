using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace LearnDapper.Models
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString = null;

        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Create(User user)
        {
            using(IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "INSERT INTO Users (Name, Age) VALUES(@Name, @Age)";
                db.Execute(sqlQuery, user);
            }
        }

        public User Get(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<User>("SELECT * FROM Users WHERE Id=@id", new { id }).FirstOrDefault();
            }
        }

        public ICollection<User> GetUsers()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<User>("SELECT * FROM Users").ToList();
            }
        }
    }
}
