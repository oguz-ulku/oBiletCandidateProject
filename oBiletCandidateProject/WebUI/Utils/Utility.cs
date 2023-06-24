using Microsoft.AspNetCore.Components.Forms;
using System.Globalization;
using System.Text;

namespace WebUI.Utils
{
    public static class Utility
    {

        public static string GetFormattedDate(string inputDate)
        {

            if (string.IsNullOrWhiteSpace(inputDate))
                throw new ArgumentException("Input date cannot be null or empty.");

            DateTime parsedDate;
            if (!DateTime.TryParseExact(inputDate, "dd MMMM yyyy dddd", CultureInfo.CurrentCulture, DateTimeStyles.None, out parsedDate))
                throw new ArgumentException("Invalid input date format.");

            return parsedDate.ToString("yyyy-MM-dd");
    


        }
    }
}
