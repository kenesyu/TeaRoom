/**  版本信息模板在安装目录下，可自行修改。
* T_Site_Photo.cs
*
* 功 能： N/A
* 类 名： T_Site_Photo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/3/23 星期一 13:22:23   N/A    初版
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
	/// 场地图片
	/// </summary>
	[Serializable]
	public partial class T_Site_Photo
	{
		public T_Site_Photo()
		{}
		#region Model
		private int _photoid;
		private int? _siteid;
		private string _photoname;
		private string _photopath;
		/// <summary>
		/// 
		/// </summary>
		public int PhotoID
		{
			set{ _photoid=value;}
			get{return _photoid;}
		}
		/// <summary>
		/// 场地ID
		/// </summary>
		public int? SiteId
		{
			set{ _siteid=value;}
			get{return _siteid;}
		}
		/// <summary>
		/// 图片名称
		/// </summary>
		public string PhotoName
		{
			set{ _photoname=value;}
			get{return _photoname;}
		}
		/// <summary>
		/// 图片路径
		/// </summary>
		public string PhotoPath
		{
			set{ _photopath=value;}
			get{return _photopath;}
		}
		#endregion Model

	}
}

