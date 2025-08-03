using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CleaningServiceAPI.Common
{
    public static class RandomNumber
    {
        /// <summary>
        /// Node.js: crypto.createHash('sha256').update(input).digest('hex')
        /// </summary>
        public static string ComputeSha256Hash(string input)
        {
            using var sha256 = SHA256.Create();
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = sha256.ComputeHash(inputBytes);
            return Convert.ToHexString(hashBytes);
        }

        /// <summary>
        /// Node.js: crypto.randomBytes(length)
        /// </summary>
        public static byte[] GenerateRandomBytes(int length=10)
        {
            byte[] randomBytes = new byte[length];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomBytes);
            return randomBytes;
        }

        /// <summary>
        /// Node.js: crypto.randomBytes(size)
        /// (Alternate name, same as above)
        /// </summary>
        public static byte[] GenerateSecureRandomBytes(int size=16)
        {
            return GenerateRandomBytes(size);
        }

        /// <summary>
        /// Node.js: crypto.randomInt(min, max)
        /// </summary>
        public static int GetRandomInt(int min, int max)
        {
            
            return RandomNumberGenerator.GetInt32(min, max);
        }

        /// <summary>
        /// Node.js: crypto.createHash('sha256').update(input).digest('hex')
        /// (Alias of ComputeSha256Hash)
        /// </summary>
        public static string ComputeSha256(string input)
        {
            return ComputeSha256Hash(input);
        }

        /// <summary>
        /// Node.js: crypto.createHmac('sha256', key).update(message).digest('hex')
        /// </summary>
        public static string ComputeHmacSha256(string key, string message)
        {
            var keyBytes = Encoding.UTF8.GetBytes(key);
            var messageBytes = Encoding.UTF8.GetBytes(message);

            using var hmac = new HMACSHA256(keyBytes);
            var hash = hmac.ComputeHash(messageBytes);
            return Convert.ToHexString(hash);
        }

        /// <summary>
        /// Node.js: Buffer.from("hello").toString("base64")
        /// </summary>
        public static string ToBase64(string input)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(input));
        }

        /// <summary>
        /// Node.js: Buffer.from(base64, "base64").toString("utf8")
        /// </summary>
        public static string FromBase64(string base64)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(base64));
        }

        /// <summary>
        /// Node.js: buffer.toString('hex')
        /// </summary>
        public static string ToHex(byte[] bytes)
        {
            return Convert.ToHexString(bytes);
        }

        /// <summary>
        /// Node.js: Buffer.from(hex, 'hex')
        /// </summary>
        public static byte[] HexToBytes(string hex)
        {
            return Enumerable.Range(0, hex.Length / 2)
                             .Select(i => Convert.ToByte(hex.Substring(i * 2, 2), 16))
                             .ToArray();
        }

        /// <summary>
        /// Async version of ComputeSha256
        /// </summary>
        public static async Task<string> ComputeSha256Async(string input)
        {
            return await Task.Run(() => ComputeSha256(input));
        }

        /// <summary>
        /// Compute SHA256 hash of a file
        /// </summary>
        public static string ComputeFileSha256(string filePath)
        {
            using var sha256 = SHA256.Create();
            using var stream = File.OpenRead(filePath);
            var hash = sha256.ComputeHash(stream);
            return Convert.ToHexString(hash);
        }
    }
}