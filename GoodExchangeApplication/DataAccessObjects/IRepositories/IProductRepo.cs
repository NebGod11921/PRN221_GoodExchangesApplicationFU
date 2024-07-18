using BusinessObjects;
using DataAccessObjects.Helpers;
using DataAccessObjects.ViewModels.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.IRepositories
{
    public interface IProductRepo : IGenericRepository<Product>
    {
        public Task<Product> GetByID(int id);
        public Task<List<Product>> GetProduct();
        public Task<Product> CreateProduct(Product product);
        public Task<bool> UpdateProduct(int id);
        public Task<bool> DeleteProduct(int id);
        public Task<bool> CheckExist(int id);
        public Task<IEnumerable<Product>> SearchProductByNameOrCode(string searchQuery);
        public Task<Pagination<ProductDTos>> GetProductsPaging(int pageIndex, int pageSize, string? title = null, float? minPrice = null, float? maxPrice = null, int? categoryId = null, string? sortField = null, string sortOrder = "asc");
        public Task<List<Category>> GetProductCategories();
    }
}
