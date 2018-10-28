namespace BlockBoys.Tutorial.Blockchain.Core.Application.Services
{
    using BlockBoys.Tutorial.Blockchain.Core.Application.Messages;

    public interface ICryptographer
    {
        HashResponse GenerateHash(HashRequest hashRequest);
    }
}