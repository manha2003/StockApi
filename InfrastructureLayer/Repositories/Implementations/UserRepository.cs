using ApplicationLayer.Interfaces.Repositories;
using DomainLayer.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Repositories.Implementations
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(StockAppDbContext context) : base(context)
        {

        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users
                 .FirstOrDefaultAsync(u => u.Email == email);
        }

         public async Task<User?> GetByUserNameAsync(string userName)
        {
            return await _context.Users
                 .FirstOrDefaultAsync(u => u.UserName == userName);
        }



        public async Task<User> GetByEmailAndTokenAsync(string email, string token)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Email == email && u.EmailConfirmationToken == token);
        }

        public bool ExistsByEmail(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }

        public bool ExistsByUserName(string userName)
        {
            return _context.Users.Any(u => u.UserName == userName);
        }
    }
}
