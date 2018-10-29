namespace BlockBoys.Tutorial.Blockchain.Core.Application.Messages
{
    public class BlockSimpleRequest
    {
        public int BlockNumber { get; set; }
        public string BlockData { get; set; }
        public ulong Nonce { get; set; }
    }
}