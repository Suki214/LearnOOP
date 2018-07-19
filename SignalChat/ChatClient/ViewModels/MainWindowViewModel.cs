using ChatClient.Commands;
using ChatClient.Services;
using System.Windows.Input;
using System.Drawing;
using System;
using System.Threading.Tasks;

namespace ChatClient.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private IDialogService dialogService;
        private const int MAX_IMAGE_WIDTH = 150;
        private const int MAX_IMAGE_HEIGHT = 150;
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
                OnPropertyChanged("ProfilePic");
            }
        }

        #region UserName
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

        #region IsConnected
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

        #region IsLogin
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
            #endregion
        }

        private bool CanLogin()
        {
            return !string.IsNullOrEmpty(UserName) && UserName.Length >= 2 && IsConnected;
        }

        private async Task<bool> Login()
        {
            throw new NotImplementedException();
        }
    }
}
