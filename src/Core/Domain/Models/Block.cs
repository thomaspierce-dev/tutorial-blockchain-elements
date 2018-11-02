namespace BlockBoys.Tutorial.Blockchain.Core.Domain.Models
{
    using System.Collections.Generic;

    public class Block
    {
        public BlockHeader Header { get; set; }
        public ulong Nonce { get; set; }
        public IList<Transaction> Transactions { get; set; }
    }
}
