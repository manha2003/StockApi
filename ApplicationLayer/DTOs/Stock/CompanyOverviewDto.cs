using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.DTOs.Stock
{
    public class CompanyOverviewDto
    {
        public string Symbol { get; set; }
        public string AssetType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Exchange { get; set; }
        public string Currency { get; set; }
        public decimal? PERatio { get; set; }
        public decimal? BookValue { get; set; }

    }
}
