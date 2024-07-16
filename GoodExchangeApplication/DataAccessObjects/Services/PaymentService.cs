using AutoMapper;
using DataAccessObjects.IServices;
using DataAccessObjects.ViewModels.PaymentDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PaymentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }




        public async Task<IEnumerable<PaymentDTOs>> GetPaymentDTOs()
        {
            try
            {
                var result = await _unitOfWork.PaymentsRepository.GetAllAsync();
                if (result != null)
                {
                    var mappedResult = _mapper.Map<IEnumerable<PaymentDTOs>>(result);
                    return mappedResult;
                }
                else
                {
                    return null;
                }




            }catch  (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PaymentDTOs> GetPaymentDTOs(int id)
        {
            try
            {
                var result = await _unitOfWork.PaymentsRepository.GetByIdAsync(id);
                if (result != null)
                {
                    var mappedResult = _mapper.Map<PaymentDTOs>(result);
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
    }
}
