using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities.Stocks
{
    public class StockPriceHistory
    {
        public Guid StockHistoryId { get; set; }

        public Guid StockId { get; set; }
        public Stock Stock { get; set; }

        public DateTime Timestamp { get; set; }

        public decimal OpenPrice { get; set; }
        public decimal HighPrice { get; set; }
        public decimal LowPrice { get; set; }
        public decimal ClosePrice { get; set; }
        public long Volume { get; set; }
    }

    
}
