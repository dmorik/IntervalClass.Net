// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace IntervalClass.Net.Testing.Create
{
    [TestFixture]
    internal sealed class Default : TestBase
    {
        [Test]
        public void Default_Success()
        {
            var createdInterval = new Interval();

            Assert.Multiple(() =>
            {
                Assert.That(createdInterval, Is.EqualTo(Interval.Empty));
                Assert.That(double.IsNaN(createdInterval.LowerBound), Is.True);
                Assert.That(double.IsNaN(createdInterval.UpperBound), Is.True);
            });
        }
    }
}