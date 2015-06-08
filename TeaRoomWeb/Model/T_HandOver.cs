/**  版本信息模板在安装目录下，可自行修改。
* T_HandOver.cs
*
* 功 能： N/A
* 类 名： T_HandOver
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/3/23 星期一 13:22:19   N/A    初版
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
	/// 帐单
	/// </summary>
	[Serializable]
	public partial class T_HandOver
	{
		public T_HandOver()
		{}
		#region Model
		private int _id;
		private DateTime? _handovertime;
		private decimal? _totalamount;
		private decimal? _confirmamount;
		private int? _handovertype;
		private DateTime? _periodday;
		private int? _operatid_a;
		private int? _operatid_b;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 操作时间
		/// </summary>
		public DateTime? HandOverTime
		{
			set{ _handovertime=value;}
			get{return _handovertime;}
		}
		/// <summary>
		/// 应收金额
		/// </summary>
		public decimal? TotalAmount
		{
			set{ _totalamount=value;}
			get{return _totalamount;}
		}
		/// <summary>
		/// 确认金额
		/// </summary>
		public decimal? ConfirmAmount
		{
			set{ _confirmamount=value;}
			get{return _confirmamount;}
		}
		/// <summary>
		/// 1. 交班 2. 关帐
		/// </summary>
		public int? HandOverType
		{
			set{ _handovertype=value;}
			get{return _handovertype;}
		}
		/// <summary>
		/// 帐期日
		/// </summary>
		public DateTime? PeriodDay
		{
			set{ _periodday=value;}
			get{return _periodday;}
		}
		/// <summary>
		/// 交班人
		/// </summary>
		public int? OperatID_A
		{
			set{ _operatid_a=value;}
			get{return _operatid_a;}
		}
		/// <summary>
		/// 接班人 如关帐则没有接班人
		/// </summary>
		public int? OperatID_B
		{
			set{ _operatid_b=value;}
			get{return _operatid_b;}
		}
		#endregion Model

	}
}

