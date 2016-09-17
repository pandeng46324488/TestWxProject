using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class WxRequestException : Exception
    {
        #region 属性
        public WxErrorEntity WxErrorObj { get; set; }
        #endregion

        #region 方法
        public WxRequestException()
        {
        }

        public WxRequestException(Exception e) : base()
        {

        }

        public WxRequestException(string msg)
            : base(msg)
        {
        }

        public WxRequestException(WxErrorEntity e): base(e.errmsg)
        {
            this.WxErrorObj = e;
        }
        #endregion
    }
}
