using System.Windows.Controls.Ribbon;

namespace PrismTwitterReader
{
    public partial class ShellWindow : RibbonWindow
    {                
        public ShellWindow(ShellWindowViewModel shellWindowViewModel)
        {
            InitializeComponent();
            
            DataContext = shellWindowViewModel;
        }
    }
}
