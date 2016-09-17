using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class WebPageTicketEntity
    {
        #region 属性
        /// <summary>
        /// 错误码
        /// </summary>
        public string errcode { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string errmsg { get; set; }

        /// <summary>
        /// 票据凭证
        /// </summary>
        public string ticket { get; set; }

        /// <summary>
        /// 有效时长，单位：秒
        /// </summary>
        public int expires_in { get; set; }

        /// <summary>
        /// 最后获取时间
        /// </summary>
        public DateTime LastGetTime { get; set; }
        #endregion

        #region 方法
        public WebPageTicketEntity()
        {            
        }
        #endregion
    }
}
