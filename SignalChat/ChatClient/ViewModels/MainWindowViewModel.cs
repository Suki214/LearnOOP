using ChatClient.Commands;
using ChatClient.Enums;
using ChatClient.Models;
using ChatClient.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
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
    }
}
