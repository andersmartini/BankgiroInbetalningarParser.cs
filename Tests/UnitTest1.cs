using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {

        
        [TestMethod]
        public void SectionTotalsIsCorrect()
        {
             var testfile = File.ReadAllText("BgMaxfil3.txt", Encoding.GetEncoding(28591));
             var bgf = new BankGiroPayment.BankGiroPayment();
             var file = bgf.ParseBankGiroPayment(testfile);
    

            foreach(var section in file.Sections)
            {
                var calculatedTotal = (float)0;
                foreach (var payment in section.Payments) 
                {
                    calculatedTotal += payment.Amount;
                }
                foreach (var deduction in section.Deductions) 
                {
                    calculatedTotal -= deduction.Amount;
                }

                Assert.AreEqual(calculatedTotal, section.TotalAmount);
            }

        }

        [TestMethod]
        public void ReferencesAreCorrect() 
        {
            var testfile = File.ReadAllText("BgMaxfil3.txt", Encoding.GetEncoding(28591));
            var bgf = new BankGiroPayment.BankGiroPayment();
            var file = bgf.ParseBankGiroPayment(testfile);
            var firstSection = file.Sections.First();
            var refs = new List<string>(new string[] { "657866", "658765", "657767" });

            Assert.AreEqual(firstSection.Payments[1].Refs, refs);
            

        }
    }
}
