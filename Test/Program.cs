using System;
using System.IO;
using System.Text;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
           var testfile = File.ReadAllText("BgMaxfil3.txt", Encoding.GetEncoding(28591));
           var bgf = new BankGiroPayment.BankGiroPayment();
           var file = bgf.ParseBankGiroPayment(testfile);

           Console.Write(file);
           Console.ReadLine();
           

        }

    }
}
