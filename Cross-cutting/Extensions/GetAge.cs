using System;
using System.Collections.Generic;
using System.Text;

namespace Cross_cutting.Extensions
{
    public static class DateGetAgeExtension
    {
        public static int GetAge(this DateTime dateTime)
        {
            DateTime today = DateTime.Now;
            int age = today.Year - dateTime.Year;
            if (dateTime > today.AddYears(-age)) age--;
            return age;
        }
    }
}
