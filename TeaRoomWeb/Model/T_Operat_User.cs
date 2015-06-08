using System;
using System.Data;
using IsTech.EnterpriseLibrary.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using TeaRoomWeb.Helper;

namespace TeaRoomWeb.Model
{
    /// <summary>
    /// T_Operat_User:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class T_Operat_User
    {
        public T_Operat_User()
        { }

        #region Model
        private int _operatid;
        private string _password;
        private string _username;
        private string _operatname;
        private string _tel;
        private int? _active;
        private int? _operatgroup;
        private string _groupname;
        private string _status;


        public string Status {
            set { _status = value; }
            get { return _status; }
        }


        /// <summary>
        /// 
        /// </summary>
        public int OperatID
        {
            set { _operatid = value; }
            get { return _operatid; }
        }
        /// <summary>
        /// 登陆密码
        /// </summary>
        public string PassWord
        {
            set { _password = value; }
            get { return _password; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 操作员姓名
        /// </summary>
        public string OperatName
        {
            set { _operatname = value; }
            get { return _operatname; }
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Tel
        {
            set { _tel = value; }
            get { return _tel; }
        }
        /// <summary>
        /// 0 禁止 1 激活
        /// </summary>
        public int? Active
        {
            set { _active = value; }
            get { return _active; }
        }
        /// <summary>
        /// 用户组
        /// </summary>
        public int? OperatGroup
        {
            set { _operatgroup = value; }
            get { return _operatgroup; }
        }


        public string GroupName {
            set { _groupname = value; }
            get { return _groupname; }
        }
        #endregion Model

        #region Function
        /// <summary>
        /// 用户登陆返回用户信息
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static T_Operat_User GetOperaterInfo(string username,string Password) {
            T_Operat_User operater = new T_Operat_User();
            DataBaseHelper dbHelper = new DataBaseHelper(ConfigurationManager.ConnectionStrings["DB"].ToString());
            DataTable dt = dbHelper.ExecuteDataTable("", "select * from T_Operat_User where username = @username and password = @password and Active = 1",
                new SqlParameter[] { new SqlParameter("username", username), new SqlParameter("password", Password) });
            if (dt.Rows.Count > 0) {
                operater.OperatID = Convert.ToInt32(dt.Rows[0]["OperatID"].ToString());
                operater.PassWord = dt.Rows[0]["PassWord"].ToString();
                operater.UserName = dt.Rows[0]["UserName"].ToString();
                operater.OperatName = dt.Rows[0]["OperatName"].ToString();
                operater.Tel = dt.Rows[0]["Tel"].ToString();
                operater.Active = Convert.ToInt32(dt.Rows[0]["Active"].ToString());
                operater.OperatGroup = Convert.ToInt32(dt.Rows[0]["OperatGroup"].ToString());
            }
            dbHelper.Dispose();
            return operater;
        }

        public static List<T_Operat_User> GetOperatList() {
            DataBaseHelper dbHelper = new DataBaseHelper(ConfigurationManager.ConnectionStrings["DB"].ToString());
            DataTable dt = dbHelper.ExecuteDataTable("", "Proc_GetOperatList", null, true);
            dbHelper.Dispose();
            return ConvertHelper<T_Operat_User>.ConvertToList(dt);
        }

        public static int SaveOrUpdate(string Password,string UserName,string OperatName,string Tel,string Active,string OperatGroup,string OperatID)
        {
            DataBaseHelper dbHelper = new DataBaseHelper(ConfigurationManager.ConnectionStrings["DB"].ToString());
            int count = dbHelper.ExecuteNonQuery("Proc_AddOrUpdateOperater",
                new SqlParameter[] { 
                    new SqlParameter("@PassWord", Password), 
                    new SqlParameter("@UserName", UserName),
                    new SqlParameter("@OperatName", OperatName), 
                    new SqlParameter("@Tel", Tel), 
                    new SqlParameter("@Active", Active), 
                    new SqlParameter("@OperatGroup", OperatGroup), 
                    new SqlParameter("@OperatID", OperatID), 
                }, true);
            dbHelper.Dispose();
            return count;
        }

        #endregion

    }
}

