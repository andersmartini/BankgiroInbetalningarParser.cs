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
        public List<section> sections;
    }

    public class section{
        public string PayingOrgNumber { get; set; }
        public string recieverBgNumber { get; set; }
        public string recieverBgPlusNumber { get; set; }
        public string currency { get; set; }
        public string recieverBankAcount { get; set; }
        public DateTime payDate { get; set; }
        public string transferSerialNumber { get; set; }
        public float totalAmount { get; set; }
        public int numTransfers { get; set; }
        public List<payment> payments;
        public List<payment> deductions;
        public List<string> info;
        public string payerName { get; set; }
        public List<string> additionalNames;
    }
    public class payment
    {
        public string senderBgNumber { get; set; }
        public string paymentChannel { get; set; }
        public float amount { get; set; }
        public string BgSerialNumber { get; set; }
        public bool hasImage { get; set; }
    }

}
