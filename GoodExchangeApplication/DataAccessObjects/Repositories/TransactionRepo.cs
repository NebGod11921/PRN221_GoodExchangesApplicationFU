using BusinessObjects;
using DataAccessObjects.IRepositories;
using DataAccessObjects.ViewModels.TransactionDTOs;
using Microsoft.EntityFrameworkCore;
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

        public async Task<PagingTransaction<Transaction>> GetTransactionByUserID(int userId, int pageNumber, int pageSize)
        {
            try
            {
                var query = _appDbContext.Transactions
                           .Where(t => t.UserId == userId)
                           .OrderByDescending(t => t.TransactionDate)
                           .AsQueryable();

                int totalRecords = query.Count();
                var transactions = await query.Skip((pageNumber - 1) * pageSize)
                                              .Take(pageSize)
                                              .Select(t => new Transaction
                                              {
                                                  Id = t.Id,
                                                  TransactionDate = t.TransactionDate,
                                                  Note = t.Note,
                                                  TotalAmount = t.TotalAmount,
                                                  ShippingAddress = t.ShippingAddress,
                                                  Status = t.Status
                                              })
                                              .ToListAsync();

                return new PagingTransaction<Transaction>
                {
                    Transactions = transactions,
                    TotalRecords = totalRecords,
                    TotalPages = (int)Math.Ceiling((double)totalRecords / pageSize)
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
