using DomainLayer.Entities.Stocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Interfaces.Repositories
{
    public interface IStockPriceHistoryRepository
    {
        Task AddAsync(StockPriceHistory history);
        Task AddRangeAsync(IEnumerable<StockPriceHistory> history);
        Task<IEnumerable<StockPriceHistory>> GetByStockIdAsync(Guid stockId, DateTime from, DateTime to);
        Task<StockPriceHistory?> GetLatestAsync(Guid stockId);
       Task<bool> SaveChangesAsync();
    }
}
