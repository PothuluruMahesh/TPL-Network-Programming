using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TaskParallelLibrary2
{
    public class Account
    {
        int Id;
        double Balance;
        public Account(int i, double j)
        {
            this.Id = i;
            this.Balance = j;
        }
        public int ID
        {
            get { return Id; }
        }
        public async Task WithDraw(double amount)
        {
            await Task.Delay(1000);
           Balance = Balance - amount;
        }
        public void Diposite(double amount)
        {
            Balance = Balance + amount;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Main STarted..........");
            Account ac1 = new Account(10210, 5000);
            Account ac2 = new Account(20319, 2000);

            AccountManger am = new AccountManger(ac1, ac2, 2000);
            Task t1 = new Task(am.TransforAsync);
            t1.RunSynchronously();

            AccountManger am1 = new AccountManger(ac2, ac1, 1000);
            Task t2 = new Task(am1.TransforAsync);
            t2.RunSynchronously();
            Task.WaitAll();
            Console.WriteLine("Main Ended............");
        }
    }
}
