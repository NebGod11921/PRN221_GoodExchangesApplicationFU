using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.IServices
{
    public interface IChatService
    {
        Task SendMessageAsync(int chatSessionId, string content, int userId);
        Task<ChatSession> GetOrCreateChatSessionAsync(int user1Id, int user2Id);
    }
}
