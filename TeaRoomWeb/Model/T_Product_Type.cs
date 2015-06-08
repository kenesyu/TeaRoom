/**  版本信息模板在安装目录下，可自行修改。
* T_Product_Type.cs
*
* 功 能： N/A
* 类 名： T_Product_Type
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
namespace TeaRoomWeb.Model
{
	/// <summary>
	/// 商品分类
	///   
	/// </summary>
	[Serializable]
	public partial class T_Product_Type
	{
		public T_Product_Type()
		{}
		#region Model
		private int _producttypeid;
		private string _typename;
		/// <summary>
		/// 
		/// </summary>
		public int ProductTypeID
		{
			set{ _producttypeid=value;}
			get{return _producttypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TypeName
		{
			set{ _typename=value;}
			get{return _typename;}
		}
		#endregion Model

	}
}

