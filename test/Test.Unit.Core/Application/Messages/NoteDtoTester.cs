namespace Test.Unit.Core.Application.Messages
{
    using System;
    using BlockBoys.Tutorial.Blockchain.Core.Application.Messages;
    using NUnit.Framework;

    [TestFixture]
    public class BlockSimpleResponseTester
    {
        [Test]
        public void CanCreateBlockSimpleResponse()
        {
            // ARRANGE

            // ACT
            var subjectUnderTest = new BlockSimpleResponse();

            // ASSERT
            Assert.That(subjectUnderTest, Is.TypeOf(typeof(BlockSimpleResponse)));
        }

        [Test]
        public void CanSetBlockData()
        {
            // ARRANGE
            var expectedBlockData = "Don't to forget to pick up bread from the grocery store.";
            var subjectUnderTest = new BlockSimpleResponse();

            // ACT
            subjectUnderTest.BlockData = expectedBlockData;

            // ASSERT
            Assert.That(subjectUnderTest.BlockData, Is.EqualTo(expectedBlockData));
        }
    }
}
