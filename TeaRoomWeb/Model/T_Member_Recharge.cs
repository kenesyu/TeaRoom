/**  版本信息模板在安装目录下，可自行修改。
* T_Member_Recharge.cs
*
* 功 能： N/A
* 类 名： T_Member_Recharge
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/3/23 星期一 13:22:20   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace TeaRoomWeb.Model
{
	/// <summary>
	/// 会员充值表
	///   
	/// </summary>
	[Serializable]
	public partial class T_Member_Recharge
	{
		public T_Member_Recharge()
		{}
		#region Model
		private int _rechargeid;
		private int? _memberid;
		private DateTime? _rechargedate;
		private decimal? _amount;
		private int? _operatid;
		/// <summary>
		/// 主键ID
		/// </summary>
		public int RechargeID
		{
			set{ _rechargeid=value;}
			get{return _rechargeid;}
		}
		/// <summary>
		/// 会员ID
		/// </summary>
		public int? MemberID
		{
			set{ _memberid=value;}
			get{return _memberid;}
		}
		/// <summary>
		/// 充值日期
		/// </summary>
		public DateTime? RechargeDate
		{
			set{ _rechargedate=value;}
			get{return _rechargedate;}
		}
		/// <summary>
		/// 充值金额
		/// </summary>
		public decimal? Amount
		{
			set{ _amount=value;}
			get{return _amount;}
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

	}
}

