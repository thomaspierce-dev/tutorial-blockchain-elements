namespace BlockBoys.Tutorial.Blockchain.Infrastructure.Server
{
    using System;
    using System.Security.Cryptography;
    using System.Text;
    using BlockBoys.Tutorial.Blockchain.Core.Application.Messages;
    using BlockBoys.Tutorial.Blockchain.Core.Application.Services;
    using Microsoft.AspNetCore.Cryptography.KeyDerivation;

    public class Cryptographer : ICryptographer
    {
        const string zeroHash = "0000000000000000000000000000000000000000000000000000000000000000";

        public HashResponse GenerateHash(HashRequest hashRequest)
        {
            var hashedMessage = GetSha256Hash(hashRequest.Message);
            return new HashResponse{ Digest = hashedMessage };
        }

        private string GetSha256Hash(string input) {
            using( SHA256 sha256Hash = SHA256.Create())
            {
                byte[] data = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                var stringBuilder = new StringBuilder();
                for (int i=0; i< data.Length; i++)
                {
                    stringBuilder.Append(data[i].ToString("x2"));
                }

                return stringBuilder.ToString();
            }
        }

        private string GetPbkdf2Hash(string input)
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            var constantSaltString = "this is my rifle, this is my gun. this is for fighting, this is for fun.";
            salt = Encoding.ASCII.GetBytes(constantSaltString.ToCharArray(), 0, 16);

            string digest = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: input,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8
            ));

            return digest;
        }
    }
}