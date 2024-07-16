using AutoMapper;
using DataAccessObjects.IServices;
using DataAccessObjects.ViewModels.TransactionDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.Services
{
    public class TransactionTypeService : ITransactionTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TransactionTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }




        public async Task<IEnumerable<TransactionTypeDTO>> GetAllTransactionTypeDTOs()
        {
            try
            {
                var result = await _unitOfWork.TransactionType.GetAllAsync();
                if (result != null)
                {
                    var mappedResult = _mapper.Map<IEnumerable<TransactionTypeDTO>>(result);
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

        public async Task<TransactionTypeDTO> GetTransactionTypeDTO(int Id)
        {
            try
            {
                var result = await _unitOfWork.TransactionType.GetByIdAsync(Id);
                if (result != null)
                {
                    var mappedResult = _mapper.Map<TransactionTypeDTO>(result);
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
    }
}
