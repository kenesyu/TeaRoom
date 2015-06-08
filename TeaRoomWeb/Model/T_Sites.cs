/**  版本信息模板在安装目录下，可自行修改。
* T_Sites.cs
*
* 功 能： N/A
* 类 名： T_Sites
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
	/// 场地信息
	/// </summary>
	[Serializable]
	public partial class T_Sites
	{
		public T_Sites()
		{}
		#region Model
		private int _siteid;
		private int? _sitetype;
		private string _sitename;
		private string _numofperson;
		private int? _status;
		private string _comments;
		/// <summary>
		/// 
		/// </summary>
		public int SiteID
		{
			set{ _siteid=value;}
			get{return _siteid;}
		}
		/// <summary>
		/// 1：包间 2：散台
		/// </summary>
		public int? SiteType
		{
			set{ _sitetype=value;}
			get{return _sitetype;}
		}
		/// <summary>
		/// 场地名 包1 包2等
		/// </summary>
		public string SiteName
		{
			set{ _sitename=value;}
			get{return _sitename;}
		}
		/// <summary>
		/// 如是包间添写包间容纳人员如4-6
		/// </summary>
		public string NumOfPerson
		{
			set{ _numofperson=value;}
			get{return _numofperson;}
		}
		/// <summary>
		/// 1：空闲 2：预定 3：使用中 4：结帐 5：清台
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 场地介绍
		/// </summary>
		public string Comments
		{
			set{ _comments=value;}
			get{return _comments;}
		}
		#endregion Model

	}
}

