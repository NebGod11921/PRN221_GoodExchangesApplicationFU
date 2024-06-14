using BusinessObjects;
using DataAccessObjects.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.Repositories
{
    public class ProductRepo: GenericRepository<Product>, IProductRepo
    {
        private readonly AppDbContext _appDbContext;
        public ProductRepo(AppDbContext appDbContext): base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Product> GetByID(int id)
        {
            var IdProduct=await _appDbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
            return IdProduct;
        }

        public async Task<List<Product>> GetProduct()
        {
            return await _appDbContext.Products.ToListAsync();
        }
        public async Task<bool> CheckExist(int id)
        {
            var exist = await _appDbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
            if(exist == null)
            {
                return false;
            }
            return true;
        }
        public async Task<Product> CreateProduct(Product product)
        {
            await _appDbContext.Products.AddAsync(product);
            await _appDbContext.SaveChangesAsync();
            return product;
        }
        public async Task<bool> DeleteProduct(int id)
        {
            var exist = await _appDbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (exist != null)
            {
                _appDbContext.Products.Remove(exist);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> UpdateProduct(int id)
        {
            var exist = await _appDbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
            if( exist != null)
            {
                _appDbContext.Products.Update(exist);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
