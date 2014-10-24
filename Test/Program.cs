using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankGiroPayment;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
           string testfile = "01BGMAX               0120040525173035010331P               " + Environment.NewLine + "050009912346          SEK                                         " + Environment.NewLine + "200003783511                   655968000000000000100000220000000000100   " + Environment.NewLine + "26Kalles Plåt AB                                               " + Environment.NewLine + "27Storgatan 2                        12345                                  " + Environment.NewLine + "28Storåker                                                                      " + Environment.NewLine + "29005500001234                                                                  " + Environment.NewLine + "21000378351189854                    0000000000000500003200023000011100         " + Environment.NewLine + "26Kalles Plåt AB                                                                " + Environment.NewLine + "27Storgatan 2                        12345                                      " + Environment.NewLine + "28Storåker                                                                      " + Environment.NewLine + "29005500001234                                                                  " + Environment.NewLine + "200003783511657866 658765 657767     000000000000140000320000000000140          " + Environment.NewLine + "220003783511                   657866000000000000000000220000000000140          " + Environment.NewLine + "220003783511                   658765000000000000000000220000000000140          " + Environment.NewLine + "220003783511                   657767000000000000000000220000000000140          " + Environment.NewLine + "25Betalning med extra refnr 657965                                              " + Environment.NewLine + "26Kalles Plåt AB                                                                " + Environment.NewLine + "27Storgatan 2                        12345                                      " + Environment.NewLine + "28Storåker                                                                      " + Environment.NewLine + "29005500001234                                                                  " + Environment.NewLine + "15000000000000000000058410000010098232004052500074000000000000190000SEK00000003 " + Environment.NewLine + "7000000008000000010000000800000003";

           BankGiroPayment.BankGiroPayment bgf = new BankGiroPayment.BankGiroPayment();
           BankGiroPaymentFile file = bgf.parseBankGiroPayment(testfile);

           Console.Write(file);
           Console.ReadLine();
           

        }

    }
}
