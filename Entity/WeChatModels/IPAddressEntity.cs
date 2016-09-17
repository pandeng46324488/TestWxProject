using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity
{
    /// <summary>
    /// 微信服务器IP地址
    /// </summary>
    [Serializable]
    public class IPAddressEntity : BaseWeChatEntity
    {
        /// <summary>
        /// IP地址
        /// </summary>
        public List<string> ip_list { get; set; }

        #region 构造器
        public IPAddressEntity()
        {
            ip_list = new List<string>();
        }
        #endregion
    }
}