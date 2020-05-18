using System;

namespace Supermarketmanagement.Core.Utilities
{
    public class IdUtilities
    {
        private static DateTime _startDateTime = new DateTime(2020,01,01);

        public static string GenerateByTimeSpan()
        {
            var endDateTime = DateTime.Now;
            TimeSpan difference = endDateTime - _startDateTime;
            string result = Math.Round(difference.TotalMilliseconds).ToString();
            return result;
        }
    }
}
