using ApplicationLayer.Interfaces.Repositories;
using DomainLayer.Entities.Stocks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Repositories.Implementations
{
    public class StockPriceHistoryRepository : IStockPriceHistoryRepository
    {
        private readonly StockAppDbContext _context; 
        

        public StockPriceHistoryRepository(StockAppDbContext context) 
        {
            _context = context;
        }

        public async Task AddAsync(StockPriceHistory history)
        {
            await _context.StockPriceHistories.AddAsync(history);
        }

        public async Task AddRangeAsync(IEnumerable<StockPriceHistory> history)
        {
            await _context.StockPriceHistories.AddRangeAsync(history);
        }

        public async Task<IEnumerable<StockPriceHistory>> GetByStockIdAsync(Guid stockId, DateTime from, DateTime to)
        {
            return await _context.StockPriceHistories
                .Where(h => h.StockId == stockId && h.Timestamp >= from && h.Timestamp <= to)
                .OrderBy(h => h.Timestamp)
                .ToListAsync();
        }

        public async Task<StockPriceHistory?> GetLatestAsync(Guid stockId)
        {
            return await _context.StockPriceHistories
                .Where(h => h.StockId == stockId)
                .OrderByDescending(h => h.Timestamp)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
