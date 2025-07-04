using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class PortfolioItem
    {
        public Guid Id { get; set; }
        public Guid PortfolioId { get; set; }
        public Portfolio Portfolio { get; set; }

        public Guid StockId { get; set; }
        public Stock Stock { get; set; }

        public decimal? Quantity { get; set; }
        public decimal? AvgBuyPrice { get; set; }
    }
}
    