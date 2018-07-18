using ChatClient.Commands;
using ChatClient.Services;
using System.Windows.Input;
using System.Drawing;

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

        public MainWindowViewModel()
        {
        }

        private ICommand _SelectProfilePicCommand;
        public ICommand SelectProfilePicCommand
        {
            get
            {
                if (_SelectProfilePicCommand == null)
                {
                    _SelectProfilePicCommand= new RelayCommand((o)=>SelectProfilePic());
                }
                return _SelectProfilePicCommand;
            }
        }

        private void SelectProfilePic()
        {
            var pic = dialogService.OpenFile("Slect image file", "Images (*.jpg;*.png)|*.jpg;*.png");
            if (!string.IsNullOrEmpty(pic))
            {
                var img = Image.FromFile(pic);
                if(img.Width>MAX_IMAGE_WIDTH||img.Height > MAX_IMAGE_HEIGHT)
                {
                    dialogService.ShowNotification($"Image size should be {MAX_IMAGE_WIDTH} and {MAX_IMAGE_HEIGHT} or less");
                    return;
                }
                ProfilePic = pic;
            }
        }
    }
}
