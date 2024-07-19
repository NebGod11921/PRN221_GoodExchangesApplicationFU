using BusinessObjects;
using DataAccessObjects.ViewModels.TransactionDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.IRepositories
{
    public interface ITransactionRepo : IGenericRepository<Transaction>
    {
        Task<PagingTransaction<Transaction>> GetTransactionByUserID(int userId, int pageNumber, int pageSize);
    }
}
