using System;

namespace TeaRoomWeb.Model
{
    [Serializable]
    public partial class Message
    {
        public Message()
		{}
        #region Model
        private int _status;
        private string _messagestring;
        /// <summary>
        /// 
        /// </summary>
        public int Status
        {
	        set{ _status=value;}
	        get{return _status;}
        }
        /// <summary>
        /// 帐单金额
        /// </summary>
        public string MessageString
        {
            set { _messagestring = value; }
            get { return _messagestring; }
        }
        #endregion Model
    }

}