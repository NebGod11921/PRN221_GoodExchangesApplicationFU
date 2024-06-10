using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.FluentApis
{
    public class TransactionProductConfiguration : IEntityTypeConfiguration<TransactionProduct> 
    {
        public void Configure(EntityTypeBuilder<TransactionProduct> builder) 
        {
            builder.HasKey(x => new {x.ProductId, x.TransactionId});
            builder.HasOne(x => x.Product).WithMany(x => x.TransactionProducts).HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Transaction).WithMany(x => x.TransactionProducts).HasForeignKey(x => x.TransactionId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
