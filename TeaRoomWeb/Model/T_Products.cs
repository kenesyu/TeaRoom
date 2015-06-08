/**  版本信息模板在安装目录下，可自行修改。
* T_Products.cs
*
* 功 能： N/A
* 类 名： T_Products
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/3/23 星期一 13:22:22   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using IsTech.EnterpriseLibrary.Data;
using System.Data.SqlClient;
using System.Configuration;
using TeaRoomWeb.Helper;
using System.Data;
namespace TeaRoomWeb.Model
{
	/// <summary>
	/// 商品信息
	/// </summary>
	[Serializable]
	public partial class T_Products
	{
		public T_Products()
		{}
		#region Model
		private int _productid;
		private string _productname;
		private int? _isinventory;
		private int? _inventoryid;
		private int? _lostinventory;
		private decimal? _memberprice;
		private decimal? _price;
		private int? _productsource;
        private int? _producttypeid;
        private string _producttypename;
		/// <summary>
		/// 
		/// </summary>
		public int ProductID
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProductName
		{
			set{ _productname=value;}
			get{return _productname;}
		}
		/// <summary>
		/// 1. 删减库存 默认0 不删减
		/// </summary>
		public int? IsInventory
		{
			set{ _isinventory=value;}
			get{return _isinventory;}
		}
		/// <summary>
		/// 如要扣库存些项必须添写
		/// </summary>
		public int? InventoryID
		{
			set{ _inventoryid=value;}
			get{return _inventoryid;}
		}
		/// <summary>
		/// 减少库存数量
		/// </summary>
		public int? LostInventory
		{
			set{ _lostinventory=value;}
			get{return _lostinventory;}
		}
		/// <summary>
		/// 会员价格
		/// </summary>
		public decimal? MemberPrice
		{
			set{ _memberprice=value;}
			get{return _memberprice;}
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
		/// 商品来源 1.茶社 2.饭店
		/// </summary>
		public int? ProductSource
		{
			set{ _productsource=value;}
			get{return _productsource;}
		}

        /// <summary>
        /// 所属分类
        /// </summary>
        public int? ProductTypeID
        {
            set { _producttypeid = value; }
            get { return _producttypeid; }
        }


        public string ProductTypeName
        {
            set { _producttypename = value; }
            get { return _producttypename; }
        }

		#endregion Model

        #region Function

        public static List<T_Products> GetProductList() {
            DataBaseHelper dbHelper = new DataBaseHelper(ConfigurationManager.ConnectionStrings["DB"].ToString());
            DataTable dt = dbHelper.ExecuteDataTable("", "Proc_GetProductList", null, true);
            dbHelper.Dispose();
            return ConvertHelper<T_Products>.ConvertToList(dt);
        }

        #endregion

    }
}

