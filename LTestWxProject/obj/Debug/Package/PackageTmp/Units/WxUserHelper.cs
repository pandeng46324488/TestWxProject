using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity;
using Newtonsoft.Json;

namespace TestWxProject.Units
{
    /// <summary>
    /// 微信用户帮助类
    /// </summary>
    public class WxUserHelper
    {
        #region 网页授权获取用户
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accesstoken"></param>
        /// <param name="openid"></param>
        /// <param name="errors"></param>
        /// <returns></returns>
        public static WxWebPageUserEntity GetWebPageUserInfo( string accesstoken, string openid)
        {
            WxWebPageUserEntity ReturnObj = new WxWebPageUserEntity();

            if( string.IsNullOrEmpty( openid)) //检查openid
            {
                ReturnObj.errorObj = new WxErrorEntity(-1, "openid为空");
                return null;
            }            
            
            //获取用户信息
            string JsonStr = Common.GetJsonResult(
                string.Format("https://api.weixin.qq.com/sns/userinfo?access_token={0}&openid={1}&lang=zh_CN", accesstoken, openid),
                IsHttps: true
            );

            if (Common.IsErrorMessage(JsonStr)) //检查是否发生了异常或是错误
            {
                ReturnObj.errorObj = JsonConvert.DeserializeObject<WxErrorEntity>(JsonStr);
            }

            ReturnObj = JsonConvert.DeserializeObject<WxWebPageUserEntity>(JsonStr);

            return ReturnObj;
        }
        #endregion
    }
}