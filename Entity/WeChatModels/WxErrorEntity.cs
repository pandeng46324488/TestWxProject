using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity
{
    /// <summary>
    /// 微信错误信息实体类
    /// </summary>
    [Serializable]
    public class WxErrorEntity
    {
        #region 属性
        /// <summary>
        /// 错误代码
        /// </summary>
        public int errcode { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string errmsg { get; set; }
        #endregion

        #region 构造函数
        public WxErrorEntity()
        {
            //默认构造函数
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="errcode">错误代码</param>
        /// <param name="errmsg">错误信息</param>
        public WxErrorEntity(int errcode, string errmsg)
        {
            this.errcode = errcode;
            this.errmsg = errmsg;
        }
        #endregion
    }
}