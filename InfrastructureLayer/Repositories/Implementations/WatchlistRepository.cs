using ApplicationLayer.Interfaces.Repositories;
using DomainLayer.Entities.Watchlists;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Repositories.Implementations
{
    public class WatchlistRepository : GenericRepository<Watchlist>, IWatchlistRepository
    {
        public WatchlistRepository(StockAppDbContext context) : base(context)
        {

        }

        //get all watchlists for a user
        public async Task<Watchlist?> GetByUserIdAsync(Guid userId)
        {
            return await _context.Watchlists
                .FirstOrDefaultAsync(w => w.UserId == userId);
        }
    }
}
