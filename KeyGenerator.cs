using System.Security.Cryptography;

namespace RockPaperScissorGame
{
    public class KeyGenerator
    {
        public static byte[] GenerateKey()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] key = new byte[32]; // 256 bits
                rng.GetBytes(key);
                return key;
            }
        }
    }
}
