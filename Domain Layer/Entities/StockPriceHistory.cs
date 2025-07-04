using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class StockPriceHistory
    {
        public Guid Id { get; set; }

        public Guid StockId { get; set; }
        public Stock Stock { get; set; }

        public DateTime Timestamp { get; set; }

        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }
        public long Volume { get; set; }
    }

    
}
