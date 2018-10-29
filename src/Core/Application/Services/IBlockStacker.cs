namespace BlockBoys.Tutorial.Blockchain.Core.Application.Services
{
    using BlockBoys.Tutorial.Blockchain.Core.Application.Messages;

    public interface IBlockStacker
    {
        BlockSimpleResponse CreateSimpleBlock(BlockSimpleRequest blockSimpleRequest);
        BlockSimpleResponse MineSimpleBlock(BlockSimpleRequest blockSimpleRequest);
    }
}