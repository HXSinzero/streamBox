using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR.WMApp
{
    public class ProjToolHelper
    {
        public static bool TryParseDatetimerange(string datetimerange, out DateTime dt1, out DateTime dt2)
        {
            string str1 = (string)null;
            string str2 = (string)null;
            if (!string.IsNullOrEmpty(datetimerange) && datetimerange.Length > 10)
            {
                string s1 = datetimerange.Substring(0, 19);
                string s2 = datetimerange.Substring(22, 19);
                DateTime.TryParse(s1, out dt1);
                DateTime.TryParse(s2, out dt2);
                str1 = dt1.ToString("yyyy-MM-dd HH:mm:ss");
                str2 = dt2.ToString("yyyy-MM-dd HH:mm:ss");
            }
            else
            {
                DateTime today = DateTime.Today;
                dt1 = today.AddDays(-7.0);
                today = DateTime.Today;
                dt2 = today.AddDays(1.0);
                str1 = dt1.ToString("yyyy-MM-dd HH:mm:ss");
                str2 = dt2.ToString("yyyy-MM-dd HH:mm:ss");
            }

            return true;
        }
    }
}
