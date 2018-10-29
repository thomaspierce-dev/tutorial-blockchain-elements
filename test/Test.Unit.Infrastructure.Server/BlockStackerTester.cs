namespace Test.Unit.Infrastructure.Server
{
    using System;
    using AutoMapper;
    using BlockBoys.Tutorial.Blockchain.Core.Application.Services;
    using BlockBoys.Tutorial.Blockchain.Core.Domain.Factories;
    using BlockBoys.Tutorial.Blockchain.Core.Domain.Services;
    using BlockBoys.Tutorial.Blockchain.Infrastructure.Server;
    using CompanyName.Notebook.NoteTaking.Core.Application.Services;
    using CompanyName.Notebook.NoteTaking.Core.Domain.Factories;
    using CompanyName.Notebook.NoteTaking.Core.Domain.Services;
    using CompanyName.Notebook.NoteTaking.Infrastructure.Server;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class BlockStackerTester
    {
        private ICryptoService _cryptoService;
        private IBlockSimpleFactory _blockSimpleFactory;
        private IMapper _mapper;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            // ARRANGE
            _cryptoService = Substitute.For<ICryptoService>();
            _blockSimpleFactory = Substitute.For<IBlockSimpleFactory>();
            _mapper = Substitute.For<IMapper>();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _cryptoService = null;
            _blockSimpleFactory = null;
            _mapper = null;
        }

        [SetUp]
        public void SetUp()
        {
            // ARRANGE
            _cryptoService.ClearReceivedCalls();
            _blockSimpleFactory.ClearReceivedCalls();
            _mapper.ClearReceivedCalls();
        }

        [Test]
        public void CanConstructBlockStacker()
        {
            // ARRANGE

            // ACT
            var subjectUnderTest = new BlockStacker(
                _cryptoService,
                _blockSimpleFactory,
                _mapper
            );

            // ASSERT
            Assert.That(subjectUnderTest, Is.Not.Null);
            Assert.That(subjectUnderTest, Is.InstanceOf(typeof(IBlockStacker)));
        }
    }
}