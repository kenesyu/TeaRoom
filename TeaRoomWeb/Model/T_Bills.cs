/**  版本信息模板在安装目录下，可自行修改。
* T_Bills.cs
*
* 功 能： N/A
* 类 名： T_Bills
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
	public partial class T_Bills
	{
		public T_Bills()
		{}
		#region Model
		private int _billid;
		private decimal? _billprice;
		private decimal? _offprice;
		private decimal? _realprice;
		private int? _paytype;
		private int? _signid;
		private string _cardno;
		private string _comments;
		private int? _operatid;
		private DateTime? _createdate;
		/// <summary>
		/// 
		/// </summary>
		public int BillID
		{
			set{ _billid=value;}
			get{return _billid;}
		}
		/// <summary>
		/// 帐单金额
		/// </summary>
		public decimal? BillPrice
		{
			set{ _billprice=value;}
			get{return _billprice;}
		}
		/// <summary>
		/// 减免金额
		/// </summary>
		public decimal? OffPrice
		{
			set{ _offprice=value;}
			get{return _offprice;}
		}
		/// <summary>
		/// 实付金额
		/// </summary>
		public decimal? RealPrice
		{
			set{ _realprice=value;}
			get{return _realprice;}
		}
		/// <summary>
		/// 支付方式 1.现金 2.银行卡 3.会员卡刷卡 4.签单 5.免单
		/// </summary>
		public int? PayType
		{
			set{ _paytype=value;}
			get{return _paytype;}
		}
		/// <summary>
		/// 签单人员ID
		/// </summary>
		public int? SignID
		{
			set{ _signid=value;}
			get{return _signid;}
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
		/// 备注
		/// </summary>
		public string Comments
		{
			set{ _comments=value;}
			get{return _comments;}
		}
		/// <summary>
		/// 操作人
		/// </summary>
		public int? OperatID
		{
			set{ _operatid=value;}
			get{return _operatid;}
		}
		/// <summary>
		/// 创建日期
		/// </summary>
		public DateTime? CreateDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		#endregion Model

	}
}

