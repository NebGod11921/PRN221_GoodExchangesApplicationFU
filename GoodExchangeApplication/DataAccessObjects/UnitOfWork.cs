using DataAccessObjects.IRepositories;
using DataAccessObjects.Repositories;
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
        private readonly IProductRepository _productRepository;
        private readonly IPostRepository _postRepository;


        public UnitOfWork(IAccountRepository accountRepository, IProductRepository productRepository, IPostRepository postRepository, AppDbContext appDbContext)
        {
            _accountRepository = accountRepository;
            _productRepository = productRepository;
            _postRepository = postRepository;
            _appDbContext = appDbContext;
        }
        public IAccountRepository AccountRepository => _accountRepository;
        public IProductRepository ProductRepository => _productRepository;
        public IPostRepository PostRepository => _postRepository;

        public async Task<int> SaveChangeAsync()
        {
            return await _appDbContext.SaveChangesAsync();
        }
    }
}
