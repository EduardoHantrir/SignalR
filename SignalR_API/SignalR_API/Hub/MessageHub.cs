using Microsoft.AspNetCore.SignalR;

namespace SignalR_API
{
    public class MessageHub : Hub
    {
        public void NewMessage(string user, string message)
        {
            Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
