using Dapper;
using LearnDapper.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace LearnDapper.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString = null;

        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<User> CreateAsync(User user)
        {
            using(IDbConnection db = new SqlConnection(_connectionString))
            {
                const string sql =
                    @"INSERT INTO Users (
                        Name, 
                        Age) 
                    VALUES (
                        @Name, 
                        @Age)
                    SELECT CAST(SCOPE_IDENTITY() as int)";


                var id = await db.QueryFirstAsync<int>(sql, user);

                user.Id = id;

                return user;
            }
        }

        public async Task<User> GetAsync(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return (await db.QueryAsync<User>("SELECT * FROM Users WHERE Id=@id", new { id })).FirstOrDefault();
            }
        }

        public async Task<ICollection<User>> GetUsersAsync()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return (await db.QueryAsync<User>("SELECT * FROM Users")).ToList();
            }
        }
    }
}
