/**  版本信息模板在安装目录下，可自行修改。
* T_Operat_Group.cs
*
* 功 能： N/A
* 类 名： T_Operat_Group
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
namespace TeaRoomWeb.Model
{
	/// <summary>
	/// 用户组
	/// </summary>
	[Serializable]
	public partial class T_Operat_Group
	{
		public T_Operat_Group()
		{}
		#region Model
		private int _groupid;
		private string _groupname;
		/// <summary>
		/// 
		/// </summary>
		public int GroupID
		{
			set{ _groupid=value;}
			get{return _groupid;}
		}
		/// <summary>
		/// 组名称
		/// </summary>
		public string GroupName
		{
			set{ _groupname=value;}
			get{return _groupname;}
		}
		#endregion Model

	}
}

