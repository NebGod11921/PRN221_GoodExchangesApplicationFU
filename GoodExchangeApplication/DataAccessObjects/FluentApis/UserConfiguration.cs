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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    { 
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasMany(x => x.Posts).WithOne(x => x.User);
            builder.HasMany(x => x.Reviews).WithOne(x => x.User);
            builder.HasMany(x => x.Reports).WithOne(x => x.User);
            builder.HasMany(x => x.Transactions).WithOne(x => x.User);
        }
    }
}
