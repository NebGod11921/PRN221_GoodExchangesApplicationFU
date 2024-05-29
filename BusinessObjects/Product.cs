using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Product : BaseEntity
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public float? Price {  get; set; }
        public string? Location {  get; set; }
        public byte[]? Image {  get; set; }
        public int? Quantity { get; set; }
        public int? Popularities { get; set; }

        //relationship
        public virtual IEnumerable<UserProduct>? UserProducts { get; set; }
        public virtual IEnumerable<Post>? Posts { get; set; }
        public int? CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        public virtual IEnumerable<Review>? Reviews { get; set; }
        public virtual IEnumerable<Report>? Reports { get; set; }
        public virtual IEnumerable<TransactionProduct>? TransactionProducts { get; set; }
    }
}
