using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.IServices
{
    public interface IServiceManager
    {
        IAccountService AccountService { get; }
        IProductService ProductService { get; }
    }
}
