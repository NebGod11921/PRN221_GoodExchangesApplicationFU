using BusinessObjects;
using DataAccessObjects.Helpers;
using DataAccessObjects.IRepositories;
using DataAccessObjects.ViewModels.ProductDTOs;
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
        public async Task<bool> UpdateProduct(int id)
        {
            var exist = await _appDbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (exist != null)
            {
                _appDbContext.Products.Update(exist);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            return false;
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
        public async Task<Pagination<ProductDTos>> GetProductsPaging(int pageIndex, int pageSize, string? title = null, 
            float? minPrice = null, float? maxPrice = null, int? categoryId = null, 
            string? sortField = null, string sortOrder = "asc")
        {
            var query = _appDbContext.Products.AsQueryable();

            if (!string.IsNullOrEmpty(title))
            {
                query = query.Where(p => p.Title.Trim().ToLower().Contains(title));
            }

            if (minPrice.HasValue)
            {
                query = query.Where(p => p.Price >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                query = query.Where(p => p.Price <= maxPrice.Value);
            }
            if (categoryId.HasValue)
            {
                query = query.Where(p => p.CategoryId == categoryId.Value);
            }
            switch (sortField)
            {
                case "Title":
                    query = sortOrder == "asc" ? query.OrderBy(p => p.Title) : query.OrderByDescending(p => p.Title);
                    break;
                case "Price":
                    query = sortOrder == "asc" ? query.OrderBy(p => p.Price) : query.OrderByDescending(p => p.Price);
                    break;
                default:
                    query = query.OrderBy(p => p.Id);
                    break;
            }
            var list = query.Select(p => new ProductDTos
            {
                Id = p.Id,
                Title = p.Title,
                Description = p.Description,
                Image = p.Image,
                Price = p.Price,
                Location = p.Location,
                Quantity = p.Quantity,
            });
            
            
            return await Pagination<ProductDTos>.CreateAsync(list.AsNoTracking(), pageIndex, pageSize);
        }
        public async Task<List<Category>> GetProductCategories()
        {
            return await _appDbContext.Categories.ToListAsync();
        }
    }
}
