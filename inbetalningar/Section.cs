using System;
using System.Collections.Generic;

namespace BankGiroPayment
{
    public class Section{
        public string PayingOrgNumber { get; set; }
        public string RecieverBgNumber { get; set; }
        public string RecieverBgPlusNumber { get; set; }
        public string Currency { get; set; }
        public string RecieverBankAcount { get; set; }
        public DateTime PayDate { get; set; }
        public string TransferSerialNumber { get; set; }
        public float TotalAmount { get; set; }
        public int NumTransfers { get; set; }           ///Total number of payments and deduction in this section
        public List<Payment> Payments = new List<Payment>();
        public List<Payment> Deductions = new List<Payment>();
        public List<string> Info = new List<string>();
        public string PayerName { get; set; }
        public List<string> AdditionalNames = new List<string>();
        public string PayersAddress { get; set; }
        public string PayersPostCode { get; set; }
        public string PayersCity { get; set; }
        public string PayersCountry { get; set; }
        public string PayersCountryCode { get; set; }
 
    }
}