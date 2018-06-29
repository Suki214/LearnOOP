using System.Windows.Controls;

namespace PrismTwitterReader.SavedTweetsModule
{    
    public partial class SavedUsers : UserControl
    {
        public SavedUsers(SavedUsersViewModel _savedUsersViewModel)
        {
            InitializeComponent();

            DataContext = _savedUsersViewModel;
        }
    }
}
