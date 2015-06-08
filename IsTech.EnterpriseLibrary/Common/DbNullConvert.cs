using System;

namespace IsTech.EnterpriseLibrary.Common
{
    public class DbNullConvert
    {
        public static object ConvertToInt(object o)
        {
            if (o == null || o == DBNull.Value || o.ToString() == string.Empty)
            {
                return DBNull.Value;
            }
            else
            {
                return int.Parse(o.ToString());
            }
        }

        public static object ConvertToDecimal(object o)
        {
            if (o == null || o == DBNull.Value || o.ToString() == string.Empty)
            {
                return DBNull.Value;
            }
            else
            {
                return decimal.Parse(o.ToString());
            }
        }

        public static object ConvertToDateTime(object o)
        {
            if (o == null || o == DBNull.Value || o.ToString() == string.Empty)
            {
                return DBNull.Value;
            }
            else
            {
                return Convert.ToDateTime(o.ToString());
            }
        }

        public static object ConvertToString(object o)
        {
            if (o == null || o == DBNull.Value || o.ToString() == string.Empty)
            {
                return DBNull.Value;
            }
            else
            {
                return o.ToString();
            }
        }

        public static object ConvertToDouble(object o)
        {
            if (o == null || o == DBNull.Value || o.ToString() == string.Empty)
            {
                return DBNull.Value;
            }
            else
            {
                return double.Parse(o.ToString());
            }
        }

        public static object ConvertToBoolean(object o)
        {
            if (o == null || o == DBNull.Value || o.ToString() == string.Empty)
            {
                return DBNull.Value;
            }
            else
            {
                return bool.Parse(o.ToString());
            }
        }
    }
}
