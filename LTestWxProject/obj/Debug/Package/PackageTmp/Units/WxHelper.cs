using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestWxProject.Units;
using Entity;
using Newtonsoft.Json;

namespace TestWxProject.Units
{
    /// <summary>
    /// 微信公共帮助类
    /// </summary>
    public class WxHelper
    {
        #region 获取微信服务器IP地址
        /// <summary>
        /// 获取微信服务器IP地址
        /// </summary>
        /// <returns></returns>
		public static IPAddressEntity GetServiceIpAddress()
        {
            IPAddressEntity ReturnObj = new IPAddressEntity();

            string ResultJson = Common.GetJsonResult(
                string.Format("Https://api.weixin.qq.com/cgi-bin/getcallbackip?access_token={0}", Common.Access_Token)
            );

            if ( Common.IsErrorMessage( ResultJson ) )
            {
                //如果错误
                ReturnObj.errorObj = JsonConvert.DeserializeObject<WxErrorEntity>(ResultJson);
            }

            return ReturnObj = JsonConvert.DeserializeObject<IPAddressEntity>(ResultJson);
        }
	    #endregion

        #region 客服
        public bool AddClientService( string account, string nickname, string pass )
        {
            ClientServiceEntity dataObj = new ClientServiceEntity();
            return false;
        }
        #endregion

        #region 获取微信公众号列表
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nextOpenId">列表的下一个openId</param>
        /// <returns></returns>
        public static WxUserEntity GetWxUserList(string nextOpenId = "")
        {
            string ResultJson = Common.GetJsonResult(
                string.Format("https://api.weixin.qq.com/cgi-bin/user/get?access_token={0}&next_openid={1}"
                ,Common.Access_Token,nextOpenId)
            );

            WxErrorEntity error = null;
            if (Common.IsErrorMessage(ResultJson))
            {
                //如果返回错误
                return null;
            }

            return JsonConvert.DeserializeObject<WxUserEntity>(ResultJson);
        }
        #endregion
    }
}