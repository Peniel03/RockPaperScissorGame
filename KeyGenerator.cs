using System.Security.Cryptography;

namespace RockPaperScissorGame
{
    /// <summary>
    /// The key generator class
    /// </summary>
    public class KeyGenerator
    {
        /// <summary>
        /// Function to generate a key of max 256 bits ~ 32 bytes
        /// </summary>
        /// <returns></returns>
        public static byte[] GenerateKey()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] key = new byte[32]; 
                rng.GetBytes(key);
                return key;
            }
        }
    }
}
