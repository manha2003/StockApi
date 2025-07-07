using DomainLayer.Entities.Stocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities.Watchlists
{
    public class WatchlistItem
    {
        public Guid Id { get; set; }

        public Guid WatchlistId { get; set; }
        public Watchlist Watchlist { get; set; }

        public Guid StockId { get; set; }
        public Stock Stock { get; set; }

        public DateTime AddedAt { get; set; }
    }
}
