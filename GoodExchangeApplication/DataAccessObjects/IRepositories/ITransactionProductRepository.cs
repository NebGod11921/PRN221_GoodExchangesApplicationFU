using BusinessObjects;
using DataAccessObjects.ViewModels.TransactionDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.IRepositories
{
    public interface ITransactionProductRepository
    {
        public Task<bool> AddTransactionProduct(List<TransactionProduct> transactionProducts, int transactionId, List<int> productIds);

        public Task<IEnumerable<TransactionProduct>> GetTransactionProductsById(int transactionId);
        public Task<IEnumerable<Product>> GetProductsByTransactionIdAsync(int transactionId);
    }
}
