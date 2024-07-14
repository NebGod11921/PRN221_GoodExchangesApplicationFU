using DataAccessObjects.IServices;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class ChatHub : Hub
    {
        private readonly IChatService _chatService;

        public ChatHub(IChatService chatService)
        {
            _chatService = chatService;
        }

        public async Task SendMessage(int chatSessionId, string content, int userId)
        {
            // Save the message to the database
            await _chatService.SendMessageAsync(chatSessionId, content, userId);

            // Notify clients of the new message
            await Clients.Group(chatSessionId.ToString()).SendAsync("ReceiveMessage", userId, content);
        }

        public async Task JoinChatSession(int chatSessionId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, chatSessionId.ToString());
        }

        public async Task LeaveChatSession(int chatSessionId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, chatSessionId.ToString());
        }
    }
}
