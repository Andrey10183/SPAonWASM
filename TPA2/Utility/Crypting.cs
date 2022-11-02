using System.Text;
using TPA2.Pages;
using TPA2.Shared;

namespace TPA2.Utility
{
    public class Crypting
    {
        public static string EncryptDecrypt(string szPlainText, int szEncryptionKey)
        {
            StringBuilder szInputStringBuild = new StringBuilder(szPlainText);
            StringBuilder szOutStringBuild = new StringBuilder(szPlainText.Length);
            char Textch;
            for (int iCount = 0; iCount < szPlainText.Length; iCount++)
            {
                Textch = szInputStringBuild[iCount];
                Textch = (char)(Textch ^ szEncryptionKey);
                szOutStringBuild.Append(Textch);
            }
            return szOutStringBuild.ToString();
        }

        public static SecurityToken EncryptDecryptToken(SecurityToken data)
        {
            var result = new SecurityToken();
            result.AccessToken = EncryptDecrypt(data.AccessToken, Constants.EncryptKey);
            result.UserName = EncryptDecrypt(data.UserName, Constants.EncryptKey);
            result.Role = EncryptDecrypt(data.Role, Constants.EncryptKey);

            return result;
        }
    }
}
