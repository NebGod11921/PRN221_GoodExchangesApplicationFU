using BusinessObjects;
using DataAccessObjects.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.Services
{
    public class TransactionService: ITransactionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TransactionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Transaction>> ViewListOfTransaction()
        {
            return await _unitOfWork.TransactionRepository.ViewListOfTransaction();
        }
    }
}
