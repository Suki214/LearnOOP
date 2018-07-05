using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizardDemo.ViewModel
{
    public class WelcomePageViewModel:WizardBaseViewModel
    {
        public override string DisplayName
        {
            get
            {
                return "Welcome";
            }
        }
    }
}
