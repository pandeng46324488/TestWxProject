using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity
{
    /// <summary>
    /// 客服账号
    /// </summary>
    [Serializable]
    public class ClientServiceEntity : BaseWeChatEntity
    {
        #region 属性
        /// <summary>
        /// 微信号
        /// </summary>
        public string kf_account { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string nickname { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string password { get; set; }
        #endregion
        
        #region 方法
        public ClientServiceEntity() { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="account"></param>
        /// <param name="nickname"></param>
        /// <param name="password"></param>
        public ClientServiceEntity(string account, string nickname, string password)
        {
            this.kf_account = account;
            this.nickname = nickname;
            this.password = password;
        }
        #endregion
    }
}