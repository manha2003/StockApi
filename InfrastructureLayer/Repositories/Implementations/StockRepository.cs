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
    public class StockRepository : GenericRepository<Stock>,IStockRepository
    {
        public StockRepository(StockAppDbContext context) : base(context)
        {
        }
        public async Task<Stock> GetStockBySymbolAsync(string symbol)
        {
            return await _context.Stocks.FirstOrDefaultAsync(s => s.Symbol == symbol);
        }
        public async Task<IEnumerable<Stock>> GetStocksByExchangeAsync(string exchange)
        {
            return await _context.Stocks.Where(s => s.Exchange == exchange).ToListAsync();
        }
    }
}
