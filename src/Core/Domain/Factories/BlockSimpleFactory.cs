namespace BlockBoys.Tutorial.Blockchain.Core.Domain.Factories
{
    using System;
    using BlockBoys.Tutorial.Blockchain.Core.Domain.Models;
    using BlockBoys.Tutorial.Blockchain.Core.Domain.Services;

    public class BlockSimpleFactory : IBlockSimpleFactory
    {
        public IBlockSimple Create(
            ICryptoService cryptoService,
            int number,
            string data,
            ulong nonce
        )
        {
            return new BlockSimple(
                cryptoService,
                number,
                data,
                nonce
            );
        }
    }
}