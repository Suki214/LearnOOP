using Microsoft.AspNet.SignalR;
using System.Collections.Concurrent;

namespace ChatServer
{
    public class ChatHub:Hub<IClient>
    {
        private static ConcurrentDictionary<string, User> ChatClients = new ConcurrentDictionary<string, User>();
    }
}
