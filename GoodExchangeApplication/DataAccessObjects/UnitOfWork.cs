using DataAccessObjects.IRepositories;
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

        public UnitOfWork(IAccountRepository accountRepository, AppDbContext appDbContext)
        {
            _accountRepository = accountRepository;
            _appDbContext = appDbContext;
        }
        public IAccountRepository AccountRepository => _accountRepository;

        public async Task<int> SaveChangeAsync()
        {
            return await _appDbContext.SaveChangesAsync();
        }
    }
}
