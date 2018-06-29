using System.Windows.Controls;

namespace PrismTwitterReader.SavedTweetsModule
{    
    public partial class ShowSavedTweetsButton : UserControl
    {
        public ShowSavedTweetsButton(ShowSavedTweetsButtonViewModel showSavedTweetsButtonViewModel)
        {
            InitializeComponent();

            DataContext = showSavedTweetsButtonViewModel;
        }
    }
}
