﻿using DataAccessObjects.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public interface IUnitOfWork
    {
        public IAccountRepository AccountRepository { get; }
        public IPostRepository PostRepository { get; }
        int Commit();
        public Task<int> SaveChangeAsync();
        public IProductRepo ProductRepository { get; }

        public ITransactionRepo TransactionRepository { get; }
        public ITransactionTypeRepo TransactionType { get; }
        public ITransactionProductRepository TransactionProductRepository { get; }
        public IPaymentRepo PaymentsRepository { get; }

        public IReportRepository ReportRepository { get; }

        public IReviewRepository ReviewRepository { get; }

    }
}
