using Microsoft.VisualStudio.TestTools.UnitTesting;
using Time_TimePeriod;

namespace TimeTests.TimeTests
{
    [TestClass]
    public class TimeCompareTests
    {
        [DataTestMethod, TestCategory("Compare")]
        [DataRow(0, 0, 1, 0, 0, 0)]
        [DataRow(0, 1, 1, 0, 1, 0)]
        [DataRow(0, 1, 1, 0, 0, 1)]
        [DataRow(1, 1, 1, 1, 1, 0)]
        [DataRow(1, 0, 0, 0, 59, 59)]
        [DataRow(10, 0, 0, 9, 59, 59)]
        public void CompareTimes_WhenLeftTimeItsGreaterThanRightTime_ShouldReturnTrue(
            int t1Hours, int t1Minutes, int t1Seconds,
            int t2Hours, int t2Minutes, int t2Seconds)
        {
            Time t1 = new Time((byte)t1Hours, (byte)t1Minutes, (byte)t1Seconds);
            Time t2 = new Time((byte)t2Hours, (byte)t2Minutes, (byte)t2Seconds);

            Assert.IsTrue(t1.CompareTo(t2) > 0);
        }

        [DataTestMethod, TestCategory("Compare")]
        [DataRow(0, 0, 0, 0, 0, 0)]
        [DataRow(0, 1, 0, 0, 1, 0)]
        [DataRow(1, 0, 0, 1, 0, 0)]
        [DataRow(1, 1, 0, 1, 1, 0)]
        [DataRow(1, 1, 1, 1, 1, 1)]
        [DataRow(0, 0, 1, 0, 0, 1)]
        [DataRow(23, 0, 0, 23, 0, 0)]
        [DataRow(23, 59, 59, 23, 59, 59)]
        [DataRow(23, 2, 59, 23, 2, 59)]
        public void CompareTimes_WhenLeftTimeItsEqualToRightTime_ShouldReturnTrue(
            int t1Hours, int t1Minutes, int t1Seconds,
            int t2Hours, int t2Minutes, int t2Seconds)
        {
            Time t1 = new Time((byte)t1Hours, (byte)t1Minutes, (byte)t1Seconds);
            Time t2 = new Time((byte)t2Hours, (byte)t2Minutes, (byte)t2Seconds);

            Assert.IsTrue(t1.CompareTo(t2) == 0);
        }

        [DataTestMethod, TestCategory("Compare")]
        [DataRow(0, 0, 0, 0, 0, 1)]
        [DataRow(0, 1, 0, 0, 1, 1)]
        [DataRow(0, 0, 1, 0, 1, 1)]
        [DataRow(1, 1, 0, 1, 1, 1)]
        [DataRow(0, 59, 59, 1, 0, 0)]
        [DataRow(9, 59, 59, 10, 0, 0)]
        public void CompareTimes_WhenLeftTimeItsLowerThanRightTime_ShouldReturnTrue(
            int t1Hours, int t1Minutes, int t1Seconds,
            int t2Hours, int t2Minutes, int t2Seconds)
        {
            Time t1 = new Time((byte)t1Hours, (byte)t1Minutes, (byte)t1Seconds);
            Time t2 = new Time((byte)t2Hours, (byte)t2Minutes, (byte)t2Seconds);

            Assert.IsTrue(t1.CompareTo(t2) < 0);
        }
    }
}