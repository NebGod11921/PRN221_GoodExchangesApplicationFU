using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Post : BaseEntity 
    {
        public string? Title { get; set; }
        public string? Description { get; set; }   
        public byte[]? Image { get; set; }
        public DateTime? CreatedDate { get; set; }
       
        //Relationship
        public int? UserId { get; set; }
        public virtual User? User { get; set; }
        public int? ProductId { get; set; }
        public virtual Product? Product { get; set; }
    }
}
