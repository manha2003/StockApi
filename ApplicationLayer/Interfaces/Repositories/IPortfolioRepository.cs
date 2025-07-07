using DomainLayer.Entities.Portfolios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Interfaces.Repositories
{
    public interface IPortfolioRepository : IGenericRepository<Portfolio>
    {
        Task<Portfolio?> GetByUserIdAsync(Guid userId);
     
    }
}
