namespace BlockBoys.Tutorial.Blockchain.Core.Domain.Models
{
    using System;
    public class Transaction
    {
        public string Sender { get; set; }
        public string Recipient { get; set; }
        public int Amount { get; set; }
        public DateTime Timestamp { get; set; }
    }
}