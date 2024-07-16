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
        public ProductRepo(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Product> GetByID(int id)
        {
            var IdProduct = await _appDbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
            return IdProduct;
        }

        public async Task<List<Product>> GetProduct()
        {
            return await _appDbContext.Products.ToListAsync();
        }
        public async Task<bool> CheckExist(int id)
        {
            var exist = await _appDbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (exist == null)
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
        public async Task<Product> UpdateProduct(Product product)
        {
            var exist = await GetByID(product.Id);
            if (exist != null)
            {
                exist.Title= product.Title;
                exist.Description= product.Description;
                exist.Price= product.Price;
                exist.CategoryId= product.CategoryId;
                exist.Quantity= product.Quantity;
                exist.Image= product.Image;
                exist.Location= product.Location;
                _appDbContext.Products.UpdateRange(exist);
            }
            await _appDbContext.SaveChangesAsync();
            return exist;
        }
        public async Task<IEnumerable<Product>> SearchProductByNameOrCode(string searchQuery)
        {
            try
            {
                var result = await _appDbContext.Products
                    .Where(p => p.Title.Contains(searchQuery) || p.Category.Name.Contains(searchQuery))
                    .ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<Product>> GetProductsByUserIdAsync(int userId)
        {
            return await _appDbContext.UserProducts
                .Where(up => up.UserId == userId)
                .Select(up => up.Product)
                .ToListAsync();
        }
    }
}
