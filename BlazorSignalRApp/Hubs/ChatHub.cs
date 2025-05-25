using Microsoft.AspNetCore.SignalR;

namespace BlazorSignalRApp.Hubs
{
    public class ChatHub:Hub
    {
        public async Task SendMessage(string user ,string messasge)
        {
            await Clients.All.SendAsync("ReceiveMessage",user, messasge);
        }
    }
}
