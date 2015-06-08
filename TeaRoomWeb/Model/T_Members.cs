/**  版本信息模板在安装目录下，可自行修改。
* T_Members.cs
*
* 功 能： N/A
* 类 名： T_Members
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/3/23 星期一 13:22:21   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.Data;
using IsTech.EnterpriseLibrary.Data;
using System.Configuration;
using System.Data.SqlClient;
using TeaRoomWeb.Helper;

namespace TeaRoomWeb.Model
{
	/// <summary>
	/// 会员表
	///   
	/// </summary>
	[Serializable]
    public partial class T_Members 
	{
		public T_Members()
		{}

		#region Model
		private int _memberid;
		private string _name;
        private string _sex;
		private string _cardno;
		private DateTime? _birthday;
		private string _openid;
		private string _tel;
		private decimal? _amount;
		private DateTime? _createdate;
		private int? _operatid;
		/// <summary>
		/// 会员ID
		/// </summary>
		public int MemberID
		{
			set{ _memberid=value;}
			get{return _memberid;}
		}
		/// <summary>
		/// 会员姓名
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}

        public string Sex
        {
            set { _sex = value; }
            get { return _sex; }
        }

		/// <summary>
		/// 会员卡号
		/// </summary>
		public string CardNo
		{
			set{ _cardno=value;}
			get{return _cardno;}
		}
		/// <summary>
		/// 生日
		/// </summary>
		public DateTime? Birthday
		{
			set{ _birthday=value;}
			get{return _birthday;}
		}
		/// <summary>
		/// 如绑定微信则有OpenID
		/// </summary>
		public string OpenID
		{
			set{ _openid=value;}
			get{return _openid;}
		}
		/// <summary>
		/// 电话
		/// </summary>
		public string Tel
		{
			set{ _tel=value;}
			get{return _tel;}
		}
		/// <summary>
		/// 开卡金额
		/// </summary>
		public decimal? Amount
		{
			set{ _amount=value;}
			get{return _amount;}
		}
		/// <summary>
		/// 创建日期
		/// </summary>
		public DateTime? CreateDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// 操作人
		/// </summary>
		public int? OperatID
		{
			set{ _operatid=value;}
			get{return _operatid;}
		}
		#endregion Model

        #region Function

        public static List<T_Members> GetList(int Page, int PageSize,string strWhere,out int TotalCount)
        {
            DataBaseHelper dbHelper = new DataBaseHelper(ConfigurationManager.ConnectionStrings["DB"].ToString());

            SqlParameter[] splist = new SqlParameter[]{
                new SqlParameter("@TableName","T_Members"),
                new SqlParameter("@ReFieldsStr","*"),
                new SqlParameter("@OrderString","MemberID desc"),
                new SqlParameter("@WhereString",strWhere),
                new SqlParameter("@PageSize",PageSize),
                new SqlParameter("@PageIndex",Page),
                new SqlParameter("@TotalRecord",ParameterDirection.Output)
            
            };
            splist[6].Direction = ParameterDirection.Output;
            //splist[]
            DataTable dt = dbHelper.ExecuteDataTable("", "Proc_ShowList", splist, true);
            TotalCount = Convert.ToInt32(splist[6].Value.ToString());
            dbHelper.Dispose();

            return ConvertHelper<T_Members>.ConvertToList(dt);
        }

        public static Message AddMembers(string Name, string Sex,string CardNo, string Birthday, string Tel, decimal Amount, string OperatID)
        {
            DataBaseHelper dbHelper = new DataBaseHelper(ConfigurationManager.ConnectionStrings["DB"].ToString());
            DataTable dt = dbHelper.ExecuteDataTable("", "Proc_AddMembers", new SqlParameter[]{
                new SqlParameter("@Name",Name),
                new SqlParameter("@Sex",Sex),
                new SqlParameter("@CardNo",CardNo),
                new SqlParameter("@Birthday",Birthday),
                new SqlParameter("@Tel",Tel),
                new SqlParameter("@Amount",Amount),
                new SqlParameter("@OperatID",OperatID),
            }, true);
            dbHelper.Dispose();

            Message message = new Message();
            message.Status = Convert.ToInt32(dt.Rows[0][0].ToString());
            message.MessageString = dt.Rows[0][1].ToString();
            return message;
        }

        public static Message MemberRecharge(int MemberID, string Amount, string OperatID) {
            DataBaseHelper dbHelper = new DataBaseHelper(ConfigurationManager.ConnectionStrings["DB"].ToString());
            DataTable dt = dbHelper.ExecuteDataTable("", "Proc_MemberRecharge", new SqlParameter[]{
                new SqlParameter("@MemberID",MemberID),
                new SqlParameter("@Amount",Amount),
                new SqlParameter("@OperatID",OperatID),
            }, true);
            dbHelper.Dispose();

            Message message = new Message();
            message.Status = Convert.ToInt32(dt.Rows[0][0].ToString());
            message.MessageString = dt.Rows[0][1].ToString();
            return message;
        }

        public static Message UpdateMember(int MemberID, string Name,string Sex, string Birthday, string Tel) {
            DataBaseHelper dbHelper = new DataBaseHelper(ConfigurationManager.ConnectionStrings["DB"].ToString());
            DataTable dt = dbHelper.ExecuteDataTable("", "Proc_UpdateMembers", new SqlParameter[]{
                new SqlParameter("@MemberID",MemberID),
                new SqlParameter("@Name",Name),
                new SqlParameter("@Sex",Sex),
                new SqlParameter("@Birthday",Birthday),
                new SqlParameter("@Tel",Tel)
            }, true);
            dbHelper.Dispose();

            Message message = new Message();
            message.Status = Convert.ToInt32(dt.Rows[0][0].ToString());
            message.MessageString = dt.Rows[0][1].ToString();
            return message;
        }


        public static T_Members GetMemberByCardNo(string CardNo)
        {
            DataBaseHelper dbHelper = new DataBaseHelper(ConfigurationManager.ConnectionStrings["DB"].ToString());
            DataTable dt = dbHelper.ExecuteDataTable("", "Proc_GetMemberByCardNo", new SqlParameter[]{
                new SqlParameter("@CardNo",CardNo),
            }, true);
            dbHelper.Dispose();

            T_Members member = new T_Members();

            if (dt.Rows.Count > 0) {
                member.MemberID = Convert.ToInt32(dt.Rows[0]["MemberID"].ToString());
                member.Name = dt.Rows[0]["Name"].ToString();
                member.CardNo = dt.Rows[0]["CardNo"].ToString();
                member.Birthday = Convert.ToDateTime(dt.Rows[0]["Birthday"].ToString());
                member.OpenID = dt.Rows[0]["OpenID"].ToString();
                member.Amount = Convert.ToDecimal(dt.Rows[0]["Amount"].ToString());
            }
            return member;
        }
        #endregion
    }
}

