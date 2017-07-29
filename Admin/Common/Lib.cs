using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Admin.Common
{
    public static class Lib
    {
        public static string Encrypt(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;
            var md5 = new MD5CryptoServiceProvider();
            byte[] valueArray = Encoding.ASCII.GetBytes(value);
            valueArray = md5.ComputeHash(valueArray);
            var sb = new StringBuilder();
            for (int i = 0; i < valueArray.Length; i++)
                sb.Append(valueArray[i].ToString("x2").ToLower());
            return sb.ToString();
        }
    }
}