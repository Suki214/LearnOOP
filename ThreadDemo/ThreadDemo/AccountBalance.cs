using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadDemo
{
   public class AccountBalance
    {
        public  int myBalance;

        public AccountBalance(int balance)
        {
            myBalance = balance;
        }

        public bool Withdraw(int money)
        {
            lock (this) { 
            if (myBalance >= money)
            {
                myBalance -= money;
            }
            return myBalance>0;
            }
        }
    }
}
