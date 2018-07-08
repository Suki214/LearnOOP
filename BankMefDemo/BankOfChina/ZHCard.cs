using BanksInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfChina
{
    [Export(typeof(ICard))]
    public class ZHCard : ICard
    {
        public double Money { get; set; }

        public void CheckoutMoney(double money)
        {
            Money = Money - money;
        }

        public string GetAccountInfo()
        {
            return "Bank of China";
        }

        public void SaveMoney(double money)
        {
            Money = Money - money;
        }
    }
}
