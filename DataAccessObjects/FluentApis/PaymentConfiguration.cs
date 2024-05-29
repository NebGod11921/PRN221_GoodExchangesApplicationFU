using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.FluentApis
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment> 
    {
        public void Configure(EntityTypeBuilder<Payment> builder) 
        { 
            builder.HasKey(x  => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasMany(x => x.Transactions).WithOne(x => x.Payment);
        }
    }
}
