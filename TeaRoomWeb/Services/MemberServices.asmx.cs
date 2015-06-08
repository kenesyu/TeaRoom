using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using TeaRoomWeb.Model;

namespace TeaRoomWeb.Services
{
    /// <summary>
    /// MemberServices 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class MemberServices : System.Web.Services.WebService
    {

        [WebMethod]
        public Message AddMembers(string Name,string Sex, string CardNo, string Birthday, string Tel, decimal Amount, string OperatID)
        {
            return T_Members.AddMembers(Name, Sex, CardNo, Birthday, Tel, Amount, OperatID);
        }

        [WebMethod]
        public List<T_Members> GetMemberList(int Page, int PageSize, string strWhere,out int TotalCount)
        {
            if (strWhere.Trim() != "") { strWhere = "cardNo like '%" + strWhere + "%'"; }
            return T_Members.GetList(Page, PageSize, strWhere,out TotalCount);
        }

        [WebMethod]
        public Message MemberRecharge(int MemberID, string Amount, string OperatID) {
            return T_Members.MemberRecharge(MemberID, Amount, OperatID);
        }

        [WebMethod]
        public Message MemberUpdate(int MemberID,string Name,string Sex,string Birthday,string Tel) {
            return T_Members.UpdateMember(MemberID, Name, Sex ,Birthday, Tel);
        }

        [WebMethod]
        public T_Members GetMemberByCardNo(string CardNo) {
            return T_Members.GetMemberByCardNo(CardNo);
        }
    }
}
