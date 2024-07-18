using DataAccessObjects.ViewModels.PaymentDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.IServices
{
    public interface IPaymentService
    {
        public Task<IEnumerable<PaymentDTOs>> GetPaymentDTOs();
        public Task<PaymentDTOs> GetPaymentDTOs(int id);
    }
}
