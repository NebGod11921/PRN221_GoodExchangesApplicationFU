using AutoMapper;
using BusinessObjects;
using DataAccessObjects.IServices;
using DataAccessObjects.ViewModels.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.Services
{
    public class ProductCategoryService: IProductCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductCategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            try
            {
               /* var result = await _unitOfWork.productCategoryRepo.GetAllAsync();
                if (result != null)
                {
                    var mappedResult = _mapper.Map<IEnumerable<ProductCategoryDTOs>>(result);
                    return mappedResult;
                } else
                {
                    return null;
                }*/
               return await _unitOfWork.productCategoryRepo.GetCategories();
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
