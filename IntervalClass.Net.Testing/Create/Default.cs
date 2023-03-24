// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using NUnit.Framework;

namespace IntervalClass.Net.Testing.Create
{
    [TestFixture]
    internal sealed class Default : TestBase
    {
        [Test]
        public void Default_Success()
        {
            var createdInterval = new Interval();

            Assert.IsTrue(createdInterval == Interval.Empty);
            Assert.IsTrue(double.IsNaN(createdInterval.LowerBound));
            Assert.IsTrue(double.IsNaN(createdInterval.UpperBound));
        }
    }
}