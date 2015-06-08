/**  版本信息模板在安装目录下，可自行修改。
* T_Inventory.cs
*
* 功 能： N/A
* 类 名： T_Inventory
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
	/// 库存信息
	/// </summary>
	[Serializable]
	public partial class T_Inventory
	{
		public T_Inventory()
		{}
		#region Model
		private int _inventoryid;
		private string _inventorytype;
		private int? _inventorycount;
		private int? _inventoryalert;
		/// <summary>
		/// 
		/// </summary>
		public int InventoryID
		{
			set{ _inventoryid=value;}
			get{return _inventoryid;}
		}
		/// <summary>
		/// 库存种类
		/// </summary>
		public string InventoryType
		{
			set{ _inventorytype=value;}
			get{return _inventorytype;}
		}
		/// <summary>
		/// 库存数量
		/// </summary>
		public int? InventoryCount
		{
			set{ _inventorycount=value;}
			get{return _inventorycount;}
		}
		/// <summary>
		/// 底于多少库存提醒
		/// </summary>
		public int? InventoryAlert
		{
			set{ _inventoryalert=value;}
			get{return _inventoryalert;}
		}
		#endregion Model

	}
}

