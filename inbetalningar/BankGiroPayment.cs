using System;
using System.IO;

namespace BankGiroPayment
{
    public class BankGiroPayment
    {
        protected DateTime CurrentDocDate;
        public BankGiroPaymentFile ParseBankGiroPayment (string doc)
        {
            var readDoc = new StringReader(doc);
            var bgp = new BankGiroPaymentFile();
            var post = string.Empty;
            do
            {
               post = " " + readDoc.ReadLine();
               if(post != " ")
               {
                    var tk = post.Substring(1,2);
                    switch(tk)
                    {
                        case "01":
                            bgp.Init(post);
                            break;

                        case "05":
                            bgp.StartSection(post);
                            break;

                        case"15":
                            bgp.EndSection(post);
                            break;

                        case "20":
                            bgp.AddPayment(post);
                            break;

                        case "21":
                            bgp.AddDeduction(post);
                            break;

                        case "22":
                            bgp.AddRefference(post);
                            break;

                        case "23":
                            break;


                        case "25":
                            bgp.AddInfo(post);
                            break;

                        case "26":
                            bgp.AddName(post);
                            break;

                        case "27":
                            bgp.AddAddress(post);
                            break;

                        case "28":
                            bgp.AddAddress2(post);
                            break;

                        

                       
                        
                        case "29":
                            bgp.AddOrgNumber(post);
                            break;

                        case "70":
                            return bgp;
                        

                        default:
                            var m =  "Encountered an unexpected (post-type identifier) value while parsing file from BankGirot";
                            throw new Exception(m);
                    }
               }
            }    
            while(post != " ");   
    
            return bgp;


        }
    }
}
