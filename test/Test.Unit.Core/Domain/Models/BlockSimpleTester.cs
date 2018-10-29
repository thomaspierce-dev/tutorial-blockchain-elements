namespace Test.Unit.Core.Domain.Models
{
    using System;
    using BlockBoys.Tutorial.Blockchain.Core.Domain.Models;
    using BlockBoys.Tutorial.Blockchain.Core.Domain.Services;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class BlockSimpleTester
    {
        [Test]
        public void CanCreateBlockSimple()
        {
            // ARRANGE
            var cryptoService = Substitute.For<ICryptoService>();
            var expectedNumber = 1;
            var expectedBlockData = "This is just a reminder to go to the store.";
            var expectedNonce = 1U;

            // ACT
            var subjectUnderTest = new BlockSimple(cryptoService, expectedNumber, expectedBlockData, expectedNonce);

            // ASSERT
            Assert.That(subjectUnderTest, Is.TypeOf(typeof(BlockSimple)));
            Assert.That(subjectUnderTest.Number, Is.EqualTo(expectedNumber));
            Assert.That(subjectUnderTest.Data, Is.EqualTo(expectedBlockData));
            Assert.That(subjectUnderTest.Nonce, Is.EqualTo(expectedNonce));
        }
    }
}
