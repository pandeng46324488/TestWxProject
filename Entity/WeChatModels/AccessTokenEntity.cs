using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Entity
{
    /// <summary>
    /// 请求微信Api接口时需要用到的AccessToken实体对象
    /// </summary>
    public class AccessTokenEntity : BaseWeChatEntity
    {
        #region 属性
        /// <summary>
        /// AccessToken 调用接口凭证
        /// </summary>
        public string access_token { get; set; }

        /// <summary>
        /// 有效时间
        /// </summary>
        public int expires_in { get; set; }

        /// <summary>
        /// 最后获取时间
        /// </summary>
        public DateTime LastGetTime { get; set; }
        #endregion

        #region 方法
        public AccessTokenEntity(string jsonData)
        {

        }

        public AccessTokenEntity()
        {

        }
        #endregion
    }
}