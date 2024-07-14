﻿using DataAccessObjects.IRepositories;
using DataAccessObjects.Repositories;
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
        private readonly IPostRepository _postRepository;
        private readonly IChatSessionRepository _chatSessionRepository;
        private readonly IMessageRepository _messageRepository;
        private readonly IProductRepo _productRepo;
        private readonly ITransactionRepo _transactionRepo;
        private readonly ITransactionTypeRepo _transactionTypeRepo;
        public UnitOfWork(IAccountRepository accountRepository, AppDbContext appDbContext, IProductRepo IProductRepo, ITransactionRepo transactionRepo, ITransactionTypeRepo transactionTypeRepo,
            IPostRepository postRepository, IMessageRepository messageRepository, IChatSessionRepository chatSessionRepository)
        {
            _accountRepository = accountRepository;
            _productRepo = IProductRepo;
            _messageRepository = messageRepository;
            _chatSessionRepository = chatSessionRepository;
            _postRepository = postRepository;
            _appDbContext = appDbContext;
            _productRepo = IProductRepo;
            _transactionRepo = transactionRepo;
            _transactionTypeRepo = transactionTypeRepo;
        }
        public IAccountRepository AccountRepository => _accountRepository;
        public IPostRepository PostRepository => _postRepository;
        public IMessageRepository MessageRepository => _messageRepository;
        public IChatSessionRepository ChatSessionRepository => _chatSessionRepository;

        public IProductRepo ProductRepository => _productRepo;

        public ITransactionRepo TransactionRepository => _transactionRepo;

        public ITransactionTypeRepo TransactionType => _transactionTypeRepo;

        public async Task<int> SaveChangeAsync()
        {
            return await _appDbContext.SaveChangesAsync();
        }
    }
}
