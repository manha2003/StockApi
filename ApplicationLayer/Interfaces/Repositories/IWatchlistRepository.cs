using DomainLayer.Entities.Watchlists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Interfaces.Repositories
{
    public interface IWatchlistRepository : IGenericRepository<Watchlist>
    {
         Task<Watchlist?> GetByUserIdAsync(Guid userId);
    }
}
