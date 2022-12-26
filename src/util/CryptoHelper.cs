using System;
using System.Security.Cryptography;
using System.Text;
using citronindo.cryptolib.bc.Crypto.Engines;
using citronindo.cryptolib.bc.Crypto.Modes;
using citronindo.cryptolib.bc.Crypto.Parameters;
using citronindo.cryptolib.signal.kdf;
using HKDF = citronindo.cryptolib.signal.kdf.HKDF;

namespace citronindo.cryptolib.util
{
    public static class CryptoHelper
    {
        // generate random iv
        public static byte[] GenerateIV()
        {
            // generate iv
            byte[] iv = new byte[12];
            Random rand = new();
            rand.NextBytes(iv);
            return iv;
        }

        /// <summary>
        /// TODO: dead code?
        /// </summary>
        public static void Shuffle<T>(this IList<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }

    /// <summary>
    /// Encryption helpers
    /// </summary>
    public class Encrypt
    {
        /// <summary>
        /// Computes PKCS5 for the message
        /// </summary>
        /// <param name="message">plaintext</param>
        /// <returns>PKCS5 of the message</returns>
        public static byte[] aesCbcPkcs7(byte[] message, byte[] key, byte[] iv)
        {
            using (var aes = Aes.Create())
            {
                aes.Padding = PaddingMode.PKCS7;
                aes.BlockSize = 128;
                aes.Key = key;
                aes.IV = iv;
                using (var encrypt = aes.CreateEncryptor())
                {
                    return encrypt.TransformFinalBlock(message, 0, message.Length);
                }
            }
        }

        /// <summary>
        /// Encrypt Aes GCM for the message
        /// </summary>
        /// <param name="message"></param>
        /// <param name="key"></param>
        /// <param name="associatedData"></param>
        /// <returns></returns>
        public static byte[] aesGcm(byte[] message, byte[] key, byte[] iv, byte[]? associatedData = null)
        {
            var cipher = new GcmBlockCipher(new AesEngine());
            if (associatedData != null)
                cipher.Init(true, new AeadParameters(new KeyParameter(key), 128, iv, associatedData));
            else
                cipher.Init(true, new AeadParameters(new KeyParameter(key), 128, iv));
            var cipherBytes = new byte[cipher.GetOutputSize(message.Length)];
            int len = cipher.ProcessBytes(message, 0, message.Length, cipherBytes, 0);
            cipher.DoFinal(cipherBytes, len);
            return iv.Concat(cipherBytes).ToArray();
        }

        // only for windows
        public static byte[] aesGcmWindowsOnly(byte[] message, byte[] key, byte[] nonce, byte[]? associatedData = null)
        {
            using var aes = new AesGcm(key);
            var tag = new byte[AesGcm.TagByteSizes.MaxSize];
            var cipherBytes = new byte[message.Length];
            if (associatedData != null)
                aes.Encrypt(nonce, message, cipherBytes, tag, associatedData);
            else
                aes.Encrypt(nonce, message, cipherBytes, tag);
            return nonce.Concat(cipherBytes).Concat(tag).ToArray();
        }

        public static byte[] AesGcmSecret(byte[] message, byte[] secret)
        {
            HKDF kdf = new HKDFv3();
            byte[] derive = kdf.deriveSecrets(secret, secret, 80);
            var iv = derive[^12..];
            return Encrypt.aesGcm(message, secret, iv); ;
        }
    }

    /// <summary>
    /// Decryption helpers
    /// </summary>
    public class Decrypt
    {
        public static byte[] aesCbcPkcs7(byte[] message, byte[] key, byte[] iv)
        {
            using (var aes = Aes.Create())
            {
                aes.Padding = PaddingMode.PKCS7;
                aes.BlockSize = 128;
                aes.Key = key;
                aes.IV = iv;
                if (message.Length % (aes.BlockSize / 8) != 0) throw new Exception("Invalid ciphertext length");
                using (var decrypt = aes.CreateDecryptor())
                {
                    return decrypt.TransformFinalBlock(message, 0, message.Length);
                }
            }
        }

        public static byte[] aesGcm(byte[] message, byte[] key, byte[]? associatedData)
        {
            var iv = message[0..12];
            var cipherBytes = message[12..];
            var cipher = new GcmBlockCipher(new AesEngine());
            if (associatedData != null)
                cipher.Init(false, new AeadParameters(new KeyParameter(key), 128, iv, associatedData));
            else
                cipher.Init(false, new AeadParameters(new KeyParameter(key), 128, iv));
            var plainBytes = new byte[cipher.GetOutputSize(cipherBytes.Length)];
            int len = cipher.ProcessBytes(cipherBytes, 0, cipherBytes.Length, plainBytes, 0);
            cipher.DoFinal(plainBytes, len);
            return plainBytes;
        }
    }
}

