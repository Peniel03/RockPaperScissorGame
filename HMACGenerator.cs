using System.Security.Cryptography;
using System.Text;

namespace RockPaperScissorGame
{
    /// <summary>
    /// The HMAC generator class
    /// </summary>
    public class HMACGenerator
    {
        /// <summary>
        /// This method generate the string HMAC of a given message and key
        /// </summary>
        /// <param name="message">the message</param>
        /// <param name="key">the key</param>
        /// <returns></returns>
        public static string GenerateHMAC(string message, byte[] key)
        {
            using (var hmac = new HMACSHA256(key))
            {
                byte[] hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(message));
                return BitConverter.ToString(hashBytes).Replace("-", "");
            }
        }
    }
}
