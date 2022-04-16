using Microsoft.VisualStudio.TestTools.UnitTesting;
using Time_TimePeriod;

namespace TimeTests.TimePeriodTests
{
    [TestClass]
    public class TimePeriodToStringTests
    {
        [DataTestMethod, TestCategory("ToString")]
        [DataRow(0, 0, 0, "00:00:00")]
        [DataRow(0, 00, 0, "00:00:00")]
        [DataRow(00, 00, 00, "00:00:00")]
        [DataRow(7, 50, 0, "07:50:00")]
        [DataRow(23, 59, 59, "23:59:59")]
        [DataRow(23, 0, 0, "23:00:00")]
        public void ToString_WhenCalled_ShouldReturnCorrectStringRepresentation(int hours, int minutes, int seconds, string expectedStringRepresentation)
        {
            TimePeriod time = new TimePeriod(hours, minutes, seconds);
            Assert.AreEqual(expectedStringRepresentation, time.ToString());
        }
    }
}