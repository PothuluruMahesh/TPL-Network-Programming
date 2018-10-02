using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TaskParallelLibrary2
{
    class AccountManger
    {
        Account fA; Account TA; double ATT;
        public AccountManger(Account i, Account j, double k)
        {
            this.fA = i;
            this.TA = j;
            this.ATT = k;
        }
       public void TransforAsync()
        {           
           lock (TA) 
            {
                Thread.Sleep(1000);
                lock (fA)
                {
                    fA.WithDraw(ATT);
                    TA.Diposite(ATT);
                    Console.WriteLine(TA.ID.ToString()+" Transfor the Amount " + ATT.ToString() + " from the Account " + fA.ID.ToString());
                }
            }
        }
    }
}
