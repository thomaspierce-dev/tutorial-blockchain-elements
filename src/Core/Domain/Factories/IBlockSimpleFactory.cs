namespace BlockBoys.Tutorial.Blockchain.Core.Domain.Factories
{
    using System;
    using BlockBoys.Tutorial.Blockchain.Core.Domain.Models;
    using BlockBoys.Tutorial.Blockchain.Core.Domain.Services;

    public interface IBlockSimpleFactory
    {
        IBlockSimple Create(
            ICryptoService cryptoService,
            int number,
            string data,
            ulong nonce
        );
    }
}