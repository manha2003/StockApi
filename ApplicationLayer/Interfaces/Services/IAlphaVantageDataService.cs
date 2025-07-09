using ApplicationLayer.DTOs.Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Interfaces.Services
{
    public interface IAlphaVantageDataService   
    {
        Task<CompanyOverviewDto?> GetCompanyOverviewAsync(string symbol);
    }
}
