using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class TransactionProduct
    {
        public int? TransactionId {  get; set; }
        public int? ProductId { get; set; }
        public virtual Product? Product { get; set; }
        public virtual Transaction? Transaction { get; set; }
    }
}
