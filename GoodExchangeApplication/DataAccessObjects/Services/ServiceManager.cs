using AutoMapper;
using DataAccessObjects.IServices;
using DataAccessObjects.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly Lazy<IAccountService> _accountService;
        private readonly Lazy<IProductService> _productService;

        public ServiceManager(IMapper mapper,IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _accountService = new Lazy<IAccountService>(() => new AccountService(mapper,unitOfWork));
            _productService = new Lazy<IProductService>(() => new ProductService(mapper,unitOfWork));
        }
        public IAccountService AccountService => _accountService.Value;
        public IProductService ProductService => _productService.Value;     
    }
}
