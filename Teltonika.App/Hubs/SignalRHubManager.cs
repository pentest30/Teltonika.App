using Microsoft.AspNetCore.SignalR;

namespace Teltonika.App.Hubs
{
    public static class SignalRHubManager
    {
        public static string ConnectionId { get; set; }
        public static IHubCallerClients Clients { get; set; }
    }
}
