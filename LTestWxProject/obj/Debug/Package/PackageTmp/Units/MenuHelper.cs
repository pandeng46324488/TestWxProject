using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity;
using Newtonsoft.Json;

namespace TestWxProject.Units
{
    /// <summary>
    /// 自定义菜单帮助类
    /// </summary>
    public class MenuHelper
    {
        #region 获取自定义菜单配置接口
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static WxNoPersonalButtonEntity GetButtonList()
        {
            string JsonResult = Common.GetJsonResult(
                string.Format("https://api.weixin.qq.com/cgi-bin/menu/get?access_token={0}",Common.Access_Token),
                IsHttps:true
            );

            if (Common.IsErrorMessage(JsonResult))
            {
                return new WxNoPersonalButtonEntity();
            }

            return JsonConvert.DeserializeObject<WxNoPersonalButtonEntity>(JsonResult);
        }
        #endregion

        #region 创建菜单
        /// <summary>
        /// 创建菜单
        /// </summary>
        /// <param name="postData"></param>
        /// <returns></returns>
        public static bool CreateButton(string postData)
        {
            string JsonResult = Common.GetJsonResult(
                string.Format("https://api.weixin.qq.com/cgi-bin/menu/create?access_token={0}", Common.Access_Token),
                PostData : postData,
                Method:"POST",
                IsHttps:true
            );

            WxErrorEntity errorEntity = JsonConvert.DeserializeObject<WxErrorEntity>(JsonResult);

            return errorEntity.errcode == 0;
        }
        #endregion
    }
}