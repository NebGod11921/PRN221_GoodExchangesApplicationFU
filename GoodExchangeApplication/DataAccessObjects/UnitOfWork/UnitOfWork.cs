using DataAccessObjects.IRepositories;
using DataAccessObjects.IServices;
using DataAccessObjects.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.UnitOfWork
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
        private readonly IReportRepository _reportRepo;

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
            _reportRepo = reportRepo;

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

        public IReportRepository ReportRepository => _reportRepo;
        public int Commit()
        {
            return _appDbContext.SaveChanges();
        }

        public async Task<int> SaveChangeAsync()
        {
            TrackChanges();
            return await _appDbContext.SaveChangesAsync();
        }

        private void TrackChanges()
        {
            var validationErrors = _appDbContext.ChangeTracker.Entries<IValidatableObject>()
                .SelectMany(e => e.Entity.Validate(null))
                .Where(e => e != ValidationResult.Success)
                .ToArray();
            if (validationErrors.Any())
            {
                var exceptionMessage = string.Join(Environment.NewLine,
                    validationErrors.Select(error => $"Properties {error.MemberNames} Error: {error.ErrorMessage}"));
                throw new Exception(exceptionMessage);
            }
        }
    }
}
