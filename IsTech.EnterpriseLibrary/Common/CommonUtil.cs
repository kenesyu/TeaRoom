using System.Data;
using System.Text;
namespace IsTech.EnterpriseLibrary.Common
{
    public class CommonUtil
    {
        public static string SqlEncode(string strValue, bool isLikeStatement)
        {
            string rtStr = strValue;
            if (isLikeStatement)
            {
                rtStr = strValue.Replace("[", "[[]");
                rtStr = rtStr.Replace("_", "[_]");
                rtStr = rtStr.Replace("%", "[%]");
                rtStr = rtStr.Replace(@"\", "\\\\");
            }
            rtStr = rtStr.Replace("'", "''");
            return rtStr;
        }

        public static string MySqlEncode(string str)
        {
            if (str != null)
            {
                return str.Trim().Replace("\\", "\\\\")
                                .Replace("'", "\\'")
                                .Replace("\"", "\\\"")
                                .Replace("%", "\\%")
                                .Replace("_", "\\_")
                                .Replace("\n", "\\\n")
                                .Replace("\r", "\\\r")
                                .Replace("\b", "\\\b")
                                .Replace("\t", "\\\t");
            }
            return string.Empty;

        }
        public static string DataTable2Json(DataTable dt, bool withTableName)
        {
            if (dt.Rows.Count == 0)
            {
                return string.Empty;
            }
            StringBuilder jsonBuilder = new StringBuilder();
            if (withTableName)
            {
                jsonBuilder.Append("{\"");
                jsonBuilder.Append(dt.TableName);
                jsonBuilder.Append("\":");
            }
            jsonBuilder.Append("[");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                jsonBuilder.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    jsonBuilder.Append("\"");
                    jsonBuilder.Append(dt.Columns[j].ColumnName);
                    jsonBuilder.Append("\":\"");
                    jsonBuilder.Append(dt.Rows[i][j].ToString());
                    jsonBuilder.Append("\",");
                }
                jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                jsonBuilder.Append("},");
            }
            jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
            jsonBuilder.Append("]");
            if (withTableName) jsonBuilder.Append("}");
            return jsonBuilder.ToString();
        }
    }
}
