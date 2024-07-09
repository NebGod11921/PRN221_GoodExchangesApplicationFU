using BusinessObjects;
using DataAccessObjects.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.Repositories
{
    public class PaymentRepo : GenericRepository<Payment>, IPaymentRepo
    {
        private readonly AppDbContext _appDbContext;

        public PaymentRepo(AppDbContext appDbContext) : base(appDbContext) 
        {
            _appDbContext = appDbContext;
        }

    }
}
