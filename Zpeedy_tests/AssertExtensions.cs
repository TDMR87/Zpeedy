using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

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
