using BusinessObjects;
using DataAccessObjects.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessObjects.Repositories
{
    public class ChatSessionRepository : GenericRepository<ChatSession>, IChatSessionRepository
    {
        private readonly AppDbContext _context;

        public ChatSessionRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ChatSession> GetChatSessionAsync(int user1Id, int user2Id)
        {
            return await _context.ChatSessions
                .FirstOrDefaultAsync(cs => (cs.User1Id == user1Id && cs.User2Id == user2Id) ||
                                            (cs.User1Id == user2Id && cs.User2Id == user1Id));
        }
        public async Task AddChatSessionAsync(ChatSession chatSession)
        {
            await _context.ChatSessions.AddAsync(chatSession);
            await _context.SaveChangesAsync();
        }
    }
}
