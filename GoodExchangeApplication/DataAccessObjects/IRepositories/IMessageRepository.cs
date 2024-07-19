using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.IRepositories
{
    public interface IMessageRepository : IGenericRepository<Message>
    {
        Task<IEnumerable<Message>> GetMessagesBySessionIdAsync(int sessionId);
        Task AddMessageAsync(Message message);
        Task<List<Message>> GetMessagesByChatSessionIdAsync(int chatSessionId);


    }
}
