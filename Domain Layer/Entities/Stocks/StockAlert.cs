using DomainLayer.Entities.Users;
using DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities.Stocks
{
    public class StockAlert
    {
        public int Id { get; set; }

        
        public int StockId { get; set; }
        public Stock Stock { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        
        public AlertType Type { get; set; }

      
        public decimal TargetPrice { get; set; }
        public decimal? PercentageChange { get; set; }

        public string? Message { get; set; }


        public bool IsTriggered { get; set; } = false;
        public DateTime? TriggeredAt { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
