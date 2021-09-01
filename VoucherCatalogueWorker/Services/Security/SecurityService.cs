using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace VoucherCatalogueWorker.Services.Security
{
    public class SecurityService
    {
         public static string Sha256FromString(string strData)
        {
            var message = Encoding.ASCII.GetBytes(strData);
            SHA256Managed hashString = new SHA256Managed();
            string hex = "";

            var hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                hex += String.Format("{0:x2}", x);
            }
            return hex;
        }
        public static string GetMobileHash(string mobileNumber)
        {
            string hashedMobileNumber = String.Empty;
            if (!String.IsNullOrEmpty(mobileNumber))
            {
                var message = Encoding.ASCII.GetBytes("+91" + mobileNumber + "ZmxpcGthcnQ=");
                SHA256Managed hashString = new SHA256Managed();

                var hashValue = hashString.ComputeHash(message);
                foreach (byte x in hashValue)
                {
                    hashedMobileNumber += String.Format("{0:x2}", x);
                }
            }
            return hashedMobileNumber;
        }
    }
}
