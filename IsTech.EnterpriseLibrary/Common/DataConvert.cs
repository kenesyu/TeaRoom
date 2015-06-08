using System;
using System.Collections.Generic;
using System.Text;

namespace IsTech.EnterpriseLibrary.Common
{
    public static class DataConvert
    {
        public static int ConvertToInt(object o)
        {
            if (o == null || o == DBNull.Value || o.ToString() == string.Empty)
            {
                return 0;
            }
            else
            {
                return int.Parse(o.ToString());
            }
        }

        public static double ConvertToDouble(object o)
        {
            if (o == null || o == DBNull.Value || o.ToString() == string.Empty)
            {
                return 0;
            }
            else
            {
                return double.Parse(o.ToString());
            }
        }

        public static decimal ConvertToDecimal(object o)
        {
            if (o == null || o == DBNull.Value || o.ToString() == string.Empty)
            {
                return 0;
            }
            else
            {
                return decimal.Parse(o.ToString());
            }
        }

        public static bool ConvertToBoolean(object o)
        {
            return Convert.ToBoolean(DataConvert.ConvertToInt(o));
        }

        public static string ConvertToTrimString(object o)
        {
            if (o == null || o == DBNull.Value)
            {
                return string.Empty;
            }
            else
            {
                return o.ToString();
            }
        }

        public static DateTime ConvertToDateTime(object o)
        {
            if (o == null || o == DBNull.Value || o.ToString() == string.Empty)
            {
                return DateTime.MinValue;
            }
            else
            {
                return Convert.ToDateTime(o.ToString());
            }
        }
        public static string ConvertToDateTimeString(object o,string formatStr)
        {
            if (o == null || o == DBNull.Value || o.ToString() == string.Empty)
            {
                return string.Empty;
            }
            else
            {
                return Convert.ToDateTime(o).ToString(formatStr);
            }
        }
        public static string ConvertSpecialChar(string text)
        {
            return text.Replace("<", "&lt;").Replace(">", "&gt;").Replace("\n", "<br />");
        }
    }
}
