using Microsoft.VisualStudio.TestTools.UnitTesting;
using Time_TimePeriod;

namespace TimeTests.TimeTests
{
    [TestClass]
    public class TimeOperatorsTests
    {
        [DataTestMethod, TestCategory("Operators")]
        [DataRow(0, 0, 0, 0, 0, 0)]
        [DataRow(23, 59, 59, 23, 59, 59)]
        [DataRow(0, 59, 59, 0, 59, 59)]
        public void EqualsOperatorTime_WhenValuesItsCorrectThreeParameters_ShouldReturnTrue(
            int hours, int minutes, int seconds,
            int expectedHours, int expectedMinutes, int expectedSeconds)
        {
            Time t1 = new Time((byte)hours, (byte)minutes, (byte)seconds);
            Time t2 = new Time((byte)expectedHours, (byte)expectedMinutes, (byte)expectedSeconds);
            Assert.IsTrue(t1 == t2);
        }

        [DataTestMethod, TestCategory("Operators")]
        [DataRow(0, 0, 0, 23, 0, 0)]
        [DataRow(0, 0, 0, 23, 0, 40)]
        [DataRow(0, 0, 0, 23, 10, 40)]
        [DataRow(0, 20, 0, 23, 0, 0)]
        [DataRow(0, 0, 30, 23, 0, 0)]
        [DataRow(8, 0, 0, 23, 0, 0)]
        [DataRow(20, 50, 11, 23, 59, 59)]
        public void NotEqualsOperatorTime_WhenValuesItsIncorrect_ShouldReturnTrue(
            int hours, int minutes, int seconds,
            int expectedHours, int expectedMinutes, int expectedSeconds)
        {
            Time t1 = new Time((byte)hours, (byte)minutes, (byte)seconds);
            Time t2 = new Time((byte)expectedHours, (byte)expectedMinutes, (byte)expectedSeconds);
            Assert.IsTrue(t1 != t2);
        }

        [DataTestMethod, TestCategory("Operators")]
        [DataRow(0, 0, 1, 0, 0, 0)]
        [DataRow(0, 1, 1, 0, 1, 0)]
        [DataRow(0, 1, 1, 0, 0, 1)]
        [DataRow(1, 1, 1, 1, 1, 0)]
        [DataRow(1, 0, 0, 0, 59, 59)]
        [DataRow(10, 0, 0, 9, 59, 59)]
        public void CompareOperatorTimes_WhenLeftTimeItsGreaterThanRightTime_ShouldReturnTrue(
            int t1Hours, int t1Minutes, int t1Seconds,
            int t2Hours, int t2Minutes, int t2Seconds)
        {
            Time t1 = new Time((byte)t1Hours, (byte)t1Minutes, (byte)t1Seconds);
            Time t2 = new Time((byte)t2Hours, (byte)t2Minutes, (byte)t2Seconds);

            Assert.IsTrue(t1 > t2);
        }

        [DataTestMethod, TestCategory("Operators")]
        [DataRow(0, 0, 1, 0, 0, 0)]
        [DataRow(0, 1, 1, 0, 1, 0)]
        [DataRow(0, 1, 1, 0, 0, 1)]
        [DataRow(1, 1, 1, 1, 1, 0)]
        [DataRow(1, 0, 0, 0, 59, 59)]
        [DataRow(10, 0, 0, 9, 59, 59)]
        [DataRow(0, 0, 0, 0, 0, 0)]
        [DataRow(0, 1, 0, 0, 1, 0)]
        [DataRow(1, 0, 0, 1, 0, 0)]
        [DataRow(1, 1, 0, 1, 1, 0)]
        [DataRow(1, 1, 1, 1, 1, 1)]
        [DataRow(0, 0, 1, 0, 0, 1)]
        [DataRow(23, 0, 0, 23, 0, 0)]
        [DataRow(23, 59, 59, 23, 59, 59)]
        [DataRow(23, 2, 59, 23, 2, 59)]
        public void CompareOperatorTimes_WhenLeftTimeItsGreaterOrEqualsThanRightTime_ShouldReturnTrue(
            int t1Hours, int t1Minutes, int t1Seconds,
            int t2Hours, int t2Minutes, int t2Seconds)
        {
            Time t1 = new Time((byte)t1Hours, (byte)t1Minutes, (byte)t1Seconds);
            Time t2 = new Time((byte)t2Hours, (byte)t2Minutes, (byte)t2Seconds);

            Assert.IsTrue(t1 >= t2);
        }

        [DataTestMethod, TestCategory("Operators")]
        [DataRow(0, 0, 0, 0, 0, 1)]
        [DataRow(0, 1, 0, 0, 1, 1)]
        [DataRow(0, 0, 1, 0, 1, 1)]
        [DataRow(1, 1, 0, 1, 1, 1)]
        [DataRow(0, 59, 59, 1, 0, 0)]
        [DataRow(9, 59, 59, 10, 0, 0)]
        public void CompareOperatorTimes_WhenLeftTimeItsLowerThanRightTime_ShouldReturnTrue(
            int t1Hours, int t1Minutes, int t1Seconds,
            int t2Hours, int t2Minutes, int t2Seconds)
        {
            Time t1 = new Time((byte)t1Hours, (byte)t1Minutes, (byte)t1Seconds);
            Time t2 = new Time((byte)t2Hours, (byte)t2Minutes, (byte)t2Seconds);

            Assert.IsTrue(t1 < t2);
        }

        [DataTestMethod, TestCategory("Operators")]
        [DataRow(0, 0, 0, 0, 0, 1)]
        [DataRow(0, 1, 0, 0, 1, 1)]
        [DataRow(0, 0, 1, 0, 1, 1)]
        [DataRow(1, 1, 0, 1, 1, 1)]
        [DataRow(0, 59, 59, 1, 0, 0)]
        [DataRow(9, 59, 59, 10, 0, 0)]
        [DataRow(0, 0, 0, 0, 0, 0)]
        [DataRow(0, 1, 0, 0, 1, 0)]
        [DataRow(1, 0, 0, 1, 0, 0)]
        [DataRow(1, 1, 0, 1, 1, 0)]
        [DataRow(1, 1, 1, 1, 1, 1)]
        [DataRow(0, 0, 1, 0, 0, 1)]
        [DataRow(23, 0, 0, 23, 0, 0)]
        [DataRow(23, 59, 59, 23, 59, 59)]
        [DataRow(23, 2, 59, 23, 2, 59)]
        public void CompareOperatorTimes_WhenLeftTimeItsLowerOrEqualsThanRightTime_ShouldReturnTrue(
            int t1Hours, int t1Minutes, int t1Seconds,
            int t2Hours, int t2Minutes, int t2Seconds)
        {
            Time t1 = new Time((byte)t1Hours, (byte)t1Minutes, (byte)t1Seconds);
            Time t2 = new Time((byte)t2Hours, (byte)t2Minutes, (byte)t2Seconds);

            Assert.IsTrue(t1 <= t2);
        }

        [DataTestMethod, TestCategory("Operators")]
        [DataRow(20, 35, 00, 3600, 21, 35, 00)]
        [DataRow(20, 35, 00, 54302, 11, 40, 02)]
        [DataRow(23, 59, 59, 1, 00, 00, 00)]
        [DataRow(23, 59, 59, 86400, 23, 59, 59)]
        public void AdditionOperator_WhenAddedCorrectTimePeriodToTime_ShouldReturnTrue(
            int hours, int minutes, int seconds,
            long timePeriodInSeconds,
            int expectedHours, int expectedMinutes, int expectedSeconds)
        {
            Time time = new Time((byte)hours, (byte)minutes, (byte)seconds);
            TimePeriod period = new TimePeriod(timePeriodInSeconds);
            Assert.IsTrue(time + period == new Time((byte)expectedHours, (byte)expectedMinutes, (byte)expectedSeconds));
        }

        [DataTestMethod, TestCategory("Operators")]
        [DataRow(00, 00, 00, 1, 23, 59, 59)]
        [DataRow(21, 35, 00, 3601, 20, 34, 59)]
        [DataRow(21, 35, 00, 3600, 20, 35, 00)]
        [DataRow(11, 40, 02, 54302, 20, 35, 00)]
        [DataRow(23, 59, 59, 86400, 23, 59, 59)]
        [DataRow(23, 59, 59, 86400, 23, 59, 59)]
        [DataRow(12, 0, 0, 86399, 12, 0, 1)]
        public void SubtractionOperator_WhenSubtractedCorrectTimePeriodToTime_ShouldReturnTrue(
            int hours, int minutes, int seconds,
            long timePeriodInSeconds,
            int expectedHours, int expectedMinutes, int expectedSeconds)
        {
            Time time = new Time((byte)hours, (byte)minutes, (byte)seconds);
            TimePeriod period = new TimePeriod(timePeriodInSeconds);
            Assert.IsTrue(time - period == new Time((byte)expectedHours, (byte)expectedMinutes, (byte)expectedSeconds));
        }
    }
}