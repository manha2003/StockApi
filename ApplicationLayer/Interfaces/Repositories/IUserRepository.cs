using DomainLayer.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Interfaces.Repositories
{
    public interface IUserRepository : IGenericRepository <User>
    {
        Task<User?> GetByEmailAsync(string email);
        bool ExistsByEmail(string email);
        bool ExistsByUserName(string username);
        Task<User> GetByEmailAndTokenAsync(string email, string token);
    }
}
