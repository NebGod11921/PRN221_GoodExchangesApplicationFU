using AutoMapper;
using BusinessObjects;
using DataAccessObjects.IServices;
using DataAccessObjects.UnitOfWork;
using DataAccessObjects.ViewModels.TransactionDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.Services
{
    public class TransactionProductService : ITransactionProductService
    { 
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TransactionProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }



        public async Task<bool> CreateTransactionProducts(List<TransactionProductDTOs> transactionDTOs, int transactionId, List<int> productIds)
        {
            try
            {
                var mapping = _mapper.Map<List<TransactionProduct>>(transactionDTOs);
                

                var result = await _unitOfWork.TransactionProductRepository.AddTransactionProduct(mapping, transactionId, productIds);
                if (result == true)
                {
                    return true;
                }else
                {
                    return false;
                }
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<TransactionProductDTOs>> GetTransactionProductsById(int transactionId)
        {
            try
            {
                var result = await _unitOfWork.TransactionProductRepository.GetTransactionProductsById(transactionId);
                if (result != null)
                {
                    var mappedResult =  _mapper.Map<IEnumerable<TransactionProductDTOs>>(result);
                    return mappedResult;
                } else
                {
                    return new List<TransactionProductDTOs>();
                }

            }catch  (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
