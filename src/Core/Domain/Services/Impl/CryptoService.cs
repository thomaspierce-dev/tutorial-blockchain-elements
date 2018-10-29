using System.Security.Cryptography;
using System.Text;

namespace BlockBoys.Tutorial.Blockchain.Core.Domain.Services
{
    public class CryptoService : ICryptoService
    {
        public string GenerateHash(string message)
        {
            using( SHA256 sha256Hash = SHA256.Create())
            {
                byte[] data = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(message));

                var stringBuilder = new StringBuilder();
                for (int i=0; i< data.Length; i++)
                {
                    stringBuilder.Append(data[i].ToString("x2"));
                }

                return stringBuilder.ToString();
            }
        }
    }
}