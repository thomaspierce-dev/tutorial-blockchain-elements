namespace BlockBoys.Tutorial.Blockchain.Infrastructure.Server
{
    using System;
    using AutoMapper;
    using BlockBoys.Tutorial.Blockchain.Core.Application.Messages;
    using BlockBoys.Tutorial.Blockchain.Core.Application.Services;
    using BlockBoys.Tutorial.Blockchain.Core.Domain.Factories;
    using BlockBoys.Tutorial.Blockchain.Core.Domain.Models;
    using BlockBoys.Tutorial.Blockchain.Core.Domain.Services;

    public class BlockStacker : IBlockStacker
    {
        private readonly ICryptoService _cryptoService;
        private readonly IBlockSimpleFactory _blockSimpleFactory;
        private readonly IMapper _mapper;

        public BlockStacker(ICryptoService cryptoService, IBlockSimpleFactory blockSimpleFactory, IMapper mapper)
        {
            _cryptoService = cryptoService ?? throw new ArgumentNullException(nameof(cryptoService));
            _blockSimpleFactory = blockSimpleFactory ?? throw new ArgumentNullException(nameof(blockSimpleFactory));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public BlockSimpleResponse MineSimpleBlock(BlockSimpleRequest blockSimpleRequest)
        {
            if (blockSimpleRequest == null)
            {
                throw new ArgumentNullException(nameof(blockSimpleRequest));
            }

            var blockSimple = GetBlockSimpleFromRequest(blockSimpleRequest);
            blockSimple.Mine();
            return _mapper.Map<BlockSimpleResponse>(blockSimple);
        }

        public BlockSimpleResponse CreateSimpleBlock(BlockSimpleRequest blockSimpleRequest)
        {
            if (blockSimpleRequest == null)
            {
                throw new ArgumentNullException(nameof(blockSimpleRequest));
            }

            var blockSimple = GetBlockSimpleFromRequest(blockSimpleRequest);
            return _mapper.Map<BlockSimpleResponse>(blockSimple);
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
    }
}