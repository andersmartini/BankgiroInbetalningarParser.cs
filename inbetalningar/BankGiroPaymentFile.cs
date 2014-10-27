using System;
using System.Globalization;
using System.Linq;

namespace BankGiroPayment
{
    public partial class BankGiroPaymentFile
    {
        private bool _intiated = false;
        private Section _currentSection;
        public DateTime CreatedDateTime { get; set; }
        internal void Init(string post)
        {
            if(_intiated)
            {
                var m = "tried to initiate already intiated object. did you join 2 files to a string?";
                throw new Exception(m);
            }else
            {
                _intiated = true;
                CreatedDateTime = DateTime.ParseExact(post.Substring(25,14),"yyyyMMddHHmmss",CultureInfo.InvariantCulture);

            }
        

        }
        internal void AddAddress(string post) 
        {
            _currentSection.PayersAddress = post.Substring(3, 35);
            _currentSection.PayersPostCode = post.Substring(38, 9);
        }

        internal void AddAddress2(string post) 
        {
            _currentSection.PayersCity = post.Substring(3, 35);
            _currentSection.PayersCountry = post.Substring(38, 35);
            _currentSection.PayersCountryCode = post.Substring(73, 2);
        }

        internal void AddName (string post)
        {
            _currentSection.PayerName = post.Substring(3, 35);
            var names = post.Substring(38, 35);
            _currentSection.AdditionalNames.Add(names);
        }

        internal void StartSection(string post)
        {
            if(_currentSection == null){
            var section = new Section();
            section.RecieverBgNumber = post.Substring(3, 10);
            section.RecieverBgPlusNumber = post.Substring(13,10);
            section.Currency = post.Substring(23,3);
            
            _currentSection = section;
            }else{
                var m= "started new section before closing old one";
                throw new Exception(m);
            }
        }


        internal void AddPayment(string post)
        {
            var pay = ParsePaymentOrDeductionPost(post);

              _currentSection.Payments.Add(pay);
        }
        internal void AddDeduction(string post) 
        {
            var deduct = ParsePaymentOrDeductionPost(post);

            _currentSection.Deductions.Add(deduct);
        }

        internal void AddOrgNumber(string post) 
        {
            _currentSection.PayingOrgNumber = post.Substring(5, 10);
        }

        internal void EndSection(string post) 
        {
            _currentSection.RecieverBankAcount = post.Substring(3,35);
            _currentSection.PayDate = DateTime.ParseExact(post.Substring(38,8),"yyyyMMdd",null);
            _currentSection.TransferSerialNumber = post.Substring(46,5);
            _currentSection.TotalAmount = (float.Parse(post.Substring(51,18))/100);

            Sections.Add(_currentSection);
            _currentSection = null;
        }
        internal void AddInfo(string post) 
        {
            var info = post.Substring(3, 50);
            _currentSection.Info.Add(info);
        }
        internal void AddRefference(string post)
        {
            var payment = _currentSection.Payments.Last();
            payment.Refs.Add(post.Substring(13,25).Trim('0'));
        }

        private Payment ParsePaymentOrDeductionPost(string post)
        {
            var pay = new Payment
                      {
                          SenderBgNumber = post.Substring(3, 10),
                          Amount =
                              (float.Parse(post.Substring(38, 18), CultureInfo.InvariantCulture.NumberFormat)/
                               100),
                          BgSerialNumber = post.Substring(58, 12),
                          ReferenceString = post.Substring(13, 25)
                      };
            switch (post.Substring(57, 1)) 
            {
                case"1":
                    pay.PaymentChannel = "1 Betalningen är en elektronisk betalning från bank.";
                break;

                case"2":
                pay.PaymentChannel = "Betalningen är en elektronisk betalning från tjänsten Leverantörsbetalningar (LB)";
                break;

                case"3":
                pay.PaymentChannel = "Betalningen är en blankettbetalning";
                break;

                case"4":
                pay.PaymentChannel = "Betalningen är en elektronisk betalning från tjänsten Autogiro (AG). Reserverad för framtida bruk";
                break;

                default:
                   throw new Exception("Error Parsing PaymentChannel, please verify the paymentdocument");
            }
            return pay;
        }



    }


}
