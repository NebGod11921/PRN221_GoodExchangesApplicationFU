using DataAccessObjects.IRepositories;
using DataAccessObjects.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        private readonly IAccountRepository _accountRepository;
        private readonly IProductRepo _productRepo;


        public UnitOfWork(IAccountRepository accountRepository, AppDbContext appDbContext, IProductRepo IProductRepo)
        {
            _accountRepository = accountRepository;
            _appDbContext = appDbContext;
            _productRepo = IProductRepo;
        }
        public IAccountRepository AccountRepository => _accountRepository;

        public IProductRepo ProductRepository => _productRepo;

        public async Task<int> SaveChangeAsync()
        {
            return await _appDbContext.SaveChangesAsync();
        }
    }
}
