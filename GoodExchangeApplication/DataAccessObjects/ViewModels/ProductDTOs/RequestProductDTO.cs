using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.ViewModels.ProductDTOs
{
    public class RequestProductDTO: BaseEntity
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public float? Price { get; set; }
        public string? Location { get; set; }
        public byte[]? Image { get; set; }
        public int? Quantity { get; set; }
    }
}
