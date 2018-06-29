using System.Windows.Controls;

namespace PrismTwitterReader.SavedTweetsModule
{
    public partial class SavedTweets : UserControl
    {
        public SavedTweets(SavedTweetsViewModel _savedTweetsViewModel)
        {
            InitializeComponent();

            DataContext = _savedTweetsViewModel;
        }
    }
}
