namespace BlockBoys.Tutorial.Blockchain.Infrastructure.Server
{
    using System;
    using BlockBoys.Tutorial.Blockchain.Core.Application.Messages;
    using BlockBoys.Tutorial.Blockchain.Core.Application.Services;
    using BlockBoys.Tutorial.Blockchain.Core.Domain.Factories;
    using BlockBoys.Tutorial.Blockchain.Core.Domain.Services;

    public class BlockStacker : IBlockStacker
    {
        private readonly ICryptoService _cryptoService;
        private readonly IBlockSimpleFactory _blockSimpleFactory;

        public BlockStacker(ICryptoService cryptoService, IBlockSimpleFactory blockSimpleFactory)
        {
            _cryptoService = cryptoService ?? throw new ArgumentNullException(nameof(cryptoService));
            _blockSimpleFactory = blockSimpleFactory ?? throw new ArgumentNullException(nameof(blockSimpleFactory));
        }

        public BlockSimpleResponse MineSimpleBlock(BlockSimpleRequest blockSimpleRequest)
        {
            if (blockSimpleRequest == null)
            {
                throw new ArgumentNullException(nameof(blockSimpleRequest));
            }

            throw new NotImplementedException();
        }

        public BlockSimpleResponse CreateSimpleBlock(BlockSimpleRequest blockSimpleRequest)
        {
            if (blockSimpleRequest == null)
            {
                throw new ArgumentNullException(nameof(blockSimpleRequest));
            }

            var blockSimple = _blockSimpleFactory.Create(
                _cryptoService,
                blockSimpleRequest.BlockNumber,
                blockSimpleRequest.BlockData,
                blockSimpleRequest.Nonce
            );

            return new BlockSimpleResponse
            {
                BlockNumber = blockSimple.Number,
                BlockData = blockSimple.Data,
                Nonce = blockSimple.Nonce,
                Hash = blockSimple.Hash
            };
        }
    }
}