using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ACFIP.Data.Helpers
{
    public class AppUtils
    {
        // hash function, using SHA512
        public static string hashSHA512(string password, byte[] salt)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: 10,
                numBytesRequested: 512 / 8));
        }
        public static bool VerifyPassword(string userEnteredPassword, string dbPasswordHash, byte[] salt)
        {
            string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: userEnteredPassword,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: 10,
                numBytesRequested: 512 / 8));
            return dbPasswordHash == hashedPassword;
        }
        public static byte[] generateSalt()
        {
            byte[] salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }
    }
}
