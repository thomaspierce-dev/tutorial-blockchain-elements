namespace BlockBoys.Tutorial.Blockchain.Core.Domain.Services
{
    public interface ICryptoService
    {
        string GenerateHash(string message);
    }
}