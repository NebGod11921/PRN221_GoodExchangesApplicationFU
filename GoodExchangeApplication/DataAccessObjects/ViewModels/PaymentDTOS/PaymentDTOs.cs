using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.ViewModels.PaymentDTOS
{
    public class PaymentDTOs
    {
        public int Id { get; set; }
        public DateTime? PaymentDate { get; set; }
        /*public float? Amount { get; set; }*/
        public string? PaymentMethod { get; set; }
    }
}
