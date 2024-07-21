using DataAccessObjects.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessObjects;

namespace MyRazorPage.Pages
{
    public class ChatModel : PageModel
    {
       /* private readonly IChatService _chatService;

        public ChatModel(IChatService chatService)
        {
            _chatService = chatService;
        }
        public int User2Id { get; set; }
        public int UserId { get; set; }
        public int ChatSessionId { get; set; }
        public List<Message> Messages { get; set; } = new List<Message>();

        public async Task OnGetAsync(int user2Id)
        {
            User2Id = user2Id;
            int? id = HttpContext.Session.GetInt32("userId");
            UserId = id ?? 0;

            var chatSession = await _chatService.GetOrCreateChatSessionAsync(UserId, User2Id);
            ChatSessionId = chatSession.Id;

            // Fetch the messages for this chat session
            Messages = await _chatService.GetMessagesAsync(ChatSessionId);
        }*/
    }
}
