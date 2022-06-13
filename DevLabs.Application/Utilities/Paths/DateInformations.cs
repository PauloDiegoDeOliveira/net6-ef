using DevLabs.Domain.Enums;
using System;

namespace DevLabs.Application.Utilities.Paths
{
    public static class DateInformations
    {
        public static string GetSplitData(Date date)
        {
            DateTime datevalue = DateTime.Now;

            return date switch
            {
                Date.Year => datevalue.Year.ToString(),
                Date.Month => datevalue.Month.ToString(),
                Date.Day => datevalue.Day.ToString(),
                _ => null,
            };
        }
    }
}