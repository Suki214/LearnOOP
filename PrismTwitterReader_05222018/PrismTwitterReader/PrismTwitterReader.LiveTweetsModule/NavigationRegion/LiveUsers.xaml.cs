using System.Windows.Controls;

namespace PrismTwitterReader.LiveTweetsModule
{
    public partial class LiveUsers : UserControl
    {
        public LiveUsers(LiveUsersViewModel liveUsersViewModel)
        {
            InitializeComponent();

            DataContext = liveUsersViewModel;
            
        }
    }
}
