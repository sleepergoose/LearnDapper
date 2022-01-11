using LearnDapper.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearnDapper.DAL.Repositories
{
    public interface IUserRepository
    {
        Task<User> CreateAsync(User user);
        Task<User> GetAsync(int id);
        Task<ICollection<User>> GetUsersAsync();
    }
}
