using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace BankGiroPayment
{
    public partial class BankGiroPaymentFile
    {
        private bool intiated = false;
        private Section currentSection;
        internal void init(string post)
        {
            if(this.intiated)
            {
                string m = "tried to initiate already intiated object. did you join 2 files to a string?";
                throw new System.Exception(m);
            }else
            {
                this.intiated = true;
                string datestring = post.Substring(25,20);

            }
        

        }
        internal void AddAddress(string post) 
        {
            currentSection.payersAddress = post.Substring(3, 35);
            currentSection.payersPostCode = post.Substring(38, 9);
        }

        internal void AddAddress2(string post) 
        {
            currentSection.payersCity = post.Substring(3, 35);
            currentSection.payersCountry = post.Substring(38, 35);
            currentSection.payersCountryCode = post.Substring(73, 2);
        }

        internal void addName (string post)
        {
            currentSection.payerName = post.Substring(3, 35);
            string Names = post.Substring(38, 35);
            currentSection.additionalNames.Add(Names);
        }

        internal void startSection(string post)
        {
            if(this.currentSection == null){
            Section section = new Section();
            section.recieverBgNumber = post.Substring(3, 10);
            section.recieverBgPlusNumber = post.Substring(13,10);
            section.currency = post.Substring(23,3);
            
            currentSection = section;
            }else{
                string m= "started new section before closing old one";
                throw new System.Exception(m);
            }
        }


        internal void addPayment(string post)
        {
            Payment pay = parsePaymentOrDeductionPost(post);

              currentSection.payments.Add(pay);
        }
        internal void addDeduction(string post) 
        {
            Payment deduct = parsePaymentOrDeductionPost(post);

            currentSection.deductions.Add(deduct);
        }

        internal void addOrgNumber(string post) 
        {
            currentSection.PayingOrgNumber = post.Substring(5, 10);
        }

        internal void endSection(string post) 
        {
            currentSection.recieverBankAcount = post.Substring(3,35);
            currentSection.payDate = DateTime.ParseExact(post.Substring(38,8),"yyyyMMdd",null);
            currentSection.transferSerialNumber = post.Substring(46,5);
            currentSection.totalAmount = (float.Parse(post.Substring(51,18))/100);

            sections.Add(currentSection);
            currentSection = null;
        }
        internal void addInfo(string post) 
        {
            string info = post.Substring(3, 50);
            currentSection.info.Add(info);
        }
        internal void addRefference(string post) 
        {

        }

        private Payment parsePaymentOrDeductionPost(string post)
        {
            Payment pay = new Payment();
            pay.senderBgNumber = post.Substring(3,10);
            pay.amount =(float.Parse(post.Substring(38,18), CultureInfo.InvariantCulture.NumberFormat) / 100);
            pay.BgSerialNumber = post.Substring(58, 12);
            pay.referenceString = post.Substring(13, 25);
            switch (post.Substring(57, 1)) 
            {
                case"1":
                    pay.paymentChannel = "1 Betalningen är en elektronisk betalning från bank.";
                break;

                case"2":
                pay.paymentChannel = "Betalningen är en elektronisk betalning från tjänsten Leverantörsbetalningar (LB)";
                break;

                case"3":
                pay.paymentChannel = "Betalningen är en blankettbetalning";
                break;

                case"4":
                pay.paymentChannel = "Betalningen är en elektronisk betalning från tjänsten Autogiro (AG). Reserverad för framtida bruk";
                break;

                default:
                   throw new System.Exception("Error Parsing PaymentChannel, please verify the paymentdocument");
            }
            return pay;
        }



    }


}
