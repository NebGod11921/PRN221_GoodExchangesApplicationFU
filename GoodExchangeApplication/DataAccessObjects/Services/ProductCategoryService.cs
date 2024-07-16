using BusinessObjects;
using DataAccessObjects.IServices;
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
        public ProductCategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _unitOfWork.productCategoryRepo.GetCategories();
        }
    }
}
