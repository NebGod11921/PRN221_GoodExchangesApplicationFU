using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Report : BaseEntity
    {
        public string? Reason {  get; set; }
        public DateTime? CreatedDate { get; set; }

        //Relationship
        public int? ReportTypeId { get; set; }
        public virtual ReportType? ReportType { get; set; }
        public int? UserId { get; set; }
        public virtual User? User { get; set; }
        public int? ProductId { get; set; }
        public virtual Product? Product { get; set; }
    }
}
