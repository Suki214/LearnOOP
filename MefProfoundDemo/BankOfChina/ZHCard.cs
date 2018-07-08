using BankInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfChina
{
    [ExportCard(CardType = "BankOFChina")]
    public class ZHCard : ICard
    {
        public double Money { get ; set ; }
       

        public string GetCardInfo()
        {
            return "Bank Of China";
        }

        public void CheckoutMoney(double money)
        {
            Money -= money;
        }

        public void SaveMoney(double money)
        {
            Money += money;
        }
    }
}
