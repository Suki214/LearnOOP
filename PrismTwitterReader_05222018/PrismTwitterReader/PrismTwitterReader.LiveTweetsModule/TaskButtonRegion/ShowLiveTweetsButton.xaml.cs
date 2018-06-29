using System.Windows.Controls;

namespace PrismTwitterReader.LiveTweetsModule
{
    public partial class ShowLiveTweetsButton : UserControl
    {
        public ShowLiveTweetsButton(ShowLiveTweetsButtonViewModel showLiveTweetsButtonViewModel)
        {
            InitializeComponent();

            DataContext = showLiveTweetsButtonViewModel;
        }
    }
}
