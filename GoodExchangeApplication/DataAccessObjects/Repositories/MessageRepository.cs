using BusinessObjects;
using DataAccessObjects.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.Repositories
{
    public class MessageRepository /*: GenericRepository<Message>, IMessageRepository*/
    {
        /*private readonly AppDbContext _context;

        public MessageRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Message>> GetMessagesBySessionIdAsync(int sessionId)
        {
            return await _context.Messages
                .Where(m => m.ChatSessionId == sessionId)
                .OrderBy(m => m.Timestamp)
                .ToListAsync();
        }
        public async Task AddMessageAsync(Message message)
        {
            await _context.Messages.AddAsync(message);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Message>> GetMessagesByChatSessionIdAsync(int chatSessionId)
        {
            return await _context.Messages
                .Where(m => m.ChatSessionId == chatSessionId)
                .OrderBy(m => m.Timestamp)
                .ToListAsync();
        }*/
    }
}
