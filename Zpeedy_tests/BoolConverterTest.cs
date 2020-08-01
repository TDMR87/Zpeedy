using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Zpeedy_core_3.Helpers;

namespace Zpeedy_tests
{
    [TestClass]
    public class BoolConverterTest
    {
        private bool trueValue = true;

        [TestMethod]
        public void ConvertBoolean()
        {
            BoolConverter e = new BoolConverter();

            // COnvert the boolean
            bool convertedBool = (bool)e.Convert(trueValue, typeof(bool?), null, CultureInfo.InvariantCulture);

            // Assert type
            Assert.IsInstanceOfType(convertedBool, typeof(bool));

            // Assert value has been converted
            Assert.IsFalse(convertedBool);
        }
    }
}
