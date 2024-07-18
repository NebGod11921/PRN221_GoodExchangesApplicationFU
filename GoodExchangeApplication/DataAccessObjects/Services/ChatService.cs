using BusinessObjects;
using DataAccessObjects.IRepositories;
using DataAccessObjects.IServices;
using System.Threading.Tasks;

namespace DataAccessObjects.Services
{
    public class ChatService : IChatService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IChatSessionRepository _chatSessionRepository;

        public ChatService(IMessageRepository messageRepository, IChatSessionRepository chatSessionRepository)
        {
            _messageRepository = messageRepository;
            _chatSessionRepository = chatSessionRepository;
        }

        public async Task SendMessageAsync(int chatSessionId, string content, int userId)
        {
            var message = new Message
            {
                ChatSessionId = chatSessionId,
                Content = content,
                Timestamp = DateTime.Now,
                UserId = userId
            };

            await _messageRepository.AddMessageAsync(message);
        }

        public async Task<ChatSession> GetOrCreateChatSessionAsync(int user1Id, int user2Id)
        {
            var chatSession = await _chatSessionRepository.GetChatSessionAsync(user1Id, user2Id);
            if (chatSession == null)
            {
                chatSession = new ChatSession
                {
                    User1Id = user1Id,
                    User2Id = user2Id
                };

                await _chatSessionRepository.AddChatSessionAsync(chatSession);
            }

            return chatSession;
        }
        public async Task<List<Message>> GetMessagesAsync(int chatSessionId)
        {
            return await _messageRepository.GetMessagesByChatSessionIdAsync(chatSessionId);
        }
    }
}
