using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Bazaar.Core
{
    public class Utility
    {
        public static string GD2JD(DateTime Gregorian)
        {
            PersianCalendar pc = new PersianCalendar();
            int y, m, d;
            y = pc.GetYear(Gregorian);
            m = pc.GetMonth(Gregorian);
            d = pc.GetDayOfMonth(Gregorian);
            string ans = string.Format("{0}/{1:d2}/{2:d2}", y, m, d);
            return ans;
        }

        public static string GD2JD(DateTime Gregorian, bool H)
        {
            PersianCalendar pc = new PersianCalendar();
            int y, m, d, h, M;
            y = pc.GetYear(Gregorian);
            m = pc.GetMonth(Gregorian);
            d = pc.GetDayOfMonth(Gregorian);
            h = pc.GetHour(Gregorian);

            M = pc.GetMinute(Gregorian);

            string ans = string.Format("{0}/{1:d2}/{2:d2} {3:d2}:{4:d2}", y, m, d, h, M);
            return ans;
        }

        public static DateTime JD2GD(string Jalali)
        {
            try
            {
                int y, m, d;
                y = int.Parse(Jalali.Substring(0, 4));
                m = int.Parse(Jalali.Substring(5, 2));
                d = int.Parse(Jalali.Substring(8, 2));
                PersianCalendar pc = new PersianCalendar();
                DateTime ans = new DateTime(y, m, d, pc);
                return ans;
            }
            catch
            {
                return DateTime.Now.AddYears(-100);
            }

        }
        public static string ClearTitle(string Title)
        {
            Title = Title.Replace("?", "");
            Title = Title.Replace("؟", "");
            Title = Title.Replace("+", "");
            Title = Title.Replace("/", "");
            Title = Title.Replace("\\", "");
            Title = Title.Replace("*", "");
            Title = Title.Replace(" ", "-");
            Title = Title.Replace(".", "-");
            Title = Title.Replace("\"", "");
            Title = Title.Replace(":", "");

            return Title;
        }

        public static string ToTimeString(DateTime InPutDate)
        {
            return InPutDate.Hour.ToString("00") + ":" + InPutDate.Minute.ToString("00");
        }
        public static string ToTimeString(DateTime? InPutDate)
        {
            return InPutDate.Value.Hour.ToString("00") + ":" + InPutDate.Value.Minute.ToString("00");
        }


        public static string GD2StringDateTime(DateTime InDate)
        {
            string ReturnDate;

            switch (InDate.DayOfWeek)
            {
                case DayOfWeek.Friday:
                    ReturnDate = "جمعه";
                    break;
                case DayOfWeek.Monday:
                    ReturnDate = "دوشنبه";
                    break;
                case DayOfWeek.Saturday:
                    ReturnDate = "شنبه";
                    break;
                case DayOfWeek.Sunday:
                    ReturnDate = "یکشنبه";
                    break;
                case DayOfWeek.Thursday:
                    ReturnDate = "پنجشنبه";
                    break;
                case DayOfWeek.Tuesday:
                    ReturnDate = "سه شنبه";
                    break;
                case DayOfWeek.Wednesday:
                    ReturnDate = "چهارشنبه";
                    break;
                default:
                    ReturnDate = "----";
                    break;

            }

            string[] Dd = GD2JD(InDate).Split('/');

            string MonthTitle = "";
            switch (Dd[1])
            {
                case "01":
                    MonthTitle = "فروردین";
                    break;

                case "02":
                    MonthTitle = "اردیبهشت";
                    break;

                case "03":
                    MonthTitle = "خرداد";
                    break;

                case "04":
                    MonthTitle = "تیر";
                    break;

                case "05":
                    MonthTitle = "مرداد";
                    break;

                case "06":
                    MonthTitle = "شهریور";
                    break;

                case "07":
                    MonthTitle = "مهر";
                    break;

                case "08":
                    MonthTitle = "آبان";
                    break;

                case "09":
                    MonthTitle = "آذر";
                    break;

                case "10":
                    MonthTitle = "دی";
                    break;

                case "11":
                    MonthTitle = "بهمن";
                    break;

                case "12":
                    MonthTitle = "اسفند";
                    break;
                default:
                    break;
            }

            ReturnDate += " " + Dd[2] + " " + MonthTitle + " " + Dd[0] + " " + string.Format("{0:00}", InDate.Hour) + ":" + string.Format("{0:00}", InDate.Minute);

            return ReturnDate;
        }

        public static string GD2StringDate(DateTime InDate)
        {
            string ReturnDate;

            switch (InDate.DayOfWeek)
            {
                case DayOfWeek.Friday:
                    ReturnDate = "جمعه";
                    break;
                case DayOfWeek.Monday:
                    ReturnDate = "دوشنبه";
                    break;
                case DayOfWeek.Saturday:
                    ReturnDate = "شنبه";
                    break;
                case DayOfWeek.Sunday:
                    ReturnDate = "یکشنبه";
                    break;
                case DayOfWeek.Thursday:
                    ReturnDate = "پنجشنبه";
                    break;
                case DayOfWeek.Tuesday:
                    ReturnDate = "سه شنبه";
                    break;
                case DayOfWeek.Wednesday:
                    ReturnDate = "چهارشنبه";
                    break;
                default:
                    ReturnDate = "----";
                    break;

            }

            string[] Dd = GD2JD(InDate).Split('/');

            string MonthTitle = "";
            switch (Dd[1])
            {
                case "01":
                    MonthTitle = "فروردین";
                    break;

                case "02":
                    MonthTitle = "اردیبهشت";
                    break;

                case "03":
                    MonthTitle = "خرداد";
                    break;

                case "04":
                    MonthTitle = "تیر";
                    break;

                case "05":
                    MonthTitle = "مرداد";
                    break;

                case "06":
                    MonthTitle = "شهریور";
                    break;

                case "07":
                    MonthTitle = "مهر";
                    break;

                case "08":
                    MonthTitle = "آبان";
                    break;

                case "09":
                    MonthTitle = "آذر";
                    break;

                case "10":
                    MonthTitle = "دی";
                    break;

                case "11":
                    MonthTitle = "بهمن";
                    break;

                case "12":
                    MonthTitle = "اسفند";
                    break;
                default:
                    break;
            }

            ReturnDate += " " + Dd[2] + " " + MonthTitle + " " + Dd[0];

            return ReturnDate;
        }

        public static string GD2NameofDay(DateTime InDate)
        {
            string ReturnDate;

            switch (InDate.DayOfWeek)
            {
                case DayOfWeek.Friday:
                    ReturnDate = "جمعه";
                    break;
                case DayOfWeek.Monday:
                    ReturnDate = "دوشنبه";
                    break;
                case DayOfWeek.Saturday:
                    ReturnDate = "شنبه";
                    break;
                case DayOfWeek.Sunday:
                    ReturnDate = "یکشنبه";
                    break;
                case DayOfWeek.Thursday:
                    ReturnDate = "پنجشنبه";
                    break;
                case DayOfWeek.Tuesday:
                    ReturnDate = "سه شنبه";
                    break;
                case DayOfWeek.Wednesday:
                    ReturnDate = "چهارشنبه";
                    break;
                default:
                    ReturnDate = "----";
                    break;

            }
            return ReturnDate;
        }

        public static string GD2NameofMonth(DateTime InDate)
        {
            string ReturnDate = "";
            string[] Dd = GD2JD(InDate).Split('/');

            switch (Dd[1])
            {
                case "01":
                    ReturnDate = "فروردین";
                    break;

                case "02":
                    ReturnDate = "اردیبهشت";
                    break;

                case "03":
                    ReturnDate = "خرداد";
                    break;

                case "04":
                    ReturnDate = "تیر";
                    break;

                case "05":
                    ReturnDate = "مرداد";
                    break;

                case "06":
                    ReturnDate = "شهریور";
                    break;

                case "07":
                    ReturnDate = "مهر";
                    break;

                case "08":
                    ReturnDate = "آبان";
                    break;

                case "09":
                    ReturnDate = "آذر";
                    break;

                case "10":
                    ReturnDate = "دی";
                    break;

                case "11":
                    ReturnDate = "بهمن";
                    break;

                case "12":
                    ReturnDate = "اسفند";
                    break;
                default:
                    break;
            }

            return ReturnDate;
        }

    }
}