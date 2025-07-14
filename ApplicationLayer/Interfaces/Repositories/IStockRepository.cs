using DomainLayer.Entities.Stocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Interfaces.Repositories
{
    public interface IStockRepository : IGenericRepository<Stock>
    {
        Task<Stock?> GetStockBySymbolAsync(string symbol);
        Task<IEnumerable<Stock>> GetStocksByExchangeAsync(string exchange);
    }
}
