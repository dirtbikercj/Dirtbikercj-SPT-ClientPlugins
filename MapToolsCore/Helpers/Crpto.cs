using System.Security.Cryptography;
using System.Web;

namespace MapTools.Helpers
{
    public static class Encryption
    {
        public static string Hash(string id)
        {
            string EncryptedHash;
            return EncryptedHash = SHA256.Create(id).ToString();
        }
    }
}
