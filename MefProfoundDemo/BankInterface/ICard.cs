using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankInterface
{
    public interface ICard
    {
        double Money { get; set; }

        string GetCardInfo();

        void SaveMoney(double money);

        void CheckoutMoney(double money);
    }

    public interface IMetaData
    {
        string CardType { get;  }
    }
}
