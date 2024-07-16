using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.IRepositories
{
   public interface IChatSessionRepository
    {
        Task<ChatSession> GetChatSessionAsync(int user1Id, int user2Id);
        Task AddChatSessionAsync(ChatSession chatSession);
    }
}
