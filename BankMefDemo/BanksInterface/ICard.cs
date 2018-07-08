using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanksInterface
{
    public interface ICard
    {
        double Money { get; set; }

        string GetAccountInfo();

        void SaveMoney(double money);

        void CheckoutMoney(double money);
    }
}
