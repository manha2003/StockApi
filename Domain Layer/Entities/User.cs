using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public string UserName { get; set; }
        public string Bio { get; set; }

        public DateTime CreatedAt { get; set; }

        
        public ICollection<Portfolio>? Portfolios { get; set; }
        public ICollection<Watchlist>? Watchlists { get; set; }
        //public ICollection<Order>? Orders { get; set; }
        //public ICollection<Post>? Posts { get; set; }
        //public ICollection<PostLike>? Likes { get; set; }


        //public ICollection<UserFollower>? Followers { get; set; }    // who follows me
        //public ICollection<UserFollower>? Following { get; set; }    // who i follow
    }
}
