namespace Test.Unit.Infrastructure.WebApi.Controllers
{
    using BlockBoys.Tutorial.Blockchain.Core.Application.Messages;
    using BlockBoys.Tutorial.Blockchain.Core.Application.Services;
    using BlockBoys.Tutorial.Blockchain.Infrastructure.WebApi.Controllers.v1;
    using Microsoft.Extensions.Logging;
    using NSubstitute;
    using NUnit.Framework;
    using Test.Unit.Infrastructure.WebApi.Controllers.Bases;

    [TestFixture]
    public class BlockSimpleControllerTester : ControllerTesterTemplate<BlockSimpleController>
    {
        IBlockStacker _blockStacker;
        ILogger<BlockSimpleController> _logger;

        protected override BlockSimpleController EstablishContext()
        {
            _blockStacker = Substitute.For<IBlockStacker>();
            _logger = Substitute.For<ILogger<BlockSimpleController>>();
            return new BlockSimpleController(_blockStacker, _logger);
        }

        protected override void TestCleanup()
        {
            _blockStacker.ClearReceivedCalls();
            _logger.ClearReceivedCalls();
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
        }

       [Test]
        public void CanConstructBlockSimpleController()
        {
            // ARRANGE
            var cryptographer = Substitute.For<IBlockStacker>();
            var logger = Substitute.For<ILogger<BlockSimpleController>>();

            // ACT
            var subjectUnderTest = new BlockSimpleController(_blockStacker, logger);

            // ASSERT
            Assert.That(subjectUnderTest, Is.Not.Null);
            Assert.That(subjectUnderTest, Is.TypeOf(typeof(BlockSimpleController)));
        }

        [Test]
        public void CanCreateSimpleBlock()
        {
            // ARRANGE
            var blockSimpleRequest = Substitute.For<BlockSimpleRequest>();
            var expectedBlockSimpleRespone = Substitute.For<BlockSimpleResponse>();

            _blockStacker.CreateSimpleBlock(blockSimpleRequest).Returns(expectedBlockSimpleRespone);

            // ACT
            var result = _subjectUnderTest.Post(blockSimpleRequest);

            // ASSERT
            Assert.That(result, Is.Not.Null);
            _blockStacker.Received(1).CreateSimpleBlock(blockSimpleRequest);
        }

        [Test]
        public void CanMineSimpleBlock()
        {
            // ARRANGE
            var blockSimpleRequest = Substitute.For<BlockSimpleRequest>();
            var expectedBlockSimpleRespone = Substitute.For<BlockSimpleResponse>();

            _blockStacker.MineSimpleBlock(blockSimpleRequest).Returns(expectedBlockSimpleRespone);

            // ACT
            var result = _subjectUnderTest.MineBlockSimple(blockSimpleRequest);

            // ASSERT
            Assert.That(result, Is.Not.Null);
            _blockStacker.Received(1).MineSimpleBlock(blockSimpleRequest);
        }
    }
}
