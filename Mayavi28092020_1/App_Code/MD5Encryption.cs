using System;
using System.Security.Cryptography;
using System.Text;
public class MD5Encryption
{
    public string Encryption(string InputString)
    {
        MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
        byte[] encrypt;
        UTF8Encoding encode = new UTF8Encoding();
        encrypt = md5.ComputeHash(encode.GetBytes(InputString));
        StringBuilder encryptdata = new StringBuilder();
        for (int i = 0; i < encrypt.Length; i++)
        {
            encryptdata.Append(encrypt[i].ToString());
        }
        return encryptdata.ToString();
    }
    public string ClientDecrypt(string strPass)
    {
        string display = "";
        byte[] AsciiVal = Encoding.ASCII.GetBytes(strPass);
        foreach (byte Pwd in AsciiVal)
        {
            int NewAscVal = Convert.ToInt32(Pwd) - 5;
            char str = (char)NewAscVal;
            display = display + str.ToString();
        }
        return display;
    }
}