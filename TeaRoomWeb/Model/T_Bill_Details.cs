/**  版本信息模板在安装目录下，可自行修改。
* T_Bill_Details.cs
*
* 功 能： N/A
* 类 名： T_Bill_Details
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
	/// 帐单明细表
	/// </summary>
	[Serializable]
	public partial class T_Bill_Details
	{
		public T_Bill_Details()
		{}
		#region Model
		private int _detailsid;
		private int? _billid;
		private int? _productid;
		private decimal? _price;
		private int? _siteid;
		private int? _isoff;
		private int? _operatid;
		private DateTime? _createtime;
		/// <summary>
		/// 
		/// </summary>
		public int DetailsID
		{
			set{ _detailsid=value;}
			get{return _detailsid;}
		}
		/// <summary>
		/// 帐单ID
		/// </summary>
		public int? BillID
		{
			set{ _billid=value;}
			get{return _billid;}
		}
		/// <summary>
		/// 商品
		/// </summary>
		public int? ProductID
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// 价格
		/// </summary>
		public decimal? Price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 场地ID
		/// </summary>
		public int? SiteID
		{
			set{ _siteid=value;}
			get{return _siteid;}
		}
		/// <summary>
		/// 1为赠送不予计费
		/// </summary>
		public int? IsOff
		{
			set{ _isoff=value;}
			get{return _isoff;}
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
		/// 
		/// </summary>
		public DateTime? CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		#endregion Model

	}
}

