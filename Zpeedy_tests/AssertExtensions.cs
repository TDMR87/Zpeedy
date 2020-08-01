using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Zpeedy_tests
{
    public static class AssertExtensions
    {
        public static void IsPositiveDouble(this Assert assert, double value)
        {
            if (value <= 0) throw new AssertFailedException();
        }

        public static void IsNegativeDouble(this Assert assert, double value)
        {
            if (value >= 0) throw new AssertFailedException();
        }
    }
}
