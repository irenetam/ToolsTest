using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject_EFMS.Commons
{
    public static class CommonMethods
    {
        public static string GenerateRandomString()
        {
            return DateTime.Now.ToString("MMMddyyHHmmss");
        }
        public static string GenerateRandomEmail(string domain = "logigear.com")
        {
            return GenerateRandomString() + "@" +domain;
        }
        public static string GetDepartDate(int days)
        {
            DateTime dt = DateTime.Now.AddDays(days);

            return dt.ToString("M / d / yyyy");

        }
    }
}
