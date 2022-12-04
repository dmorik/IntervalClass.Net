using NUnit.Framework;

namespace IntervalClass.Testing.Create
{
    [TestFixture]
    internal sealed class FromEmpty : TestBase
    {
        [Test]
        public void Empty_Success()
        {
            var createdInterval = new Interval();

            Assert.IsTrue(createdInterval == Interval.Empty);
        }
    }
}