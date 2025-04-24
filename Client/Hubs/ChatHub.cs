using BusinessObject.Entities;
using Microsoft.AspNetCore.SignalR;

namespace Client.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(Message message)
        {
            Console.WriteLine($"User: {message.UserName}, Content: {message.Content}, When: {message.SentAt}");
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}