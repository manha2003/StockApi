using DomainLayer.Entities.Portfolios;
using DomainLayer.Entities.Watchlists;
using DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities.Stocks
{
   
    public class Stock
    {
        public Guid Id { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public string Exchange { get; set; } 
        public string Sector { get; set; }
        public string Industry { get; set; }
        public Currency Currency { get; set; }
        public bool IsActive { get; set; }
        public decimal? LastestPrice { get; set; }
        public DateTime? LastPriceUpdatedAt { get; set; }

        public ICollection<PortfolioItem> PortfolioItems { get; set; }
        //public ICollection<Order> Orders { get; set; }
        public ICollection<StockPriceHistory> PriceHistory { get; set; }
        public ICollection<WatchlistItem> WatchlistItems { get; set; }
        public StockKeyStatistic KeyStatistic { get; set; }





    }
}
