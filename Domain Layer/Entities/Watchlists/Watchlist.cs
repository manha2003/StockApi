using DomainLayer.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities.Watchlists
{
    public class Watchlist
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }

        public string Name { get; set; }     
        public DateTime CreatedAt { get; set; }

        public ICollection<WatchlistItem>? Items { get; set; }
    }
}
