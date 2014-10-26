using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankGiroPayment;
using System.IO;
using System.Text;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SectionTotalsIsCorrect()
        {
            string testfile = File.ReadAllText("BgMaxfil3.txt", Encoding.GetEncoding(28591));
            BankGiroPayment.BankGiroPayment bgf = new BankGiroPayment.BankGiroPayment();
            BankGiroPaymentFile file = bgf.parseBankGiroPayment(testfile);

            foreach(Section section in file.sections)
            {
                float calculatedTotal = (float)0;
                foreach (Payment payment in section.payments) 
                {
                    calculatedTotal += payment.amount;
                }
                foreach (Payment deduction in section.deductions) 
                {
                    calculatedTotal -= deduction.amount;
                }

                Assert.AreEqual(calculatedTotal, section.totalAmount);
            }

        }

        [TestMethod]
        public void ReferencesAreCorrect() 
        {
            
        }
    }
}
