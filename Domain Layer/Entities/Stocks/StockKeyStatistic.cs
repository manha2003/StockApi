using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities.Stocks
{
    public class StockKeyStatistic
    {
        public int Id { get; set; }

        public int StockId { get; set; }
        public Stock Stock { get; set; } = null!;

        public decimal? PERatio { get; set; }
        public decimal? PEG { get; set; }
        public decimal? ROE { get; set; }
        public decimal? ROA { get; set; }
        public decimal? ProfitMargin { get; set; }
        public decimal? OperatingMargin { get; set; }
        public decimal? DebtToEquity { get; set; }
        public decimal? CurrentRatio { get; set; }

        public decimal? EarningsPerShare { get; set; }
        public decimal? Revenue { get; set; }
        public decimal? GrossProfit { get; set; }
        public decimal? EBITDA { get; set; }

        public decimal? DividendYield { get; set; }
        public decimal? DividendPerShare { get; set; }
        public DateTime? DividendDate { get; set; }

        public decimal? MarketCap { get; set; }
        public decimal? BookValue { get; set; }
        public decimal? PriceToBook { get; set; }

        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
    }
}
