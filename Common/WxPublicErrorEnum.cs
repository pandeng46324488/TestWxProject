using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// 微信错误类枚举
    /// </summary>
    public enum WxPublicErrorEnum
    {     
        /// <summary>
        /// -1 系统繁忙
        /// </summary>
        SystemIsBusy = -1,

        /// <summary>
        /// 0 请求成功
        /// </summary>
        RequestSuccess = 0,

        /// <summary>
        /// 40003 非法的openid
        /// </summary>
        IllegalOpenId = 40003,

        /// <summary>
        /// 40013 不合法的AppId
        /// </summary>
        IllegalAppId = 40013,

        /// <summary>
        /// 40014 不合法的AccessToken
        /// </summary>
        IllegalAccessToken = 40014,

        /// <summary>
        /// 40029 不合法的Oauth_code
        /// </summary>
        IllegalOauthCode = 40029,

        /// <summary>
        /// 40030 不合法的RefreshToken
        /// </summary>
        IllegalRefreshToken = 40030,

    }
}
