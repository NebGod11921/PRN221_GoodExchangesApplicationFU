using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.IRepositories
{
    public interface IProductCategoryRepo : IGenericRepository<Category>
    {
        public Task<List<Category>> GetCategories();
    }
}
