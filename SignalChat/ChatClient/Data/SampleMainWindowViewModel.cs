using ChatClient.Models;
using ChatClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.Data
{
    public class SampleMainWindowViewModel : ViewModelBase
    {
        private string userName;
        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Participant> participants=new ObservableCollection<Participant>();
        public ObservableCollection<Participant> Participants
        {
            get { return participants; }
            set
            {
                participants = value;
                OnPropertyChanged();
            }
        }

        private Participant selectedParticipant;
        public Participant SelectedParticipant
        {
            get { return selectedParticipant; }
            set
            {
                selectedParticipant = value;
                if (SelectedParticipant.HasSendMessage) SelectedParticipant.HasSendMessage = false;
                OnPropertyChanged();
            }
        }

        public SampleMainWindowViewModel()
        {
            ObservableCollection<ChatMessage> someChatter = new ObservableCollection<ChatMessage>();

            someChatter.Add(new ChatMessage
            {
                Author = "AA",
                Message = "Hi, i am Aa",
                Time = DateTime.Now,
                IsOriginNative = true
            });

            someChatter.Add(new ChatMessage
            {
                Author = "BB",
                Message = "Hi, i am BB",
                Time = DateTime.Now,
                IsOriginNative = true
            });

            someChatter.Add(new ChatMessage
            {
                Author = "CC",
                Message = "Hi, i am CC",
                Time = DateTime.Now,
                IsOriginNative = true
            });

            someChatter.Add(new ChatMessage
            {
                Author = "DD",
                Message = "Hi, i am DD",
                Time = DateTime.Now,
                IsOriginNative = true
            });

            Participants.Add(new Participant { Name = "AA", Chatter = someChatter, IsTyping = true, IsLoggedIn = true });
            Participants.Add(new Participant { Name = "BB", Chatter = someChatter, IsLoggedIn = false });
            Participants.Add(new Participant { Name = "CC", Chatter = someChatter, HasSendMessage=true });
            Participants.Add(new Participant { Name = "DD", Chatter = someChatter, IsTyping = true, IsLoggedIn = true });

            SelectedParticipant = Participants.First();
        }
    }
}
