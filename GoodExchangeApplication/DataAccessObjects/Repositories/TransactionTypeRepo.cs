using BusinessObjects;
using DataAccessObjects.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.Repositories
{
    public class TransactionTypeRepo : GenericRepository<TransactionType>, ITransactionTypeRepo
    {
        private readonly AppDbContext _appDbContext;

        public TransactionTypeRepo(AppDbContext appDbContext) : base(appDbContext) 
        {
            _appDbContext = appDbContext;
        }
    }
}
