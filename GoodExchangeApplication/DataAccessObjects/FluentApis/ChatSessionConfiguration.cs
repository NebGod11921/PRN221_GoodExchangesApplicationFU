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
    public class ChatSessionConfiguration /*: IEntityTypeConfiguration<ChatSession>*/
    {
        /*public void Configure(EntityTypeBuilder<ChatSession> builder)
        {
            builder.HasOne(cs => cs.User1)
                   .WithMany(u => u.ChatSessionsAsUser1)
                   .HasForeignKey(cs => cs.User1Id)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(cs => cs.User2)
                   .WithMany(u => u.ChatSessionsAsUser2)
                   .HasForeignKey(cs => cs.User2Id)
                   .OnDelete(DeleteBehavior.Restrict);
        }*/
    }
}
