using System.Windows.Controls;

namespace PrismTwitterReader.LiveTweetsModule
{
    public partial class LiveTweets : UserControl
    {
        public LiveTweets(LiveTweetsViewModel liveTweetsViewModel)
        {
            InitializeComponent();

            DataContext = liveTweetsViewModel;
        }
    }
}
