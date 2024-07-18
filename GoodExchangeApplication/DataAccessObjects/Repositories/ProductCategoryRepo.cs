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
    public class ProductCategoryRepo: GenericRepository<Category>, IProductCategoryRepo
    {
        private readonly AppDbContext _dbContext;
        public ProductCategoryRepo(AppDbContext context): base(context)
        {
            _dbContext = context;        
        }

        public async Task<List<Category>> GetCategories()
        {
            return await _dbContext.Categories.ToListAsync();
        }
    }
}
