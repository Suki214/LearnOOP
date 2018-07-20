using ChatClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.Models
{
    public class Participant:ViewModelBase
    {
        public string Name { get; set; }
        public byte[] Photo { get; set; }
        public ObservableCollection<ChatMessage> Chatter { get; set; }

        private bool isLoggedIn;
        public bool IsLoggedIn
        {
            get
            {
                return isLoggedIn;
            }
            set
            {
                isLoggedIn = value;
                OnPropertyChanged();
            }
        }

        public bool hasSendMessage;
        public bool HasSendMessage
        {
            get
            {
                return hasSendMessage;
            }
            set
            {
                hasSendMessage = value;
                OnPropertyChanged();
            }
        }

        public bool isTyping;
        public bool IsTyping
        {
            get { return isTyping; }
            set
            {
                isTyping = value;
                OnPropertyChanged();
            }
        }

        public Participant()
        {
            Chatter = new ObservableCollection<ChatMessage>();
        }
    }
}
