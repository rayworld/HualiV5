////////////////////////////////////////
//ver		:1.1.0.0
//Create by  	:Ray
//Create Date	:2012-11-29
//last Update	:2012-11-30
//Description	:Ray Encrypt Utilty
//UpdateLog	:
//2012-11-30	新增MD5Encrypt()
//2012-11-30	新增HashEncrypt()
//2012-11-30	新增MD5HashCodeEncrypt()
//2012-11-30	新增HashCodeMD5Encrypt
//2018-03-10    加重载
/////////////////////////////////////////
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Ray.Framework.Encrypt
{
    public sealed class EncryptHelper
    {
        /// <summary>
        /// 默认的key
        /// </summary>
        static string key = "77052300";
        public EncryptHelper()
        { }

        /// <summary>  
        ///方法一:  
        ///此种加密之后的字符串是三十二位的(字母加数据)字符串   
        /// Example:password是admin 加密变成后21232f297a57a5a743894a0e4a801fc3  
        /// </summary>  
        /// <param name="beforeStr"></param>  
        /// <returns></returns>  
        public static string MD5Encrypt(string beforeStr)
        {
            string afterString = "";
            try
            {
                MD5 md5 = MD5.Create();
                byte[] hashs = md5.ComputeHash(Encoding.UTF8.GetBytes(beforeStr));

                foreach (byte by in hashs)
                    //这里是字母加上数据进行加密.//3y 可以,y3不可以或 x3j等应该是超过32位不可以  
                    afterString += by.ToString("x2");
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return afterString;
        }
        /// <summary>  
        /// 方法:二  
        ///HashAlgorithm加密  
        /// 这种加密是 字母加-加字符   
        /// Example:password是admin 加密变成后19-A2-85-41-44-B6-3A-8F-76-17-A6-F2-25-01-9B-12  
        /// </summary>  
        /// <param name="password"></param>  
        /// <returns></returns>  
        public static String HashEncrypt(string password)
        {
            Byte[] hashedBytes = null;
            try
            {
                Byte[] clearBytes = new UnicodeEncoding().GetBytes(password);
                hashedBytes = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(clearBytes);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return BitConverter.ToString(hashedBytes);//MD5加密  
        }

        /// <summary>  
        /// 方法:三  
        /// MD5  +  HashCode加密  
        /// Example:password是admin 加密变成后 895b7da64943134be17b825ce118456c  
        /// </summary>  
        /// <returns></returns>  
        public static String MD5HashCodeEncrypt(string EncryptPwd)
        {
            return MD5Encrypt(HashEncrypt(EncryptPwd)); //在HashEncrypt基础上再MD5  
        }

        /// <summary>  
        /// 方法:四  
        /// HashCode+MD5 加密  
        /// Example:password是admin 加密变成后EB-1D-6D-E2-FC-F1-CD-94-4D-75-78-E6-3D-7A-12-32  
        /// </summary>  
        /// <param name="EncryptPwd"></param>  
        /// <returns></returns>  
        public static String HashCodeMD5Encrypt(string EncryptPwd)
        {
            return HashEncrypt(MD5Encrypt(EncryptPwd)); //在MD5基础再HashCode  
        }
        /// <summary>  
        /// 方法:五  
        /// </summary>  
        /// <param name="EncryptPwd"></param>  
        /// <returns></returns>
        public static String HashMD5Encrypt(string EncryptPwd)
        {
            return HashCodeMD5Encrypt(HashCodeMD5Encrypt(EncryptPwd)); //在HashCodeMD5Encrypt基础再HashCode  
        }
        /// <summary>  
        /// 方法:六  
        /// 哈哈 是不是  有点晕呢？  
        /// 大家伙可以继续写下去  
        /// </summary>  
        /// <param name="EncryptPwd"></param>  
        /// <returns></returns>  
        public static string MD5HashEncrypt(string EncryptPwd)
        {
            return MD5HashCodeEncrypt(MD5HashCodeEncrypt(EncryptPwd)); //在MD5基础再HashCode  
        }

        private static byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };


        /// <summary>
        /// 
        /// </summary>
        /// <param name="Key"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Encrypt(string Key, string str)
        {
            byte[] bKey = Encoding.UTF8.GetBytes(Key.Substring(0, 8));
            byte[] bIV = IV;
            byte[] bStr = Encoding.UTF8.GetBytes(str);
            try
            {
                DESCryptoServiceProvider desc = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, desc.CreateEncryptor(bKey, bIV), CryptoStreamMode.Write);
                cStream.Write(bStr, 0, bStr.Length);
                cStream.FlushFinalBlock();
                return Convert.ToBase64String(mStream.ToArray());
            }
            catch
            {
                return string.Empty;
            }
        }

        public static string Decrypt(string Key, string DecryptStr)
        {
            try
            {
                byte[] bKey = Encoding.UTF8.GetBytes(Key.Substring(0, 8));
                byte[] bIV = IV;
                byte[] bStr = Convert.FromBase64String(DecryptStr);
                DESCryptoServiceProvider desc = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, desc.CreateDecryptor(bKey, bIV), CryptoStreamMode.Write);
                cStream.Write(bStr, 0, bStr.Length);
                cStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(mStream.ToArray());
            }
            catch
            {
                return string.Empty;
            }
        }

        #region 重载

        public static string Decrypt(string decryptString)
        {
            return Decrypt(key, decryptString);
        }

        public static string Encrypt(string encryptString)
        {
            return Encrypt(key, encryptString);
        }

        #endregion
    }
}