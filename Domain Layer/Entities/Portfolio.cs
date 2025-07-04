using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class Portfolio
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public string Name { get; set; }           
        public string? Description { get; set; }   

        public DateTime CreatedAt { get; set; }

        public ICollection<PortfolioItem>? Items { get; set; }
    }
}
