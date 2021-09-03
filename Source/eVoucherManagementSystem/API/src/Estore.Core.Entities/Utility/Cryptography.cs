using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Estore.Core.Entities.Utility
{
    public class Cryptography
    {
        public string EncryptString(string strData, string strKey)
        {
            RijndaelManaged AES = new RijndaelManaged();
            AES.Mode = CipherMode.CBC;
            AES.KeySize = 256;
            AES.BlockSize = 128;
            byte[] keyBytes = Encoding.UTF8.GetBytes(strKey);
            byte[] encryptionkeyBytes = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

            int len = keyBytes.Length;
            if (len > encryptionkeyBytes.Length)
            {
                len = encryptionkeyBytes.Length;
            }
            Array.Copy(keyBytes, encryptionkeyBytes, len);

            AES.Key = encryptionkeyBytes;
            AES.IV = encryptionkeyBytes;
            ICryptoTransform encryptor = AES.CreateEncryptor();
            byte[] textDataByte = Encoding.UTF8.GetBytes(strData);
            return Convert.ToBase64String(encryptor.TransformFinalBlock(textDataByte, 0, textDataByte.Length));
        }

        public string EncryptStringUsingMemoryStream(string strData, string strKey)
        {
            // Get the bytes of the string
            byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(strData);
            byte[] keyBytes = Encoding.UTF8.GetBytes(strKey);

            // Hash the password with SHA256
            keyBytes = SHA256.Create().ComputeHash(keyBytes);

            byte[] bytesEncrypted = AESEncrypt(bytesToBeEncrypted, keyBytes);

            string result = Convert.ToBase64String(bytesEncrypted);

            return result;
        }

        public static byte[] AESEncrypt(byte[] bytesToBeEncrypted, byte[] keyBytes)
        {
            byte[] encryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(keyBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }
                    encryptedBytes = ms.ToArray();
                }
            }

            return encryptedBytes;
        }

        public string DecryptString(string strData, string strKey)
        {
            RijndaelManaged objrij = new RijndaelManaged();
            objrij.Mode = CipherMode.CBC;
            objrij.Padding = PaddingMode.PKCS7;

            objrij.KeySize = 0x80;
            objrij.BlockSize = 0x80;
            byte[] encryptedTextByte = Convert.FromBase64String(strData);
            byte[] passBytes = Encoding.UTF8.GetBytes(strKey);
            byte[] EncryptionkeyBytes = new byte[0x10];
            int len = passBytes.Length;
            if (len > EncryptionkeyBytes.Length)
            {
                len = EncryptionkeyBytes.Length;
            }
            Array.Copy(passBytes, EncryptionkeyBytes, len);
            objrij.Key = EncryptionkeyBytes;
            objrij.IV = EncryptionkeyBytes;
            byte[] TextByte = objrij.CreateDecryptor().TransformFinalBlock(encryptedTextByte, 0, encryptedTextByte.Length);
            return Encoding.UTF8.GetString(TextByte);  //it will return readable string 

        }

        public string DecryptStringUsingMemoryStream(string strData, string strKey)
        {

            byte[] bytesToBeDecrypted = Convert.FromBase64String(strData);
            byte[] keyBytes = Encoding.UTF8.GetBytes(strKey);
            keyBytes = SHA256.Create().ComputeHash(keyBytes);
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            byte[] decryptedBytes = null;
            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(keyBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);
                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cs.Close();
                    }
                    decryptedBytes = ms.ToArray();
                }
            }
            return Encoding.UTF8.GetString(decryptedBytes);
        }
    }
}
