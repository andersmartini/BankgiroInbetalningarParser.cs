using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BankGiroPayment
{
    public class BankGiroPayment
    {
        protected DateTime CurrentDocDate;
        public BankGiroPaymentFile parseBankGiroPayment (string doc)
        {
            StringReader readDoc = new StringReader(doc);
            BankGiroPaymentFile bgp = new BankGiroPaymentFile();
            string post = string.Empty;
            do
            {
               post = " " + readDoc.ReadLine();
               if(post != " ")
               {
                    string TK = post.Substring(1,2);
                    switch(TK)
                    {
                        case "01":
                            bgp.init(post);
                            break;

                        case "05":
                            bgp.startSection(post);
                            break;

                        case"15":
                            bgp.endSection(post);
                            break;

                        case "20":
                            bgp.addPayment(post);
                            break;

                        case "21":
                            bgp.addDeduction(post);
                            break;

                        case "22":
                            bgp.addRefference(post);
                            break;

                        case "23":
                            break;


                        case "25":
                            bgp.addInfo(post);
                            break;

                        case "26":
                            bgp.addName(post);
                            break;

                        case "27":
                            bgp.AddAddress(post);
                            break;

                        case "28":
                            bgp.AddAddress2(post);
                            break;

                        

                       
                        
                        case "29":
                            bgp.addOrgNumber(post);
                            break;

                        case "70":
                            return bgp;
                        

                        default:
                            string m =  "Encountered an unexpected (post-type identifier) value while parsing file from BankGirot";
                            throw new System.Exception(m);
                    }
               }
            }    
            while(post != " ");   
    
            return bgp;


        }
    }
}
