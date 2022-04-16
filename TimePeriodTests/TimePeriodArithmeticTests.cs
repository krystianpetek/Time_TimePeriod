using Microsoft.VisualStudio.TestTools.UnitTesting;
using Time_TimePeriod;

namespace TimeTests.TimePeriodTests
{
    [TestClass]
    public class TimePeriodArithmeticTests
    {
        [DataTestMethod, TestCategory("Arithmetic")]
        [DataRow(3600, 3600, 7200)]
        [DataRow(5600, 9000, 14600)]
        [DataRow(86400, 86400, 172800)]
        [DataRow(0, 0, 0)]
        [DataRow(1, 2, 3)]
        public void PlusTimePeriod_WhenAddedCorrectTimePeriods_ShouldReturnTrue(
            long tp1NumOfSeconds, long tp2NumOfSeconds, long sumOfAddedTimePeriods)
        {
            TimePeriod tp1 = new TimePeriod(tp1NumOfSeconds);
            TimePeriod tp2 = new TimePeriod(tp2NumOfSeconds);
            Assert.IsTrue((tp1.Plus(tp2)).NumberOfSeconds == sumOfAddedTimePeriods);
        }

        [DataTestMethod, TestCategory("Arithmetic")]
        [DataRow(3600, 3600, 7200)]
        [DataRow(5600, 9000, 14600)]
        [DataRow(86400, 86400, 172800)]
        [DataRow(0, 0, 0)]
        [DataRow(1, 2, 3)]
        public void PlusTimePeriodStatic_WhenAddedCorrectTimePeriods_ShouldReturnTrue(
            long tp1NumOfSeconds, long tp2NumOfSeconds, long sumOfAddedTimePeriods)
        {
            TimePeriod tp1 = new TimePeriod(tp1NumOfSeconds);
            TimePeriod tp2 = new TimePeriod(tp2NumOfSeconds);
            Assert.IsTrue((TimePeriod.Plus(tp1, tp2)).NumberOfSeconds == sumOfAddedTimePeriods);
        }

        [DataTestMethod, TestCategory("Operators")]
        [DataRow(7200, 3600, 3600)]
        [DataRow(14600, 9000, 5600)]
        [DataRow(172800, 86400, 86400)]
        [DataRow(0, 0, 0)]
        [DataRow(3600, 3600, 0)]
        [DataRow(0, 200, 200)]
        public void MinusTime_WhenSubtractedCorrectTimePeriods_ShouldReturnTrue(
            long tp1NumOfSeconds, long tp2NumOfSeconds, long sumOfAddedTimePeriods)
        {
            TimePeriod tp1 = new TimePeriod(tp1NumOfSeconds);
            TimePeriod tp2 = new TimePeriod(tp2NumOfSeconds);
            Assert.IsTrue((tp1.Minus(tp2)).NumberOfSeconds == sumOfAddedTimePeriods);
        }

        [DataTestMethod, TestCategory("Operators")]
        [DataRow(7200, 3600, 3600)]
        [DataRow(14600, 9000, 5600)]
        [DataRow(172800, 86400, 86400)]
        [DataRow(0, 0, 0)]
        [DataRow(3600, 3600, 0)]
        [DataRow(0, 200, 200)]
        public void MinusTimeStatic_WhenSubtractedCorrectTimePeriodToTime_ShouldReturnTrue(
            long tp1NumOfSeconds, long tp2NumOfSeconds, long sumOfAddedTimePeriods)
        {
            TimePeriod tp1 = new TimePeriod(tp1NumOfSeconds);
            TimePeriod tp2 = new TimePeriod(tp2NumOfSeconds);
            Assert.IsTrue((TimePeriod.Minus(tp1, tp2)).NumberOfSeconds == sumOfAddedTimePeriods);
        }
    }
}