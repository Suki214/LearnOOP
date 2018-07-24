using ChatClient.Commands;
using ChatClient.Enums;
using ChatClient.Models;
using ChatClient.Services;
using Microsoft.AspNet.SignalR.Client.Hubs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ChatClient.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private IDialogService dialogService;
        private IChatService chatService;
        private const int MAX_IMAGE_WIDTH = 150;
        private const int MAX_IMAGE_HEIGHT = 150;

        #region Property ProfilePic
        private string profilePic;
        public string ProfilePic
        {
            get
            {
                return profilePic;
            }
            set
            {
                profilePic = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Property UserName
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
        #endregion

        #region Property IsConnected
        private bool isConnected;
        public bool IsConnected
        {
            get { return isConnected; }
            set
            {
                isConnected = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Property IsLogin
        private bool isLogin;
        public bool IsLogin
        {
            get { return isLogin; }
            set
            {
                isLogin = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Property Participants
        private ObservableCollection<Participant> participants;
        public ObservableCollection<Participant> Participants
        {
            get { return participants; }
            set
            {
                participants = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Property UserMode
        private UserModes userMode;
        public UserModes UserMode
        {
            get { return userMode; }
            set
            {
                userMode = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Property SelectedParticipant
        private Participant selectedParticipant;
        public Participant SelectedParticipant
        {
            get { return selectedParticipant; }
            set
            {
                selectedParticipant = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Property TextMessage
        private string textMessage;
        public string TextMessage
        {
            get { return textMessage; }
            set
            {
                textMessage = value;
                OnPropertyChanged();
            }
        }
        #endregion

        private byte [] Avator()
        {
            byte[] pic = null;
            if (!string.IsNullOrEmpty(profilePic)) pic = File.ReadAllBytes(profilePic);
            return pic;
        }

        public MainWindowViewModel(IChatService chatSvc, IDialogService diagSvc)
        {
            dialogService = diagSvc;
            chatService = chatSvc;

            chatSvc.NewTextMessage += NewTextMessage;
            chatSvc.NewImageMessage += NewImageMessage;
            chatSvc.ParticipantLoggedIn += ParticipantLogin;
            chatSvc.ParticipantLoggedOut += ParticipantDisconnection;
            chatSvc.ParticipantDisconnected += ParticipantDisconnection;
            chatSvc.ParticipantReconnected += ParticipantReconnection;
            chatSvc.PaticipantTyping += ParticipantTyping;
            chatSvc.ConnectionReconnecting += Reconnecting;
            chatSvc.ConnectionReconnected += Reconnected;
            chatSvc.ConnectionClosed += Disconnected;
        }

        #region Select Profile Picture Command
        private ICommand _SelectProfilePicCommand;
        public ICommand SelectProfilePicCommand
        {
            get
            {
                if (_SelectProfilePicCommand == null)
                {
                    _SelectProfilePicCommand = new RelayCommand((o) => SelectProfilePic());
                }
                return _SelectProfilePicCommand;
            }
        }

        private void SelectProfilePic()
        {
            var pic = dialogService.OpenFile("Select image file", "Images (*.jpg;*.png)|*.jpg;*.png");
            if (!string.IsNullOrEmpty(pic))
            {
                var img = Image.FromFile(pic);
                if (img.Width > MAX_IMAGE_WIDTH || img.Height > MAX_IMAGE_HEIGHT)
                {
                    dialogService.ShowNotification($"Image size should be {MAX_IMAGE_WIDTH} and {MAX_IMAGE_HEIGHT} or less");
                    return;
                }
                ProfilePic = pic;
            }
        }
        #endregion

        #region Connect Command
        private ICommand connectCommand;
        public ICommand ConnectCommand
        {
            get
            {
                if (connectCommand == null)
                {
                    connectCommand = new RelayCommandAsync(() => Connect());
                }
                return connectCommand;
            }
        }

        private async Task<bool> Connect()
        {
            try
            {
                await chatService.ConnectAsync();
                IsConnected = true;
                return true;
            }
            catch (Exception) { return false; }
        }
        #endregion

        #region Login Command
        private ICommand loginCommand;
        public ICommand LoginCommand
        {
            get
            {
                if (loginCommand == null)
                    loginCommand = new RelayCommandAsync(() => Login(), (o) => CanLogin());
                return loginCommand;
            }            
        }

        private bool CanLogin()
        {
            return !string.IsNullOrEmpty(UserName) && UserName.Length >= 2 && IsConnected;
        }

        private async Task<bool> Login()
        {
            try
            {
                List<User> users = new List<User>();
                users = await chatService.LoginAsync(userName, Avator());
                if (userName != null)
                {
                    users.ForEach(u => Participants.Add(new Participant { Name = u.Name, Photo = u.Photo }));
                    UserMode = UserModes.Chat;
                    IsLogin = true;
                    return true;
                }
                else
                {
                    dialogService.ShowNotification("Username is already in use");
                    return false;
                }
            }
            catch(Exception)
            {
                return false;
            }
        }
        #endregion

        #region Logout Command
        private ICommand logoutCommand;
        public ICommand LogoutCommand
        {
            get
            {
                if (logoutCommand == null)
                {
                    logoutCommand = new RelayCommandAsync(()=>Logout(), (o)=>CanLogout());
                }
                return logoutCommand;
            }
        }

        private async Task<bool> Logout()
        {
            try
            {
                await chatService.LogoutAsync();
                UserMode = UserModes.Login;
                return true;
            }
            catch (Exception) { return false; }
        }

        private bool CanLogout()
        {
            return IsConnected && IsLogin;
        }
        #endregion

        #region Typing Command
        private ICommand typingCommand;
        public ICommand TypingCommand
        {
            get
            {
                return typingCommand?? (typingCommand = new RelayCommandAsync(() => Typing(), (o) => CanUseTypingCommand()));
            }
        }

        private bool CanUseTypingCommand()
        {
            return (SelectedParticipant != null && SelectedParticipant.IsLoggedIn);
        }

        private async Task<bool> Typing()
        {
            try
            {
                await chatService.TypingAsync(SelectedParticipant.Name);
                return true;
            }
            catch (Exception) { return false; }
        }
        #endregion

        #region Send Text Message Command
        private ICommand sendTextMessageCommand;
        public ICommand SendTextMessageCommand
        {
            get
            {
                return sendTextMessageCommand ?? (sendTextMessageCommand = new RelayCommandAsync(() => SendTextMessage(), (o) => CanSendTextMessage()));
            }
        }

        private bool CanSendTextMessage()
        {
            return ( (!string.IsNullOrEmpty(textMessage) && selectedParticipant != null && selectedParticipant.IsLoggedIn));
        }

        private async Task<bool> SendTextMessage()
        {
            try
            {
                var receipt = selectedParticipant.Name;
                await chatService.SendUnicastTextMessageAsync(receipt, textMessage);
                return true;
            }
            catch (Exception) { return false; }
            finally
            {
                ChatMessage msg = new ChatMessage { Author = userName, Message = textMessage, Time = DateTime.Now, IsOriginNative = true };
                SelectedParticipant.Chatter.Add(msg);
                textMessage = string.Empty;
            }
        }
        #endregion

        #region Send Picture Message Command
        private ICommand sendPictureMessageCommand;
        public ICommand SendPictureMessageCommand
        {
            get
            {
                return sendPictureMessageCommand ?? (sendPictureMessageCommand = new RelayCommandAsync(() => SendPictureMessage(), (o) => CanSendPictureMessage()));
            }
        }

        private bool CanSendPictureMessage()
        {
            return (selectedParticipant != null && selectedParticipant.IsLoggedIn && IsConnected);
        }

        private async Task<bool> SendPictureMessage()
        {
            var pic = dialogService.OpenFile("Select image file", "Images(*.jpg;*.png)|*.jpg;*.png");
            if (string.IsNullOrEmpty(pic)) return false;

            var img = await Task.Run(() => File.ReadAllBytes(pic));

            try
            {
                var receipt = selectedParticipant.Name;
                await chatService.SendUnicastImageAsync(receipt, img);
                return true;
            }
            catch (Exception) { return false; }
            finally
            {
                ChatMessage msg = new ChatMessage { Author = userName, IsOriginNative = true, Picture = pic, Time = DateTime.Now };
                SelectedParticipant.Chatter.Add(msg);
            }
        }
        #endregion

        #region Open Image Command
        private ICommand openImageCommand;
        public ICommand OpenImageCommand
        {
            get
            {
                return openImageCommand ?? (openImageCommand = new RelayCommand<ChatMessage>((m) => OpenImage(m)));
            }
        }

        private void OpenImage(ChatMessage m)
        {
            var pic = m.Picture;
            if (string.IsNullOrEmpty(pic) || !File.Exists(pic)) return;
            Process.Start(pic);
        }
        #endregion

        #region Event Handler
        private async void Reconnected()
        {
            var pic = Avator();
            if (!string.IsNullOrEmpty(userName)) await chatService.LoginAsync(userName, pic);
            IsConnected = true;
            IsLogin = true;
        }

        private async void Disconnected()
        {
            var connectTask = chatService.ConnectAsync();
            await connectTask.ContinueWith(t=> {
                if (!t.IsFaulted)
                {
                    IsConnected = true;
                    chatService.LoginAsync(userName, Avator()).Wait();
                    IsLogin = true;
                }
            });
        }

        private void Reconnecting()
        {
            IsConnected = false;
            IsLogin = false;
        }

        private void ParticipantLogin(User u)
        {
            var ptp = Participants.FirstOrDefault(p => string.Equals(p.Name, u.Name));
            if(isLogin&& ptp == null)
            {
                Task.Run(() => Participants.Add(new Participant { Name = u.Name, Photo = u.Photo })).Wait();
            }
        }

        private void ParticipantTyping(string name)
        {
            var person = Participants.Where((p) => string.Equals(p.Name, name)).FirstOrDefault();
            if(person!=null && person.IsTyping)
            {
                person.IsTyping = true;
                Observable.Timer(TimeSpan.FromMilliseconds(1500)).Subscribe(t=>person.IsTyping = false);
            }
        }

        private void ParticipantDisconnection(string name)
        {
            var person = Participants.Where((p) => string.Equals(p.Name, name)).FirstOrDefault();
            if (person != null) person.IsLoggedIn = false;
        }

        private void ParticipantReconnection(string name)
        {
            var person = Participants.Where((p) => string.Equals(p.Name, name)).FirstOrDefault();
            if (person != null) person.IsLoggedIn = true;
        }

        private void NewTextMessage(string name, string msg, MessageType mt)
        {
            if (mt == MessageType.Unicast)
            {
                ChatMessage cm = new ChatMessage { Author = name, Message = msg, Time=DateTime.Now };
                var sender = Participants.Where((p) => string.Equals(p.Name, name)).FirstOrDefault();
                Task.Run(() => sender.Chatter.Add(cm)).Wait();

                if(!(SelectedParticipant!=null && sender.Name.Equals(SelectedParticipant.Name)))
                {
                    Task.Run(() => sender.HasSendMessage = true).Wait();
                }
            }
        }

        private void NewImageMessage(string name, byte[] pic, MessageType mt)
        {
            var imgsDirectory = Path.Combine(Environment.CurrentDirectory, "Image Messages");
            if (!Directory.Exists(imgsDirectory)) Directory.CreateDirectory(imgsDirectory);
            var imgsCount = Directory.EnumerateFiles(imgsDirectory).Count() + 1;
            var imgPath = Path.Combine(imgsDirectory, $"IMG_{imgsCount}.jpg");

            ImageConverter converter = new ImageConverter();
            using (Image img = (Image)converter.ConvertFrom(pic))
            {
                img.Save(imgPath);
            }

            ChatMessage cm = new ChatMessage { Author = name, Picture = imgPath, Time = DateTime.Now };
            var sender = Participants.Where((p) => string.Equals(p.Name, name)).FirstOrDefault();
            Task.Run(() => sender.Chatter.Add(cm)).Wait();

            if(!(SelectedParticipant!=null&& sender.Name.Equals(SelectedParticipant.Name)))
            {
                Task.Run(() => sender.HasSendMessage = true).Wait();
            }
        }
        #endregion
    }
}
