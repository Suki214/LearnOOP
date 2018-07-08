using BanksInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfNonyYe
{
    [Export(typeof(ICard))]
    public class NHCard : ICard
    {
        public double Money { get; set; }

        public void CheckoutMoney(double money)
        {
            Money -= money;
        }

        public string GetAccountInfo()
        {
            return "Nony Ye Bank";
        }

        public void SaveMoney(double money)
        {
            Money += money;
        }
    }
}
