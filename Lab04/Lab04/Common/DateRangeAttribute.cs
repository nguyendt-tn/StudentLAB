using System;
using System.ComponentModel.DataAnnotations;

namespace DataAnnotationInMVC.Common
{
    public class DateRangeAttribute : RangeAttribute
    {
        public DateRangeAttribute(string minimumValue)
            : base(typeof(DateTime), minimumValue, DateTime.Today.ToString())
        {

        }
    }
}