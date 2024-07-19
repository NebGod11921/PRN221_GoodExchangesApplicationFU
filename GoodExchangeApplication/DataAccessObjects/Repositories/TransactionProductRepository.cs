using BusinessObjects;
using DataAccessObjects.IRepositories;
using DataAccessObjects.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.Repositories
{
    public class TransactionProductRepository : ITransactionProductRepository
    {
        private readonly AppDbContext _appDbContext;

        public TransactionProductRepository(AppDbContext context)
        {
            _appDbContext = context;
        }

        public async Task<bool> AddTransactionProduct(List<TransactionProduct> transactionProducts, int transactionId, List<int> productIds)
        {
            try
            {
                var getTransaction = await _appDbContext.Transactions.FindAsync(transactionId);
                if (getTransaction == null)
                {
                    return false; // Transaction not found
                }

                foreach (var productId in productIds)
                {
                    // Check if the TransactionProduct already exists in the context
                    var existingTransactionProduct = await _appDbContext.TransactionProducts
                        .FirstOrDefaultAsync(tp => tp.ProductId == productId && tp.TransactionId == transactionId);

                    if (existingTransactionProduct == null)
                    {
                        // If it doesn't exist, create a new TransactionProduct instance
                        var getProduct = await _appDbContext.Products.FindAsync(productId);
                        if (getProduct != null)
                        {
                            var transactionProduct = new TransactionProduct
                            {
                                ProductId = getProduct.Id,
                                TransactionId = transactionId
                            };
                            transactionProducts.Add(transactionProduct);
                        }
                    }
                    // Optionally, you can handle the case where the entity already exists or is tracked
                }

                // Add range of new TransactionProduct instances to the context
                foreach (var newTransactionProduct in transactionProducts)
                {
                    // Check if the entity is already tracked
                    var existingEntity = _appDbContext.Set<TransactionProduct>().Local
                        .FirstOrDefault(tp => tp.ProductId == newTransactionProduct.ProductId && tp.TransactionId == newTransactionProduct.TransactionId);

                    if (existingEntity == null)
                    {
                        // If not tracked, attach and mark as added
                        _appDbContext.Entry(newTransactionProduct).State = EntityState.Added;
                    }
                    else
                    {
                        // If tracked, update its state if needed
                        _appDbContext.Entry(existingEntity).State = EntityState.Added;
                    }
                }

                // Save changes to the database
                var isSuccess = await _appDbContext.SaveChangesAsync() > 0;

                return isSuccess;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<TransactionProduct>> GetTransactionProductsById(int transactionId)
        {
            try
            {
                var getTransaction = await _appDbContext.TransactionProducts.Where(x => x.TransactionId == transactionId).ToListAsync();
                if (getTransaction.Count > 0)
                {
                    return getTransaction;
                }
                else
                {
                   return new List<TransactionProduct>();
                }

            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
