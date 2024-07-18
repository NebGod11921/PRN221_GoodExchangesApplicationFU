using DataAccessObjects.ViewModels.TransactionDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.IServices
{
    public interface ITransactionService
    {
        public Task<IEnumerable<TransactionDTOs>> GetTransactionDTOs();
        public Task<TransactionDTOs> GetTransaction(int id);
        public Task<IEnumerable<TransactionDTOs>> GetTransactionByUserID(int userId);
        public Task<TransactionDTOs> CreateTransaction(TransactionDTOs transactionDTOs, int TransactionTypeId);
        public Task<UpdateTransactionDTOs> UpdateTransaction(int transactionId, UpdateTransactionDTOs updateTransactionDTOs);
        public Task<bool> DeleteTransaction(int transactionId);
       
    }
}
