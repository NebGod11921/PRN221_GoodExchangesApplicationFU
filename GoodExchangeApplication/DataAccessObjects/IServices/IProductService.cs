using BusinessObjects;
using DataAccessObjects.Helpers;
using DataAccessObjects.ViewModels.ProductDTOs;
using Microsoft.AspNetCore.Mvc;
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
        public Task<IEnumerable<ResponseProductDTO>> GetAllProducts();
        public Task<IEnumerable<ProductDTos>> GetAllProductsSecVers();
        public Task<ProductDTos> GetProductByIdSecondVers(int productId);

        public Task<Pagination<ProductDTos>> GetProductsPaging(int pageIndex, int pageSize, string? title = null, float? minPrice = null, float? maxPrice = null, int? categoryId = null);
        public Task<IEnumerable<Category>> GetProductCategories();

        public Task<ResponseProductDTO> GetById(int id);
        public Task<RequestProductDTO> CreateProduct(RequestProductDTO createProduct);
        public Task<ResponseProductDTO> UpdateProduct(ResponseProductDTO updateProduct);
        public Task<bool> DeleteProduct(int id);
    }
}
