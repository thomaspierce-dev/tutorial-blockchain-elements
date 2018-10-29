namespace Test.Unit.Infrastructure.Server
{
    using AutoMapper;
    using BlockBoys.Tutorial.Blockchain.Core.Application.Services;
    using BlockBoys.Tutorial.Blockchain.Core.Domain.Factories;
    using BlockBoys.Tutorial.Blockchain.Core.Domain.Services;
    using BlockBoys.Tutorial.Blockchain.Infrastructure.Server;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class CryptographerTester
    {
        [Test]
        public void CanConstructCryptographer()
        {
            // ARRANGE

            // ACT
            var subjectUnderTest = new Cryptographer();

            // ASSERT
            Assert.That(subjectUnderTest, Is.Not.Null);
            Assert.That(subjectUnderTest, Is.InstanceOf(typeof(ICryptographer)));
        }
    }
}