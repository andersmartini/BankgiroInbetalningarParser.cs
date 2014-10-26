using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankGiroPayment;
using System.IO;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
           string testfile = File.ReadAllText("BgMaxfil3.txt", Encoding.GetEncoding(28591));
           BankGiroPayment.BankGiroPayment bgf = new BankGiroPayment.BankGiroPayment();
           BankGiroPaymentFile file = bgf.parseBankGiroPayment(testfile);

           Console.Write(file);
           Console.ReadLine();
           

        }

    }
}
