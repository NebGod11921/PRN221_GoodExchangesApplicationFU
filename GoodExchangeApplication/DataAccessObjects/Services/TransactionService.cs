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
                await _unitOfWork.TransactionRepository.AddAsync(mapper);
                var IsSucces = await _unitOfWork.SaveChangeAsync() > 0;
                if (IsSucces)
                {
                    var mappedResult = _mapper.Map<TransactionDTOs>(mapper);
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

        public async Task<bool> DeleteTransaction(int transactionId)
        {
            try
            {
                var result = await _unitOfWork.TransactionRepository.GetByIdAsync(transactionId);
                if (result != null)
                {
                     _unitOfWork.TransactionRepository.SoftRemove(result);
                    var IsSuccess = await _unitOfWork.SaveChangeAsync() > 0;
                    if(IsSuccess)
                    {
                        return true;
                    } else
                    {
                        return false;
                    }
                }
                return false;


            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TransactionDTOs> GetTransaction(int id)
        {
            try
            {
                var getTransactionId = await _unitOfWork.TransactionRepository.GetByIdAsync(id);
                if (getTransactionId != null)
                {
                    var mappedResult = _mapper.Map<TransactionDTOs>(getTransactionId);
                    return mappedResult;
                } else
                {
                    return null;
                }


            }catch(Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<TransactionDTOs>> GetTransactionByUserID(int userId)
        {
            try
            {
                var getUserID = await _unitOfWork.AccountRepository.GetByIdAsync(userId);
                if (getUserID != null)
                {
                    var transactionResult = await _unitOfWork.TransactionRepository.GetAllAsync();
                    var mapperREsult = _mapper.Map<IEnumerable<TransactionDTOs>>(transactionResult);
                    return mapperREsult;
                }
                else
                {
                    throw new Exception();
                }
            }catch( Exception ex )
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<TransactionDTOs>> GetTransactionDTOs()
        {
            try
            {
                var result = await _unitOfWork.TransactionRepository.GetAllAsync();
                if (result != null)
                {
                    var mappedResult = _mapper.Map<IEnumerable<TransactionDTOs>>(result);
                    return mappedResult;
                }
                else
                {
                    return null;
                }



            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UpdateTransactionDTOs> UpdateTransaction(int transactionId, UpdateTransactionDTOs updateTransactionDTOs)
        {
            try
            {
                var mapper = _mapper.Map<UpdateTransactionDTOs>(updateTransactionDTOs);
                var getTransactionId = await _unitOfWork.TransactionRepository.GetByIdAsync(transactionId);
                if (getTransactionId != null)
                {
                    _unitOfWork.TransactionRepository.Update(getTransactionId);
                    var IsSuccess = await _unitOfWork.SaveChangeAsync() > 0;
                    if (IsSuccess)
                    {
                        var mappedResult = _mapper.Map<UpdateTransactionDTOs>(getTransactionId);
                        return mappedResult;
                    } else
                    {
                        return null;
                    }
                } else
                {
                    return null;
                }


            }catch( Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
