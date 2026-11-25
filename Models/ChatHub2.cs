using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace SignalR_Demo.Models
{
    [Authorize]
    public class ChatHub2 : Hub
    {
        public async Task SendMessage(string receiverId, string message)
        {
            var senderId = Context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(senderId))
                throw new HubException("Unauthorized");

            // TODO: Verify receiver exists and sender
            // is permitted to message receiver.

            // TODO: Save message in Oracle using Dapper.

            await Clients.User(receiverId)
                .SendAsync("ReceiveMessage", new
                {
                    SenderId = senderId,
                    Message = message,
                    SentAt = DateTime.UtcNow
                });
        }
    }
}



