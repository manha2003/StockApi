using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities.Stocks
{
    public class StockKeyStatistic
    {
        public Guid Id { get; set; }

        public Guid StockId { get; set; }
        public Stock Stock { get; set; }

        public decimal? PERatio { get; set; }
        public decimal? PEG { get; set; }
        public decimal? EPS { get; set; }
        public decimal? ROE { get; set; }
        public decimal? ROA { get; set; }
        public string? Descripstion { get; set; }
        public decimal? ProfitMargin { get; set; }
        public decimal? OperatingMargin { get; set; }
        public decimal? DebtToEquity { get; set; }
        public decimal? CurrentRatio { get; set; }
      
        public decimal? FiftyTwoWeekHigh { get; set; }
        public decimal? FiftyTwoWeekLow { get; set; }
        public decimal? FiftyDayMovingAverage { get; set; }
        public decimal? TwoHundredDayMovingAverage { get; set; }

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
