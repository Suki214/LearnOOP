using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatServer
{
    public class ChatHub:Hub<IClient>
    {
        private static ConcurrentDictionary<string, User> ChatClients = new ConcurrentDictionary<string, User>();

        public override Task OnDisconnected(bool stopCalled)
        {
            var userName = ChatClients.SingleOrDefault((c) => c.Value.ID == Context.ConnectionId).Key;
            if (userName != null)
            {
                Clients.Others.PaticipantDisconnection(userName);
                Console.WriteLine($"<> {userName} Disconnected");
            }
            return base.OnDisconnected(stopCalled);
        }

        public override Task OnConnected()
        {
            var userName = ChatClients.SingleOrDefault((c) => c.Value.ID == Context.ConnectionId).Key;
            if (userName != null)
            {
                Clients.Others.PaticipantReconnection(userName);
                Console.WriteLine($"== {userName} Reconnected");
            }
            return base.OnConnected();
        }

        public List<User> Login(string name, byte[] photo)
        {
            if (!ChatClients.ContainsKey(name))
            {
                Console.WriteLine($"++ {name} logged in");
                List<User> users = new List<User>(ChatClients.Values);
                User newUser = new User { Name = name, ID = Context.ConnectionId, Photo = photo };
                var added = ChatClients.TryAdd(name, newUser);
                if (!added) return null;
                Clients.CallerState.UserName = name;
                Clients.Others.PaticipantLogin(newUser);
                return users;
            }
            return null;
        }

        public void Logout()
        {
            var name = Clients.CallerState.UserName;
            if (!string.IsNullOrEmpty(name))
            {
                User client = new User();
                ChatClients.TryRemove(name, out client);
                Clients.Others.PaticipantLogout(name);
                Console.WriteLine($"-- {name} logged out");
            }
        }

        public void BroadcastTextMessage(string message)
        {
            var name = Clients.CallerState.UserName;
            if (!string.IsNullOrEmpty(name) && !(string.IsNullOrEmpty(message)))
            {
                Clients.Others.BroadcastTexMessage(name,message);
            }
        }

        public void BroadcastImageMessage(byte[] img)
        {
            var name = Clients.CallerState.UserName;
            if (!string.IsNullOrEmpty(name) && img!=null)
            {
                Clients.Others.BroadcastPictureMessage(name, img);
            }
        }

        public void UnicastTextMessage(string receipt, string message)
        {
            var sender = Clients.CallerState.UserName;
            if(!string.IsNullOrEmpty(sender) && receipt!=sender &&
                    !string.IsNullOrEmpty(message) && ChatClients.ContainsKey(receipt))
            {
                User client = new User();
                ChatClients.TryGetValue(receipt, out client);
                Clients.Client(client.ID).UnicastTexMessage(sender, message);
            }
        }

        public void UnicastImageMessage(string receipt, byte[] img)
        {
            var sender = Clients.CallerState.UserName;
            if(!string.IsNullOrEmpty(sender) && sender!=receipt &&
                img!=null && ChatClients.ContainsKey(receipt))
            {
                User client = new User();
                ChatClients.TryGetValue(receipt, out client);
                Clients.Client(client.ID).UnicastPictureMessage(sender, img);
            }
        }

        public void Typing(string receipt)
        {
            if (string.IsNullOrEmpty(receipt)) return;
            var sender = Clients.CallerState.UserName;
            User client = new User();
            ChatClients.TryGetValue(receipt, out client);
            Clients.Client(client.ID).PaticipantTyping(sender);
        }
    }
}
