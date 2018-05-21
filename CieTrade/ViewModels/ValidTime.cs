using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace CieTrade.ViewModels
{
    public class ValidTime : System.ComponentModel.DataAnnotations.ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime;
            var isValid = DateTime.TryParseExact(Convert.ToString(value),
                  "HH:mm",
                  CultureInfo.CurrentCulture, DateTimeStyles.None,
                  out dateTime);
            return (isValid );

        }
    }
}