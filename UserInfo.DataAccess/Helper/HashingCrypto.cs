using System;
using System.Security.Cryptography;
using System.Text;

namespace UserInfo.DataAccess.Helper
{
    
    public class HashingCrypto
    {
        private static string key = "altamira_example_project";
        public static string hashPassword(string pass)
        {
            pass += key;
            SHA512CryptoServiceProvider cryptoServiceProvider = new SHA512CryptoServiceProvider();
            byte[] pass_bytes = Encoding.ASCII.GetBytes(pass);
            byte[] pass_encrpted_bytes =cryptoServiceProvider.ComputeHash(pass_bytes);
            return Convert.ToBase64String(pass_encrpted_bytes);
        }
        public static bool comparePassword(string login_Pass, string pass)
        {
            var loginPass = hashPassword(login_Pass);
            if (loginPass == pass)
            {
                return true;
            }
            return false;
        }
    }
}
