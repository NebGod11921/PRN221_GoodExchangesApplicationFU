using AutoMapper;
using BusinessObjects;
using DataAccessObjects.IRepositories;
using DataAccessObjects.IServices;
using DataAccessObjects.ViewModels.TransactionDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentTime _currentTime;

        public TransactionService(IMapper mapper, IUnitOfWork unitOfWork, ICurrentTime currentTime)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _currentTime = currentTime;
        }

        public async Task<TransactionDTOs> CreateTransaction(TransactionDTOs transactionDTOs, int TransactionTypeId)
        {
            try
            {
                var getTransactionTypeId = await _unitOfWork.TransactionType.GetByIdAsync(TransactionTypeId);
                var mapper = _mapper.Map<Transaction>(transactionDTOs);
                if (getTransactionTypeId != null && getTransactionTypeId.Id == 1)
                {
                    mapper.TransactionDate = _currentTime.GetCurrentTime().AddDays(3);

                }
                if (getTransactionTypeId != null && getTransactionTypeId.Id == 2)
                {
                    mapper.TransactionDate = _currentTime.GetCurrentTime().AddDays(1);
                }
                if (getTransactionTypeId != null && getTransactionTypeId.Id == 3)
                {
                    mapper.TransactionDate = _currentTime.GetCurrentTime().AddDays(5);
                }

                mapper.TransactionTypeId = getTransactionTypeId.Id;
                var result =  _unitOfWork.TransactionRepository.AddAsync(mapper);
                var IsSucces = await _unitOfWork.SaveChangeAsync() > 0;
                if (IsSucces)
                {
                    var mappedResult = _mapper.Map<TransactionDTOs>(result);
                    return mappedResult;
                } else
                {
                    return null;
                }





            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<bool> DeleteTransaction(int transactionId)
        {
            throw new NotImplementedException();
        }

        public Task<TransactionDTOs> GetTransaction(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TransactionDTOs>> GetTransactionDTOs()
        {
            throw new NotImplementedException();
        }

        public Task<TransactionDTOs> UpdateTransaction(int transactionId, UpdateTransactionDTOs updateTransactionDTOs)
        {
            throw new NotImplementedException();
        }
    }
}
