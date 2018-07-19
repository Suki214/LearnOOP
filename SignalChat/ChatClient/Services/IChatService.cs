using ChatClient.Enums;
using ChatClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.Services
{
    public interface IChatService
    {
        event Action<User> ParticipantLoggedIn;
        event Action<string> ParticipantLoggedOut;
        event Action<string> ParticipantDisconnected;
        event Action<string> ParticipantReconnected;
        event Action ConnectionReconnecting;
        event Action ConnectionReconnected;
        event Action ConnectionClosed;
        event Action<string, string, MessageType> NewTextMessage;
        event Action<string, byte[], MessageType> NewImageMessage;
        event Action<string> PaticipantTyping;

        Task ConnectAsync();
        Task<List<User>> LoginAsync(string name, byte[] photo);
        Task LogoutAsync();
        Task SendBroadcastMessageAsync(string msg);
        Task SendBroadcastImageAsync(byte[] img);
        Task SendUnicastTextMessageAsync(string recepient, string msg);
        Task SendUnicastImageAsync(string recepient, byte[] img);
        Task TypingAsync(string recepient);
    }
}
