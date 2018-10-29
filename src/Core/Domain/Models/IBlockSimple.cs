namespace BlockBoys.Tutorial.Blockchain.Core.Domain.Models
{
    using BlockBoys.Tutorial.Blockchain.Core.Domain.Services;

    public interface IBlockSimple
    {
        int Number { get; set; }
        string Data { get; set; }
        ulong Nonce { get; set; }
        string Hash { get; }


        bool IsSolved();
        void Mine();
    }
}