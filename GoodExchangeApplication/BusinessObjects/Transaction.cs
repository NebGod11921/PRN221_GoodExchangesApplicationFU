using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Transaction : BaseEntity
    {
        public DateTime? TransactionDate {  get; set; }
        public string? ShippingAddress { get; set; }
        public float? TotalAmount {  get; set; }
        public int? Quantity { get; set; }
        public string? Note { get; set; }
        //Relationship
        public int? TransactionTypeId { get; set; }
        public virtual TransactionType? TransactionType { get; set; }
        public int? PaymentId { get; set; }
        public virtual Payment? Payment { get; set; }
        public virtual IEnumerable<TransactionProduct>? TransactionProducts { get; set; }
        public int? UserId { get; set; }
        public virtual User? User { get; set; }
    }
}
