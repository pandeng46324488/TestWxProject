using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity
{
    /// <summary>
    /// 网页授权信息返回实体类
    /// </summary>
    [Serializable]
    public partial class WebPageAccessTokenEntity : BaseWeChatEntity
    {
        #region 属性
        /// <summary>
        /// 网页授权接口调用凭证,注意：此access_token与基础支持的access_token不同
        /// </summary>
        public string access_token { get; set; }

        /// <summary>
        /// access_token接口调用凭证超时时间，单位（秒）
        /// </summary>
        public int expires_in { get; set; }

        /// <summary>
        /// 用户刷新access_token
        /// </summary>
        public string refresh_token { get; set; }

        /// <summary>
        /// 用户唯一标识，请注意，在未关注公众号时，用户访问公众号的网页，也会产生一个用户和公众号唯一的OpenID
        /// </summary>
        public string openid { get; set; }
        
        /// <summary>
        /// 用户授权的作用域，使用逗号（,）分隔
        /// </summary>
        public string scope { get; set; }

        /// <summary>
        /// 上次获取时间
        /// </summary>
        public DateTime last_get_time{ get;set;}
        #endregion  
      
        #region 方法
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public WebPageAccessTokenEntity CopyEntity(WebPageAccessTokenEntity a)
        {
            this.access_token = a.access_token;
            this.expires_in = a.expires_in;
            this.last_get_time = a.last_get_time;
            this.openid = a.openid;
            this.refresh_token = a.refresh_token;
            this.scope = a.scope;
            return this;
        }
        #endregion
        
    }
}