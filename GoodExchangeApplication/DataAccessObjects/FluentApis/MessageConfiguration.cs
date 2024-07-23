using BusinessObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.FluentApis
{
    public class MessageConfiguration /*: IEntityTypeConfiguration<Message>*/
    {
        /*public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasOne(m => m.ChatSession)
                   .WithMany(cs => cs.Messages)
                   .HasForeignKey(m => m.ChatSessionId);

            builder.HasOne(m => m.User)
                   .WithMany(u => u.Messages)
                   .HasForeignKey(m => m.UserId)
                   .OnDelete(DeleteBehavior.SetNull);
        }*/
    }
}
