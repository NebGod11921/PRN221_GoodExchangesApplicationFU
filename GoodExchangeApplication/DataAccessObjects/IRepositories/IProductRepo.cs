using BusinessObjects;
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
    }
}
