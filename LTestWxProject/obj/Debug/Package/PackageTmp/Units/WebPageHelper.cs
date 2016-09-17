using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity;
using Common;
using Newtonsoft.Json;

namespace TestWxProject.Units
{
    public class WebPageHelper
    {
        #region 属性
        
        #endregion

        #region 方法
        /// <summary>
        /// 获取WebPageAccessToken
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static WebPageAccessTokenEntity GetWebPageAccessToken(string code)
        {
            WebPageAccessTokenEntity ReturnObj = null;
            string JsonResult = Common.GetJsonResult(
                string.Format("https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code", Setting.AppId, Setting.AppSecret, code),
                IsHttps: true
            );

            if (Common.IsErrorMessage(JsonResult))
            {
                //发生异常
                throw new WxRequestException(JsonConvert.DeserializeObject<WxErrorEntity>(JsonResult));
            }
                
            ReturnObj = JsonConvert.DeserializeObject<WebPageAccessTokenEntity>(JsonResult);
            ReturnObj.last_get_time = DateTime.Now;

            return ReturnObj;            
        }
        #endregion
    }
}