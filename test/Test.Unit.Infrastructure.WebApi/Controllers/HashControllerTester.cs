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
    public class HashControllerTester : ControllerTesterTemplate<HashController>
    {
        ICryptographer _cryptographer;
        ILogger<HashController> _logger;

        protected override HashController EstablishContext()
        {
            _cryptographer = Substitute.For<ICryptographer>();
            _logger = Substitute.For<ILogger<HashController>>();
            return new HashController(_cryptographer, _logger);
        }

        protected override void TestCleanup()
        {
            _cryptographer.ClearReceivedCalls();
            _logger.ClearReceivedCalls();
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
        }

       [Test]
        public void CanConstructHashController()
        {
            // ARRANGE
            var cryptographer = Substitute.For<ICryptographer>();
            var logger = Substitute.For<ILogger<HashController>>();

            // ACT
            var subjectUnderTest = new HashController(_cryptographer, logger);

            // ASSERT
            Assert.That(subjectUnderTest, Is.Not.Null);
            Assert.That(subjectUnderTest, Is.TypeOf(typeof(HashController)));
        }

        [Test]
        public void CanGenerateHashForMessage()
        {
            // ARRANGE
            var hashRequest = Substitute.For<HashRequest>();
            var expectedHashRespone = Substitute.For<HashResponse>();

            _cryptographer.GenerateHash(hashRequest).Returns(expectedHashRespone);

            // ACT
            var result = _subjectUnderTest.Post(hashRequest);

            // ASSERT
            Assert.That(result, Is.Not.Null);
            _cryptographer.Received(1).GenerateHash(hashRequest);
        }
    }
}
