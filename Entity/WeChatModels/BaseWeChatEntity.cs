using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    /// <summary>
    /// 请求微信api返回结果基类（主要是含有错误实体类对象属性）
    /// </summary> 
    public class BaseWeChatEntity
    {
        #region 属性
        /// <summary>
        /// 错误信息
        /// </summary>
        public WxErrorEntity errorObj { get; set; }
        #endregion

        #region 构造函数
        public BaseWeChatEntity()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="errcode">错误代码</param>
        /// <param name="errmsg">错误信息</param>
        public BaseWeChatEntity(int errcode, string errmsg)
        {
            this.errorObj = new WxErrorEntity();
            this.errorObj.errcode = errcode;
            this.errorObj.errmsg = errmsg;
        }
        #endregion
    }
}
