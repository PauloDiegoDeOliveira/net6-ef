using DevLabs.Domain.Enums;
using System;

namespace DevLabs.Application.Utilities
{
    public class DateInformations
    {
        public string GetSplitData(Date date)
        {
            DateTime datevalue = DateTime.Now;

            switch (date)
            {
                case Date.Year:
                    return datevalue.Year.ToString();

                case Date.Month:
                    return datevalue.Month.ToString();

                case Date.Day:
                    return datevalue.Day.ToString();

                default:
                    return null;
            }
        }
    }
}