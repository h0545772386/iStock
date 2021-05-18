using System;
using System.Linq;

namespace iStock
{
    public static class UTILS
    {
        // כדי להקיש רק מספרים שלמים 
        public static void Integer_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (e.Text.Any(c => !char.IsDigit(c)))
            {
                e.Handled = true;
            }
        }

        // כדי להקיש מספרים עם נקודה עשרונית 
        public static void Decimal_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (e.Text.Any(c => !char.IsDigit(c) && c != '.'))
            {
                e.Handled = true;
            }
        }
                
        public static string DateToString_YYYYMMDD(this DateTime d)
        {
            int Year = d.Year;
            int Month = d.Month;
            int Day = d.Day;

            return Year.ToString() +
                   (Month < 10 ? "0" + Month.ToString() : Month.ToString()) +
                   (Day < 10 ? "0" + Day.ToString() : Day.ToString());
        }

        public static string DateToString_YYYYMMDDHHMMSS(this DateTime d)
        {
            int Year = d.Year;
            int Month = d.Month;
            int Day = d.Day;
            int HH = d.Day;   // hour
            int MM = d.Day;   // miutes
            int SS = d.Day;   // seconds

            return Year.ToString() +
                   (Month < 10 ? "0" + Month.ToString() : Month.ToString()) +
                   (Day < 10 ? "0" + Day.ToString() : Day.ToString()) +
                   (HH < 10 ? "0" + HH.ToString() : HH.ToString()) +
                   (MM < 10 ? "0" + MM.ToString() : MM.ToString()) +
                   (SS < 10 ? "0" + SS.ToString() : SS.ToString());
        }

        public static int DateToINT_YYYYMMDD(this DateTime d)
        {
            int i = 0;
            int.TryParse(DateToString_YYYYMMDD(d), out i);
            return i;
        }

        public static long DateToLONG_YYYYMMDDHHMMSS(this DateTime d)
        {
            long l = 0;
            long.TryParse(DateToString_YYYYMMDDHHMMSS(d), out l);
            return l;
        }

        public static DateTime INT2Date(this int YYYYMMDD)
        {
            int Year = YYYYMMDD / 10000;
            int Month = (YYYYMMDD / 100) % 100;
            int Day = YYYYMMDD % 100;
            return new DateTime(Year, Month, Day);
        }

        public static int GetMonthFromYYYYMMDD(this int YYYYMMDD)
        {
            int Month = (YYYYMMDD / 100) % 100;
            return Month;
        }

        public static string GetBatch1(this DateTime d)
        {
            int Year = d.Year;
            int Month = d.Month;
            int Day = d.Day;
            int HH = d.Day;   // hour
            int MM = d.Day;   // miutes

            return Year.ToString() +
                   (Month < 10 ? "0" + Month.ToString() : Month.ToString()) +
                   (Day < 10 ? "0" + Day.ToString() : Day.ToString()) +
                   (HH < 10 ? "0" + HH.ToString() : HH.ToString()) +
                   (MM < 10 ? "0" + MM.ToString() : MM.ToString());
        }
    }
}
