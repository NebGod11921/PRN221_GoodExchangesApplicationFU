using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Payment : BaseEntity
    {
        public DateTime? PaymentDate { get; set; }  
        public float? Amount {  get; set; }
        public string? PaymentMethod {  get; set; }

        //Relationship
        public virtual IEnumerable<Payment>? Payments { get; set; }
    }
}
