using DataAccessObjects.IRepositories;
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
<<<<<<< HEAD:GoodExchangeApplication/DataAccessObjects/IUnitOfWork.cs
        /*public IMessageRepository MessageRepository { get; }*/
        /*public IChatSessionRepository ChatSessionRepository { get; }*/

        /*        public IMessageRepository MessageRepository { get; }
                public IChatSessionRepository ChatSessionRepository { get; }*/
=======
        public IMessageRepository MessageRepository { get; }
        public IChatSessionRepository ChatSessionRepository { get; }
>>>>>>> parent of 8736e30 (Fix the UnitOfWork):GoodExchangeApplication/DataAccessObjects/UnitOfWork/IUnitOfWork.cs
        int Commit();
        public Task<int> SaveChangeAsync();
        public IProductRepo ProductRepository { get; }

        public ITransactionRepo TransactionRepository { get; }
        public ITransactionTypeRepo TransactionType { get; }
        public ITransactionProductRepository TransactionProductRepository { get; }
        public IPaymentRepo PaymentsRepository { get; }

        public IReportRepository ReportRepository { get; }

    }
}
