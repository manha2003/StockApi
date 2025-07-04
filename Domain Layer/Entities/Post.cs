using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DomainLayer.Entities
{
    public class Post
    {
        public Guid Id { get; set; } 
        public Guid UserId { get; set; }
        
        public User User { get; set; } 

        public string Title { get; set; }

        public string? PdfFileName { get; set; }       
        public string? PdfFilePath { get; set; }

        public DateTime CreatedAt{ get; set; }
        public DateTime? UpdatedAt { get; set; }

        //public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        //public ICollection<PostLike> Likes { get; set; } = new List<PostLike>();

    }
}
