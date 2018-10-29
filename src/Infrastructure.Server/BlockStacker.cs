namespace BlockBoys.Tutorial.Blockchain.Infrastructure.Server
{
    using System;
    using BlockBoys.Tutorial.Blockchain.Core.Application.Messages;
    using BlockBoys.Tutorial.Blockchain.Core.Application.Services;
    using BlockBoys.Tutorial.Blockchain.Core.Domain.Factories;
    using BlockBoys.Tutorial.Blockchain.Core.Domain.Models;
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

            var blockSimple = GetBlockSimpleFromRequest(blockSimpleRequest);
            blockSimple.Mine();
            return GetResponseFromBlockSimple(blockSimple);
        }

        public BlockSimpleResponse CreateSimpleBlock(BlockSimpleRequest blockSimpleRequest)
        {
            if (blockSimpleRequest == null)
            {
                throw new ArgumentNullException(nameof(blockSimpleRequest));
            }

            var blockSimple = GetBlockSimpleFromRequest(blockSimpleRequest);
            return GetResponseFromBlockSimple(blockSimple);
        }

        private IBlockSimple GetBlockSimpleFromRequest(BlockSimpleRequest request)
        {
            return _blockSimpleFactory.Create(
                _cryptoService,
                request.BlockNumber,
                request.BlockData,
                request.Nonce
            );
        }

        private BlockSimpleResponse GetResponseFromBlockSimple(IBlockSimple blockSimple)
        {
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