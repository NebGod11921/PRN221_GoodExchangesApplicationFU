using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.ViewModels.ProductDTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public float? Price { get; set; }
        public string? Location { get; set; }
        public byte[]? Image { get; set; }
        public int? Quantity { get; set; }
        public int? Popularities { get; set; }
        public int? CategoryId { get; set; }
    }
}