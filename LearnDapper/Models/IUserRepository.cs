using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnDapper.Models
{
    public interface IUserRepository
    {
        void Create(User user);
        User Get(int id);
        ICollection<User> GetUsers();
    }
}
