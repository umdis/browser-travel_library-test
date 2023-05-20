using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace BrowserTravel.Library.Common.Cryptography
{
    /// <summary>
    /// This class contain common methods  used in the API
    /// </summary>
    public static class HiddenSecret
    {
        /// <summary>
        /// Returns or sets the user's encrypted password
        /// </summary>
        /// <param name="password">User password</param>
        /// <param name="salt">Array of byte to cypher password</param>
        /// <returns>String encrypted password</returns>
        public static string Hash(string password, byte[] salt) {

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            return Convert.ToBase64String(hashBytes);
        }

        /// <summary>
        /// Returns or sets the byte array to encrypt the password.
        /// </summary>
        /// <returns>Byte array</returns>
        public static byte[] GenerateSalt()
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            return salt;
        }
    }
}