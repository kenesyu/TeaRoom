using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using IsTech.EnterpriseLibrary.Data;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using TeaRoomWeb.Model;

namespace TeaRoomWeb.Services
{
    /// <summary>
    /// OperatServices 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class OperatServices : System.Web.Services.WebService
    {

        [WebMethod]
        public T_Operat_User UserLogin(string strUserName, string strPassword)
        {
            return T_Operat_User.GetOperaterInfo(strUserName, strPassword);
        }

        [WebMethod]
        public List<T_Operat_User> GetOperatList()
        {
            return T_Operat_User.GetOperatList();
        }

        [WebMethod]
        public int SaveOrUpdateOperat(string Password, string UserName, string OperatName, string Tel, string Active, string OperatGroup, string OperatID)
        {
            return T_Operat_User.SaveOrUpdate(Password, UserName, OperatName, Tel, Active, OperatGroup, OperatID);
        }
    }
}
