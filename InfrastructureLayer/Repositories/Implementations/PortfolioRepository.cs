using ApplicationLayer.Interfaces.Repositories;
using DomainLayer.Entities.Portfolios;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Repositories.Implementations
{
    public class PortfolioRepository : GenericRepository<Portfolio>, IPortfolioRepository
    {
        public PortfolioRepository(StockAppDbContext context) : base(context)
        {

        }

        // get all portfolios for a user
        public async Task<Portfolio?> GetByUserIdAsync(Guid userId)
        {
            return await _context.Portfolios
                .FirstOrDefaultAsync(p => p.UserId == userId);
        }
    }
}