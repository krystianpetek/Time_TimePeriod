using Microsoft.VisualStudio.TestTools.UnitTesting;
using Time_TimePeriod;

namespace TimeTests.TimePeriodTests
{
    [TestClass]
    public class TimePeriodCompareTests
    {
        [DataTestMethod, TestCategory("Compare")]
        [DataRow(0, 0, 1, 0, 0, 0)]
        [DataRow(0, 1, 1, 0, 1, 0)]
        [DataRow(0, 1, 1, 0, 0, 1)]
        [DataRow(1, 1, 1, 1, 1, 0)]
        [DataRow(1, 0, 0, 0, 59, 59)]
        [DataRow(10, 0, 0, 9, 59, 59)]
        public void CompareTimePeriods_WhenLeftTimePeriodItsGreaterThanRight_ShouldReturnTrue(
            int t1Hours, int t1Minutes, int t1Seconds,
            int t2Hours, int t2Minutes, int t2Seconds)
        {
            TimePeriod t1 = new TimePeriod(t1Hours, t1Minutes, t1Seconds);
            TimePeriod t2 = new TimePeriod(t2Hours, t2Minutes, t2Seconds);

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
        public void CompareTimePeriods_WhenLeftTimePeriodItsEqualToRight_ShouldReturnTrue(
            int t1Hours, int t1Minutes, int t1Seconds,
            int t2Hours, int t2Minutes, int t2Seconds)
        {
            TimePeriod t1 = new TimePeriod(t1Hours, t1Minutes, t1Seconds);
            TimePeriod t2 = new TimePeriod(t2Hours, t2Minutes, t2Seconds);

            Assert.IsTrue(t1.CompareTo(t2) == 0);
        }

        [DataTestMethod, TestCategory("Compare")]
        [DataRow(0, 0, 0, 0, 0, 1)]
        [DataRow(0, 1, 0, 0, 1, 1)]
        [DataRow(0, 0, 1, 0, 1, 1)]
        [DataRow(1, 1, 0, 1, 1, 1)]
        [DataRow(0, 59, 59, 1, 0, 0)]
        [DataRow(9, 59, 59, 10, 0, 0)]
        public void CompareTimePeriods_WhenLeftTimePeriodItsLowerThanRight_ShouldReturnTrue(
            int t1Hours, int t1Minutes, int t1Seconds,
            int t2Hours, int t2Minutes, int t2Seconds)
        {
            TimePeriod t1 = new TimePeriod(t1Hours, t1Minutes, t1Seconds);
            TimePeriod t2 = new TimePeriod(t2Hours, t2Minutes, t2Seconds);

            Assert.IsTrue(t1.CompareTo(t2) < 0);
        }
    }
}