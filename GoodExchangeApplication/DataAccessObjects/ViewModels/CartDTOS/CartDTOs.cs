using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.ViewModels.CartDTOS
{
    public class CartDTOs
    {
        public int Id { get; set; }
        public byte[]? Images { get; set; }
        public string? ProductName { get; set; }
        public float? Price { get; set; }
        public int? Quantity { get; set; }
        public float? TotalPrice => Price * Quantity;
    }
}
