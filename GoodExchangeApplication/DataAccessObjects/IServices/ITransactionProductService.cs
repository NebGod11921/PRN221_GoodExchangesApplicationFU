using DataAccessObjects.ViewModels.TransactionDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.IServices
{
    public interface ITransactionProductService
    {
        public Task<bool> CreateTransactionProducts(List<TransactionProductDTOs> transactionDTOs, int transactionId, List<int> productIds );
        public Task<IEnumerable<TransactionProductDTOs>> GetTransactionProductsById( int transactionId );
    }
}
