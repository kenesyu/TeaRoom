using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace IsTech.EnterpriseLibrary.Simulate
{
    public class DESUtil
    {
        public string Key = "!T2v@Soft#";
        public string InputString { get; set; }

        public string OutString { get; set; }

        public string EncryptKey { get; set; }

        public string DecryptKey { get; set; }

        public string NoteMessage { get; set; }

        public void DesEncrypt()
        {
            byte[] byKey = null;
            byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
            try
            {
                byKey = Encoding.UTF8.GetBytes(this.EncryptKey.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputByteArray = Encoding.UTF8.GetBytes(this.InputString);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                this.OutString = Convert.ToBase64String(ms.ToArray());
            }
            catch (System.Exception error)
            {
                this.NoteMessage = error.Message;
            }
        }
        public void DesDecrypt()
        {
            byte[] byKey = null;
            byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
            byte[] inputByteArray = new Byte[this.InputString.Length];
            try
            {
                byKey = Encoding.UTF8.GetBytes(DecryptKey.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                inputByteArray = Convert.FromBase64String(this.InputString);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                Encoding encoding = new System.Text.UTF8Encoding();
                this.OutString = encoding.GetString(ms.ToArray());
            }
            catch (System.Exception error)
            {
                this.NoteMessage = error.Message;
            }
        }
        public void MD5Encrypt()
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(Encoding.Default.GetBytes(this.InputString));
            this.OutString = Encoding.Default.GetString(result);
        }
    }
}
