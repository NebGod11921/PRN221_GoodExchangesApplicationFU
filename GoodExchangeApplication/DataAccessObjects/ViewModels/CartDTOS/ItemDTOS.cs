using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.ViewModels.CartDTOS
{
    public class ItemDTOS
    {
        public int Id { get; set; }
        public int cartId { get; set; }
        public int productId { get; set; }
        public int quanity { get; set; }
        
    }
}
