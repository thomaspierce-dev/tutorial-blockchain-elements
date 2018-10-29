namespace Test.Unit.Core.Application.Messages
{
    using BlockBoys.Tutorial.Blockchain.Core.Application.Messages;
    using NUnit.Framework;

    [TestFixture]
    public class BlockSimpleRequestTester
    {
        [Test]
        public void CanCreateBlockSimpleRequest()
        {
            // ARRANGE

            // ACT
            var subjectUnderTest = new BlockSimpleRequest();

            // ASSERT
            Assert.That(subjectUnderTest, Is.TypeOf(typeof(BlockSimpleRequest)));
        }

        [Test]
        public void CanSetBlockData()
        {
            // ARRANGE
            var expectedBlockData = "Don't to forget to pick up bread from the grocery store.";
            var subjectUnderTest = new BlockSimpleRequest();

            // ACT
            subjectUnderTest.BlockData = expectedBlockData;

            // ASSERT
            Assert.That(subjectUnderTest.BlockData, Is.EqualTo(expectedBlockData));
        }
    }
}
