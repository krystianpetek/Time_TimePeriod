using Microsoft.VisualStudio.TestTools.UnitTesting;
using Time_TimePeriod;

namespace TimeTests.TimeTests
{
    [TestClass]
    public class TimeArithmeticTests
    {
        [DataTestMethod, TestCategory("Arithmetic")]
        [DataRow(20, 35, 00, 3600, 21, 35, 00)]
        [DataRow(20, 35, 00, 54302, 11, 40, 02)]
        [DataRow(23, 59, 59, 1, 00, 00, 00)]
        [DataRow(23, 59, 59, 86400, 23, 59, 59)]
        public void PlusTime_WhenAddedCorrectTimePeriodToTime_ShouldReturnTrue(
            int hours, int minutes, int seconds,
            long timePeriodInSeconds,
            int expectedHours, int expectedMinutes, int expectedSeconds)
        {
            Time time = new Time((byte)hours, (byte)minutes, (byte)seconds);
            TimePeriod period = new TimePeriod(timePeriodInSeconds);
            Assert.IsTrue(time.Plus(period) == new Time((byte)expectedHours, (byte)expectedMinutes, (byte)expectedSeconds));
        }

        [DataTestMethod, TestCategory("Arithmetic")]
        [DataRow(20, 35, 00, 3600, 21, 35, 00)]
        [DataRow(20, 35, 00, 54302, 11, 40, 02)]
        [DataRow(23, 59, 59, 1, 00, 00, 00)]
        [DataRow(23, 59, 59, 86400, 23, 59, 59)]
        public void PlusTimeStatic_WhenAddedCorrectTimePeriodToTime_ShouldReturnTrue(
            int hours, int minutes, int seconds,
            long timePeriodInSeconds,
            int expectedHours, int expectedMinutes, int expectedSeconds)
        {
            Time time = new Time((byte)hours, (byte)minutes, (byte)seconds);
            TimePeriod period = new TimePeriod(timePeriodInSeconds);
            Assert.IsTrue(Time.Plus(time, period) == new Time((byte)expectedHours, (byte)expectedMinutes, (byte)expectedSeconds));
        }

        [DataTestMethod, TestCategory("Operators")]
        [DataRow(00, 00, 00, 1, 23, 59, 59)]
        [DataRow(21, 35, 00, 3601, 20, 34, 59)]
        [DataRow(21, 35, 00, 3600, 20, 35, 00)]
        [DataRow(11, 40, 02, 54302, 20, 35, 00)]
        [DataRow(23, 59, 59, 86400, 23, 59, 59)]
        public void MinusTime_WhenSubtractedCorrectTimePeriodToTime_ShouldReturnTrue(
            int hours, int minutes, int seconds,
            long timePeriodInSeconds,
            int expectedHours, int expectedMinutes, int expectedSeconds)
        {
            Time time = new Time((byte)hours, (byte)minutes, (byte)seconds);
            TimePeriod period = new TimePeriod(timePeriodInSeconds);
            Assert.IsTrue(time.Minus(period) == new Time((byte)expectedHours, (byte)expectedMinutes, (byte)expectedSeconds));
        }

        [DataTestMethod, TestCategory("Operators")]
        [DataRow(00, 00, 00, 1, 23, 59, 59)]
        [DataRow(21, 35, 00, 3601, 20, 34, 59)]
        [DataRow(21, 35, 00, 3600, 20, 35, 00)]
        [DataRow(11, 40, 02, 54302, 20, 35, 00)]
        [DataRow(23, 59, 59, 86400, 23, 59, 59)]
        public void MinusTimeStatic_WhenSubtractedCorrectTimePeriodToTime_ShouldReturnTrue(
            int hours, int minutes, int seconds,
            long timePeriodInSeconds,
            int expectedHours, int expectedMinutes, int expectedSeconds)
        {
            Time time = new Time((byte)hours, (byte)minutes, (byte)seconds);
            TimePeriod period = new TimePeriod(timePeriodInSeconds);
            Assert.IsTrue(Time.Minus(time, period) == new Time((byte)expectedHours, (byte)expectedMinutes, (byte)expectedSeconds));
        }
    }
}