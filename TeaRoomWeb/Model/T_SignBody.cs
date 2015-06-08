/**  版本信息模板在安装目录下，可自行修改。
* T_SignBody.cs
*
* 功 能： N/A
* 类 名： T_SignBody
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
	/// 签单主体
	/// </summary>
	[Serializable]
	public partial class T_SignBody
	{
		public T_SignBody()
		{}
		#region Model
		private int _signid;
		private string _signname;
		private string _comments;
		private DateTime? _createdate;
		/// <summary>
		/// 
		/// </summary>
		public int SignID
		{
			set{ _signid=value;}
			get{return _signid;}
		}
		/// <summary>
		/// 签单人或单位
		/// </summary>
		public string SignName
		{
			set{ _signname=value;}
			get{return _signname;}
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
		/// 
		/// </summary>
		public DateTime? CreateDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		#endregion Model

	}
}

