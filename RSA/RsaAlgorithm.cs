using System.Numerics;
using System.Text;

namespace RSA
{
    // RSA key (public and private)
    public class RsaKey
    {
        public BigInteger Modulus { get; set; }
        public BigInteger Exponent { get; set; } // public (e) or private (d)

        // export key to custom Base64 format
        public string ExportToBase64()
        {
            string keyString = $"{Modulus}|{Exponent}";
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(keyString));
        }

        // import key from custom Base64 format
        public static RsaKey ImportFromBase64(string base64String)
        {
            string[] parts = Encoding.UTF8.GetString(Convert.FromBase64String(base64String)).Split('|');
            if (parts.Length != 2) 
                throw new ArgumentException("Invalid key format");

            return new RsaKey {
                Modulus = BigInteger.Parse(parts[0]),
                Exponent = BigInteger.Parse(parts[1])
            };
        }
    }

    // implementation of RSA algorithm using BigInteger
    public class RsaAlgorithm
    {
        private static readonly Random random = new();

        public RsaKey? PublicKey { get; private set; }
        public RsaKey? PrivateKey { get; private set; }

        // generate new pair of RSA keys
        public void GenerateKeys(int keySizeBits = 1024)
        {
            int primeSize = keySizeBits / 2;

            BigInteger p = GenerateLargePrime(primeSize);
            BigInteger q = GenerateLargePrime(primeSize);

            BigInteger n = p * q;
            BigInteger phi = (p - 1) * (q - 1);

            // 65537 is standard public exponent
            BigInteger e = 65537;
            BigInteger d = ModInverse(e, phi);

            PublicKey = new RsaKey { Modulus = n, Exponent = e };
            PrivateKey = new RsaKey { Modulus = n, Exponent = d };
        }

        public void ImportPublicKey(string base64Key) => PublicKey = RsaKey.ImportFromBase64(base64Key);
        public void ImportPrivateKey(string base64Key) => PrivateKey = RsaKey.ImportFromBase64(base64Key);

        // encrypts plaintext string using currently loaded public key
        public string Encrypt(string plainText)
        {
            if (PublicKey == null) 
                throw new InvalidOperationException("Public key is not set");

            byte[] textBytes = Encoding.UTF8.GetBytes(plainText);

            // append 0x00 byte to ensure BigInteger is positive
            byte[] positiveBytes = new byte[textBytes.Length + 1];
            Array.Copy(textBytes, positiveBytes, textBytes.Length);

            BigInteger m = new(positiveBytes);

            // C = M^e mod n
            BigInteger c = BigInteger.ModPow(m, PublicKey.Exponent, PublicKey.Modulus);

            return Convert.ToBase64String(c.ToByteArray());
        }

        // decrypt Base64 encrypted string using currently loaded private key
        public string Decrypt(string encryptedBase64)
        {
            if (PrivateKey == null) throw new InvalidOperationException("Private key is not set");

            byte[] encryptedBytes = Convert.FromBase64String(encryptedBase64);
            BigInteger c = new(encryptedBytes);

            // M = C^d mod n
            BigInteger m = BigInteger.ModPow(c, PrivateKey.Exponent, PrivateKey.Modulus);

            byte[] decryptedBytes = m.ToByteArray();

            // strip appended 0x00 byte if it exists
            if (decryptedBytes.Length > 0 && decryptedBytes[decryptedBytes.Length - 1] == 0)
                Array.Resize(ref decryptedBytes, decryptedBytes.Length - 1);

            return Encoding.UTF8.GetString(decryptedBytes);
        }

        // math helper methods

        private BigInteger GenerateLargePrime(int bits)
        {
            while (true) {
                byte[] bytes = new byte[bits / 8];
                random.NextBytes(bytes);

                bytes[^1] &= 0x7F; // force positive
                bytes[^1] |= 0x40; // ensure large magnitude
                bytes[0] |= 1; // force odd

                BigInteger candidate = new(bytes);

                if (MillerRabinTest(candidate, 10))
                    return candidate;
            }
        }

        private bool MillerRabinTest(BigInteger n, int k)
        {
            if (n < 2) 
                return false;
            if (n == 2 || n == 3) 
                return true;
            if (n % 2 == 0) 
                return false;

            BigInteger d = n - 1;
            int s = 0;

            while (d % 2 == 0) {
                d /= 2;
                s++;
            }

            for (int i = 0; i < k; i++) {
                BigInteger a = RandomBigIntegerBetween(2, n - 2);
                BigInteger x = BigInteger.ModPow(a, d, n);

                if (x == 1 || x == n - 1) 
                    continue;

                bool composite = true;
                for (int r = 1; r < s; r++) {
                    x = BigInteger.ModPow(x, 2, n);
                    if (x == n - 1) {
                        composite = false;
                        break;
                    }
                }

                if (composite) 
                    return false;
            }

            return true;
        }

        private static BigInteger RandomBigIntegerBetween(BigInteger min, BigInteger max)
        {
            BigInteger range = max - min;
            byte[] bytes = range.ToByteArray();
            random.NextBytes(bytes);
            bytes[^1] &= 0x7F;

            BigInteger result = new(bytes);
            return (result % range) + min;
        }

        private static BigInteger ModInverse(BigInteger a, BigInteger m)
        {
            BigInteger m0 = m;
            BigInteger y = 0, x = 1;

            if (m == 1) 
                return 0;

            while (a > 1) {
                BigInteger q = a / m;
                BigInteger t = m;

                m = a % m;
                a = t;
                t = y;

                y = x - q * y;
                x = t;
            }

            if (x < 0) 
                x += m0;

            return x;
        }
    }
}
