using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class TransactionType : BaseEntity
    {
        public string? TypeName {  get; set; }
        public string? Description { get; set; }
        //Relationship
        public virtual IEnumerable<Transaction>? Transactions { get; set;}
    }
}
