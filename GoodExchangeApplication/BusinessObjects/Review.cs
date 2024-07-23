using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Review : BaseEntity
    {
        public int? Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime? CreatedDate { get; set; }

        //Relationship
        public int? UserId { get; set; }
        public virtual User? User { get; set; }
      /*  public int? ProductId { get; set; }
        public virtual Product? Product { get; set; }*/
        public int? PostId {  get; set; }
        public virtual Post Post { get; set; }
    }
}
