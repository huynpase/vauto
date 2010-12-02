using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace Vibz.Security
{
    public class Cryptograph
    {
        public static string Decrypt(string stringToDecrypt, string sEncryptionKey)
        {
            //Decrypts strings using the parsed Private Key: 
            byte[] key = { };
            byte[] IV = { 10, 20, 30, 40, 50, 60, 70, 80 };
            byte[] inputByteArray = new byte[stringToDecrypt.Length];
            key = Encoding.UTF8.GetBytes(sEncryptionKey.Substring(0, 8));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            inputByteArray = Convert.FromBase64String(stringToDecrypt.Replace(" ", "+"));
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(key, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            Encoding encoding = Encoding.UTF8;
            return encoding.GetString(ms.ToArray());
        }

        public static string Encrypt(string stringToEncrypt, string sEncryptionKey)
        {
            //Encrypts strings using the parsed Private Key: 
            byte[] key = { };
            byte[] IV = { 10, 20, 30, 40, 50, 60, 70, 80 };
            byte[] inputByteArray;
            key = Encoding.UTF8.GetBytes(sEncryptionKey.Substring(0, 8));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            inputByteArray = Encoding.UTF8.GetBytes(stringToEncrypt);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(key, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Convert.ToBase64String(ms.ToArray());
        }

        public static string generateRandomPrivateKey()
        {
            //Generates an 8-bit Private Key: 
            int[] key = new int[8];
            Random rnd = new Random();
            key[0] = rnd.Next(1, 9);
            key[1] = rnd.Next(0, 9);
            key[2] = rnd.Next(0, 9);
            key[3] = rnd.Next(0, 9);
            key[4] = rnd.Next(0, 9);
            key[5] = rnd.Next(0, 9);
            key[6] = rnd.Next(0, 9);
            key[7] = rnd.Next(0, 9);
            string pvtKey = String.Empty;
            foreach (int i in key)
            {
                pvtKey += i.ToString();
            }
            return pvtKey;
        } 


    }
}
