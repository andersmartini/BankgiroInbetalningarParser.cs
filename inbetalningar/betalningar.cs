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
        private section currentSection;
        public void init(string post)
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

        public void addName (string post)
        {
            currentSection.payerName = post.Substring(3, 35);
            string Names = post.Substring(38, 35);
            currentSection.additionalNames.Add(Names);
        }

        internal void startSection(string post)
        {
            if(this.currentSection == null){
            section section = new section();
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
            payment pay = parsePaymentOrDeductionPost(post);

            currentSection.payments.Add(pay);
        }
        internal void addDeduction(string post) 
        {
            payment deduct = parsePaymentOrDeductionPost(post);

            currentSection.deductions.Add(deduct);
        }

        internal void addOrgNumber(string post) 
        {
            currentSection.PayingOrgNumber = post.Substring(5, 10);
        }

        internal void endSection(string post) 
        {
            string recieverBankAcount = post.Substring(3,35);
            DateTime payDate = Convert.ToDateTime(post.Substring(38,8));
            string transferSerialNumber = post.Substring(46,5);
            float totalAmount = float.Parse(post.Substring(51,18));
            sections.Add(currentSection);
            currentSection = null;
        }
        internal void addInfo(string post) 
        {
            string info = post.Substring(3, 50);
            currentSection.info.Add(info);
        }

        private payment parsePaymentOrDeductionPost(string post)
        {
            payment pay = new payment();
            pay.senderBgNumber = post.Substring(3,10);
            pay.paymentChannel = post.Substring(57,1);
            pay.amount =(float.Parse(post.Substring(38,18), CultureInfo.InvariantCulture.NumberFormat) / 100);
            pay.BgSerialNumber = post.Substring(58, 12);
            return pay;
        }



    }


}
