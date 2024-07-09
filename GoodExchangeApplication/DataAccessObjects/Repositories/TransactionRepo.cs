using BusinessObjects;
using DataAccessObjects.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.Repositories
{
    public class TransactionRepo : GenericRepository<Transaction>, ITransactionRepo
    {
        private readonly AppDbContext _appDbContext;

        public TransactionRepo(AppDbContext appDbContext) : base(appDbContext) 
        {
            _appDbContext = appDbContext;
        }
    }
}
