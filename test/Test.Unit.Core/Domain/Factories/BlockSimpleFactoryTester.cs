namespace Test.Unit.Core.Domain.Factories
{
    using System;
    using BlockBoys.Tutorial.Blockchain.Core.Domain.Factories;
    using BlockBoys.Tutorial.Blockchain.Core.Domain.Models;
    using BlockBoys.Tutorial.Blockchain.Core.Domain.Services;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class BlockSimpleFactoryTester
    {
        [Test]
        public void CanConstructBlockSimpleFactory()
        {
            // ARRANGE

            // ACT
            var subjectUnderTest = new BlockSimpleFactory();

            // ASSERT
            Assert.That(subjectUnderTest, Is.TypeOf(typeof(BlockSimpleFactory)));
            Assert.That(subjectUnderTest, Is.InstanceOf(typeof(IBlockSimpleFactory)));
        }

        [Test]
        public void CanCreateBlockSimple()
        {
            // ARRANGE
            var cryptoService = Substitute.For<ICryptoService>();
            var expectedNumber = 1;
            var expectedBlockData = "This is just a reminder to go to the store.";
            var expectedNonce = 1U;
            var subjectUnderTest = new BlockSimpleFactory();

            // ACT
            var result = subjectUnderTest.Create(cryptoService, expectedNumber, expectedBlockData, expectedNonce);

            // ASSERT
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf(typeof(IBlockSimple)));
            Assert.That(result.Data, Is.EqualTo(expectedBlockData));
        }
    }
}
