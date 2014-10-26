using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankGiroPayment
{
    public partial class BankGiroPaymentFile
        ///this partial contains the structure of the returned classes
        ///some classes are nested as lists within others as visible below
    {
        public DateTime timestamp {get;set;}
        public List<Section> sections = new List<Section>();
    }

    public class Section{
        public string PayingOrgNumber { get; set; }
        public string recieverBgNumber { get; set; }
        public string recieverBgPlusNumber { get; set; }
        public string currency { get; set; }
        public string recieverBankAcount { get; set; }
        public DateTime payDate { get; set; }
        public string transferSerialNumber { get; set; }
        public float totalAmount { get; set; }
        public int numTransfers { get; set; }           ///Total number of payments and deduction in this section
        public List<Payment> payments = new List<Payment>();
        public List<Payment> deductions = new List<Payment>();
        public List<string> info = new List<string>();
        public string payerName { get; set; }
        public List<string> additionalNames = new List<string>();
        public string payersAddress { get; set; }
        public string payersPostCode { get; set; }
        public string payersCity { get; set; }
        public string payersCountry { get; set; }
        public string payersCountryCode { get; set; }
 
    }
    public class Payment
    {
        public string senderBgNumber { get; set; }
        public string paymentChannel { get; set; }
        public float amount { get; set; }
        public string BgSerialNumber { get; set; }
        public bool hasImage { get; set; }
        public string referenceString { get; set; }     ///Possibly multiple references, may contain erronous refs as well, usually seperated in some way  [ " Se BG6040, tabell 5 " ]
        public List<string> Refs = new List<string>();  ///list of correct references from reference-type posts (posttype 22)  [ " Se BG6040, tabell 5 " ]
    }

}
