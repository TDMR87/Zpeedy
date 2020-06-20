using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Zpeedy_core_3
{
    public partial class Calculations
    {
        /// <summary>
        /// Calculates the average download speed.
        /// </summary>
        /// <param name="downloadTimeInSeconds"></param>
        /// <param name="bytesAmount"></param>
        /// <returns></returns>
        public static async Task<double> CalculateDownloadSpeed(double downloadTimeInSeconds, int bytesAmount)
        {
            double result = 0;

            // Count the amount of megabytes downloaded per second
            await Task.Run(() =>
            {
                double megaBytesPerSecond = (bytesAmount / downloadTimeInSeconds) / 1000000; // divided by bytes in a MB (1000 000)
                result = megaBytesPerSecond;
            });

            return result;
        }
    }
}
