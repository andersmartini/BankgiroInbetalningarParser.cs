using System.Collections.Generic;

namespace BankGiroPayment
{
    public class Payment
    {
        public string SenderBgNumber { get; set; }
        public string PaymentChannel { get; set; }
        public float Amount { get; set; }
        public string BgSerialNumber { get; set; }
        public bool HasImage { get; set; }
        public string ReferenceString { get; set; }     ///Possibly multiple references, may contain erronous refs as well, usually seperated in some way  [ " Se BG6040, tabell 5 " ]
        public List<string> Refs = new List<string>();  ///list of correct references from reference-type posts (posttype 22)  [ " Se BG6040, tabell 5 " ]
    }
}