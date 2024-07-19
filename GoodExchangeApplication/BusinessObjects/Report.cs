using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Report : BaseEntity
    {
        public string? ReportTypeName { get; set; }
        public string? Reason {  get; set; }
        public DateTime? CreatedDate { get; set; }

        //Relationship
        
        public int? UserId { get; set; }
        public virtual User? User { get; set; }
        public int? ProductId { get; set; }
        public virtual Product? Product { get; set; }
        public int? PostId { get; set; }
        public virtual Post? Post { get; set; }
    }
}
