using Microsoft.VisualStudio.TestTools.UnitTesting;
using Time_TimePeriod;

namespace TimeTests.TimePeriodTests
{
    [TestClass]
    public class TimePeriodOperatorsTests
    {
        [DataTestMethod, TestCategory("Operators")]
        [DataRow(0, 0, 0, 0, 0, 0)]
        [DataRow(23, 59, 59, 23, 59, 59)]
        [DataRow(0, 59, 59, 0, 59, 59)]
        public void EqualsOperatorTimePeriod_WhenValuesItsCorrectThreeParameters_ShouldReturnTrue(
            int t1Hours, int t1Minutes, int t1Seconds,
            int t2Hours, int t2Minutes, int t2Seconds)
        {
            TimePeriod t1 = new TimePeriod(t1Hours, t1Minutes, t1Seconds);
            TimePeriod t2 = new TimePeriod(t2Hours, t2Minutes, t2Seconds);
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
        public void NotEqualsOperatorTimePeriod_WhenValuesItsIncorrect_ShouldReturnTrue(
            int t1Hours, int t1Minutes, int t1Seconds,
            int t2Hours, int t2Minutes, int t2Seconds)
        {
            TimePeriod t1 = new TimePeriod(t1Hours, t1Minutes, t1Seconds);
            TimePeriod t2 = new TimePeriod(t2Hours, t2Minutes, t2Seconds);
            Assert.IsTrue(t1 != t2);
        }

        [DataTestMethod, TestCategory("Operators")]
        [DataRow(0, 0, 1, 0, 0, 0)]
        [DataRow(0, 1, 1, 0, 1, 0)]
        [DataRow(0, 1, 1, 0, 0, 1)]
        [DataRow(1, 1, 1, 1, 1, 0)]
        [DataRow(1, 0, 0, 0, 59, 59)]
        [DataRow(10, 0, 0, 9, 59, 59)]
        public void CompareOperatorTimes_WhenLeftTimePeriodItsGreaterThanRight_ShouldReturnTrue(
            int t1Hours, int t1Minutes, int t1Seconds,
            int t2Hours, int t2Minutes, int t2Seconds)
        {
            TimePeriod t1 = new TimePeriod(t1Hours, t1Minutes, t1Seconds);
            TimePeriod t2 = new TimePeriod(t2Hours, t2Minutes, t2Seconds);

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
        public void CompareOperatorTimes_WhenLeftTimePeriodItsGreaterOrEqualsThanRight_ShouldReturnTrue(
            int t1Hours, int t1Minutes, int t1Seconds,
            int t2Hours, int t2Minutes, int t2Seconds)
        {
            TimePeriod t1 = new TimePeriod(t1Hours, t1Minutes, t1Seconds);
            TimePeriod t2 = new TimePeriod(t2Hours, t2Minutes, t2Seconds);

            Assert.IsTrue(t1 >= t2);
        }

        [DataTestMethod, TestCategory("Operators")]
        [DataRow(0, 0, 0, 0, 0, 1)]
        [DataRow(0, 1, 0, 0, 1, 1)]
        [DataRow(0, 0, 1, 0, 1, 1)]
        [DataRow(1, 1, 0, 1, 1, 1)]
        [DataRow(0, 59, 59, 1, 0, 0)]
        [DataRow(9, 59, 59, 10, 0, 0)]
        public void CompareOperatorTimes_WhenLeftTimePeriodItsLowerThanRight_ShouldReturnTrue(
            int t1Hours, int t1Minutes, int t1Seconds,
            int t2Hours, int t2Minutes, int t2Seconds)
        {
            TimePeriod t1 = new TimePeriod(t1Hours, t1Minutes, t1Seconds);
            TimePeriod t2 = new TimePeriod(t2Hours, t2Minutes, t2Seconds);

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
        public void CompareOperatorTimes_WhenLeftTimePeriodItsLowerOrEqualsThanRight_ShouldReturnTrue(
            int t1Hours, int t1Minutes, int t1Seconds,
            int t2Hours, int t2Minutes, int t2Seconds)
        {
            TimePeriod t1 = new TimePeriod(t1Hours, t1Minutes, t1Seconds);
            TimePeriod t2 = new TimePeriod(t2Hours, t2Minutes, t2Seconds);

            Assert.IsTrue(t1 <= t2);
        }

        [DataTestMethod, TestCategory("Operators")]
        [DataRow(20, 35, 00, 3600, 21, 35, 00)]
        [DataRow(20, 35, 00, 54302, 35, 40, 02)]
        [DataRow(23, 59, 59, 1, 24, 00, 00)]
        [DataRow(23, 59, 59, 86400, 47, 59, 59)]
        public void AdditionOperator_WhenAddedCorrectTimePeriodToTime_ShouldReturnTrue(
            int t1Hours, int t1Minutes, int t1Seconds,
            int timePeriodInSeconds,
            int t2Hours, int t2Minutes, int t2Seconds)
        {
            TimePeriod t1 = new TimePeriod(t1Hours, t1Minutes, t1Seconds);
            TimePeriod t2 = new TimePeriod(t2Hours, t2Minutes, t2Seconds);
            Assert.IsTrue((t1 + new TimePeriod(timePeriodInSeconds)) == t2);
        }

        [DataTestMethod, TestCategory("Operators")]
        [DataRow(7200, 3600, 3600)]
        [DataRow(14600, 9000, 5600)]
        [DataRow(172800, 86400, 86400)]
        [DataRow(0, 0, 0)]
        [DataRow(3600, 3600, 0)]
        [DataRow(0, 200, 200)]
        public void SubtractionOperator_WhenSubtractedCorrectTimePeriodToTime_ShouldReturnTrue(
            long tp1NumOfSeconds, long tp2NumOfSeconds, long sumOfAddedTimePeriods)
        {
            TimePeriod tp1 = new TimePeriod(tp1NumOfSeconds);
            TimePeriod tp2 = new TimePeriod(tp2NumOfSeconds);
            Assert.IsTrue((tp1 - tp2).NumberOfSeconds == sumOfAddedTimePeriods);
        }
    }
}