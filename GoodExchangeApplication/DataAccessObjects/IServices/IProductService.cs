using BusinessObjects;
using DataAccessObjects.Helpers;
using DataAccessObjects.ViewModels.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.IServices
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> SearchProductByNameOrCodeAsync(string searchQuery);
        public Task<IEnumerable<ResponseProductDTO>> GetAllProducts(ResponseProductDTO productDTO);
        public Task<IEnumerable<ProductDTos>> GetAllProductsSecVers();
        public Task<ProductDTos> GetProductByIdSecondVers(int productId);
        public Task<IEnumerable<ProductDTos>> GetProductsByTransactionId(int transactionId);


        public Task<ProductDTos> UpdateProductSec(ProductDTos updateProduct);
        Task<IEnumerable<ProductDTO>> GetProductsByUserIdAsync(int userId);

        public Task<Paging<ProductDTos>> GetProductsPaging(int pageIndex, int pageSize, string? title = null, float? minPrice = null, float? maxPrice = null, int? categoryId = null, string? sortField = null, string sortOrder = "asc");
        public Task<IEnumerable<Category>> GetCategories();
        public Task<RequestProductDTO> GetById(int id);
        public Task<RequestProductDTO> CreateProduct(RequestProductDTO createProduct);
        public Task<RequestProductDTO> UpdateProduct(RequestProductDTO updateProduct);
        public Task<bool> DeleteProduct(int id);
    }
}
