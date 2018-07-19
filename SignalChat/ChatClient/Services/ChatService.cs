using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ChatClient.Enums;
using ChatClient.Models;
using Microsoft.AspNet.SignalR.Client;

namespace ChatClient.Services
{
    public class ChatService : IChatService
    {
        public event Action<User> ParticipantLoggedIn;
        public event Action<string> ParticipantLoggedOut;
        public event Action<string> ParticipantDisconnected;
        public event Action<string> ParticipantReconnected;
        public event Action ConnectionReconnecting;
        public event Action ConnectionReconnected;
        public event Action ConnectionClosed;
        public event Action<string, string, MessageType> NewTextMessage;
        public event Action<string, byte[], MessageType> NewImageMessage;
        public event Action<string> PaticipantTyping;

        private IHubProxy hubProxy;
        private HubConnection connection;
        private string url = "http://localhost:8080/signalchat";

        public async Task ConnectAsync()
        {
            connection = new HubConnection(url);
            hubProxy = connection.CreateHubProxy("ChatHub");
            hubProxy.On<User>("ParticipantLoggedIn", (u) => ParticipantLoggedIn?.Invoke(u));
            hubProxy.On<string>("ParticipantLoggedOut",(m)=> ParticipantLoggedOut?.Invoke(m));
            hubProxy.On<string>("ParticipantDisconnected",(m)=> ParticipantDisconnected?.Invoke(m));
            hubProxy.On<string>("ParticipantReconnected",(m)=> ParticipantReconnected?.Invoke(m));
            hubProxy.On<string, string>("BroadcastTextMessage",(m,n)=>NewTextMessage?.Invoke(m,n,MessageType.Broadcast));
            hubProxy.On<string, byte[]>("BroadcastPictureMessage",(m,n)=>NewImageMessage?.Invoke(m,n,MessageType.Broadcast));
            hubProxy.On<string, string>("UnicastTextMessage", (m, n) => NewTextMessage?.Invoke(m, n, MessageType.Unicast));
            hubProxy.On<string, byte[]>("UnicastPictureMessage", (m, n) => NewImageMessage?.Invoke(m, n, MessageType.Unicast));
            hubProxy.On<string>("PaticipantTyping", (p)=> PaticipantTyping?.Invoke(p));

            connection.Reconnecting += Reconnecting;
            connection.Reconnected += Reconnected;
            connection.Closed += Disconnected;

            ServicePointManager.DefaultConnectionLimit = 10;
            await connection.Start();

        }

        private void Disconnected()
        {
            ConnectionClosed?.Invoke();
        }

        private void Reconnected()
        {
            ConnectionReconnected?.Invoke();
        }

        private void Reconnecting()
        {
            ConnectionReconnecting?.Invoke();
        }

        public async Task<List<User>> LoginAsync(string name, byte[] photo)
        {
            return await hubProxy.Invoke<List<User>>("Login", new object[] { name, photo });
        }

        public async Task LogoutAsync()
        {
            await hubProxy.Invoke("Logout");
        }

        public async Task SendBroadcastImageAsync(byte[] img)
        {
            await hubProxy.Invoke("BroadcastPictureMessage", img);
        }

        public async Task SendBroadcastMessageAsync(string msg)
        {
            await hubProxy.Invoke("BroadcastTextMessage", msg);
        }

        public async Task SendUnicastImageAsync(string recepient, byte[] img)
        {
            await hubProxy.Invoke("UnicastPictureMessage", new object[] {recepient,img });
        }

        public async Task SendUnicastTextMessageAsync(string recepient, string msg)
        {
            await hubProxy.Invoke("UnicastTextMessage", new object[] { recepient, msg });
        }

        public async Task TypingAsync(string recepient)
        {
            await hubProxy.Invoke("Typing", recepient);
        }
    }
}
