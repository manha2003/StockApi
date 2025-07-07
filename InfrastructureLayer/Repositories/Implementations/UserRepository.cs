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
    }
}
