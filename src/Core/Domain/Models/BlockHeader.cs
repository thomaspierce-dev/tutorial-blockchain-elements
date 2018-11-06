namespace BlockBoys.Tutorial.Blockchain.Core.Domain.Models
{
    using System;
    public class BlockHeader
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string Version { get; set; }
        public string PreviousHash { get; set; }
        public string TransactionHash { get; set; } // Merkle Root
        public string Target { get; set; }  // level of difficulty
    }
}