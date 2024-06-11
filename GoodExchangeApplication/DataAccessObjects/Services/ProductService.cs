using AutoMapper;
using DataAccessObjects.IServices;
using DataAccessObjects.ViewModels.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ProductDTO>> SearchProductByNameOrCodeAsync(string searchQuery)
        {
            try
            {
                var products = await _unitOfWork.ProductRepository.SearchProductByNameOrCode(searchQuery);
                var productDTOs = _mapper.Map<IEnumerable<ProductDTO>>(products);
                return productDTOs;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
