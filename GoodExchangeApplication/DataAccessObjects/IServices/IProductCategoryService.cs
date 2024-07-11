using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.IServices
{
    public interface IProductCategoryService
    {
        public Task<IEnumerable<Category>> GetCategories();
    }
}
