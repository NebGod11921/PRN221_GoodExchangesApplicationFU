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
        public Task<IEnumerable<ResponseProductDTO>> GetAllProducts(ResponseProductDTO productDTO);
        public Task<ResponseProductDTO> GetById(int id);
        public Task<ResponseProductDTO> CreateProduct(RequestProductDTO createProduct);
        public Task<ResponseProductDTO> UpdateProduct(ResponseProductDTO updateProduct);
        public Task<bool> DeleteProduct(int id);
    }
}
