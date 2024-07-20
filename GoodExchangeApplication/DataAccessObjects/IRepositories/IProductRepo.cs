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
        public Task<Product> UpdateProduct(Product product);
        public Task<bool> DeleteProduct(int id);
        public Task<bool> CheckExist(int id);
        public Task<IEnumerable<Product>> SearchProductByNameOrCode(string searchQuery);
        Task<IEnumerable<Product>> GetProductsByUserIdAsync(int userId);
        public Task<List<Category>> GetCategories();
        public Task<List<ProductDTos>> GetTopPopularProductsAsync();
        public Task<Paging<ProductDTos>> GetProductsPaging(int pageIndex, int pageSize, string? title = null, float? minPrice = null, float? maxPrice = null, int? categoryId = null, string? sortField = null, string sortOrder = "asc");
    }
}
