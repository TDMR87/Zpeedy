using Microsoft.VisualStudio.TestTools.UnitTesting;
using NuGet.Frameworks;
using System.Threading.Tasks;
using testSubject = Zpeedy_core_3;

namespace Zpeedy_tests
{
    [TestClass]
    public class CalculationTest
    {
        private const double _expectedResult = 0.0;

        [TestMethod]
        public async Task CalculateDownloadSpeed()
        {
            double testResult = await testSubject.Calculations.CalculateDownloadSpeed(10, 10_000);

            // Is not null
            Assert.IsNotNull(testResult);

            // Is type double
            Assert.IsInstanceOfType(testResult, _expectedResult.GetType());

            // Is positive value
            Assert.That.IsPositiveDouble(testResult);
        }
    }
}
