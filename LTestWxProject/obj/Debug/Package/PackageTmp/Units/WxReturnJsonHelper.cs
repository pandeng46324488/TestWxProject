using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Entity;

namespace TestWxProject.Units
{
    /// <summary>
    /// 此类用于处理对于微信返回的信息处理
    /// </summary>
    public class WxReturnJsonHelper
    {
        #region Json处理
        /// <summary>
        /// 
        /// </summary>
        /// <param name="jsonStr"></param>
        /// <param name="Ex"></param>
        /// <returns></returns>
        public static string JsonDeal(string jsonStr, Exception Ex = null)
        {
            if (string.IsNullOrEmpty(jsonStr))
            {
                //如果是空串，则表示未请求到数据,请求网络超时，或者是发生异常
                if (null == Ex)
                {
                    //如果没有发生异常，则表明网络阻塞
                    return JsonConvert.SerializeObject(new WxErrorEntity(-2, "网速较慢或者网络异常、阻塞"));
                }
                else
                {
                    //发生异常
                    return JsonConvert.SerializeObject(new WxErrorEntity(-3, Ex.Message));
                }
            }

            return jsonStr;
        }
        #endregion

        #region Xml处理
        
        #endregion
    }
}