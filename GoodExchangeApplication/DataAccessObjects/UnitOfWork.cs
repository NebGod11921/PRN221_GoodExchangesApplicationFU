using DataAccessObjects.IRepositories;
using DataAccessObjects.IServices;
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
        private readonly IPostRepository _postRepository;
        /*private readonly IChatSessionRepository _chatSessionRepository;
        private readonly IMessageRepository _messageRepository;*/
        private readonly IProductRepo _productRepo;
        

       
        private readonly ITransactionRepo _transactionRepo;
        private readonly ITransactionTypeRepo _transactionTypeRepo;
        private readonly ITransactionProductRepository _transactionProductRepository;
        private readonly IPaymentRepo _paymentRepo;


        public UnitOfWork(IAccountRepository accountRepository, AppDbContext appDbContext, IProductRepo IProductRepo, ITransactionRepo transactionRepo, ITransactionTypeRepo transactionTypeRepo,
            IPostRepository postRepository, /*IMessageRepository messageRepository, IChatSessionRepository chatSessionRepository,*/ ITransactionProductRepository transactionProductRepository, IPaymentRepo paymentRepo)

        {
            _accountRepository = accountRepository;
            _productRepo = IProductRepo;
            /*_messageRepository = messageRepository;
            _chatSessionRepository = chatSessionRepository;*/
            _postRepository = postRepository;
            _appDbContext = appDbContext;
            _productRepo = IProductRepo;
            
            _transactionRepo = transactionRepo;
            _transactionTypeRepo = transactionTypeRepo;
            _transactionProductRepository = transactionProductRepository;
            _paymentRepo = paymentRepo;
        }
        public IAccountRepository AccountRepository => _accountRepository;
        public IPostRepository PostRepository => _postRepository;
        /*public IMessageRepository MessageRepository => _messageRepository;
        public IChatSessionRepository ChatSessionRepository => _chatSessionRepository;*/

        public IProductRepo ProductRepository => _productRepo;

        
        public ITransactionRepo TransactionRepository => _transactionRepo;

        public ITransactionTypeRepo TransactionType => _transactionTypeRepo;

        public ITransactionProductRepository TransactionProductRepository => _transactionProductRepository;

        public IPaymentRepo PaymentsRepository => _paymentRepo;

        public async Task<int> SaveChangeAsync()
        {
            return await _appDbContext.SaveChangesAsync();
        }
    }
}
