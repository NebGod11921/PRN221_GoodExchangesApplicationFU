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
        public Task<ProductDTos> UpdateProductSec(ProductDTos updateProduct);
        Task<IEnumerable<ProductDTO>> GetProductsByUserIdAsync(int userId);


        public Task<RequestProductDTO> GetById(int id);
        public Task<RequestProductDTO> CreateProduct(RequestProductDTO createProduct);
        public Task<RequestProductDTO> UpdateProduct(RequestProductDTO updateProduct);
        public Task<bool> DeleteProduct(int id);
    }
}
