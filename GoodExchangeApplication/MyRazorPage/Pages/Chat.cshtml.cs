using DataAccessObjects.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyRazorPage.Pages
{
    public class ChatModel : PageModel
    {
        private readonly IChatService _chatService;

        public ChatModel(IChatService chatService)
        {
            _chatService = chatService;
        
        }

        public int ChatSessionId { get; set; }
        public int UserId { get; set; }

        public async Task OnGetAsync(int chatSessionId)
        {
            ChatSessionId = chatSessionId;
            UserId = 2; // Retrieve the logged-in user's ID dynamically in a real scenario

            // Optionally, you can load chat history here
            var chatSession = await _chatService.GetOrCreateChatSessionAsync(UserId, chatSessionId);
        }
    }
}
