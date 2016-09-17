using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity
{
    /// <summary>
    /// 微信公众号用户列表实体
    /// </summary>
    [Serializable]
    public class WxUserEntity : BaseWeChatEntity
    {
        #region 属性
        /// <summary>
        /// 关注该公众账号的总用户数
        /// </summary>
        public int total { get; set; }

        /// <summary>
        /// 拉取的OPENID个数，最大值为10000
        /// </summary>
        public int count { get; set; }

        /// <summary>
        /// 列表数据，OPENID的列表
        /// </summary>
        public WxUserDataEntity data { get; set; }

        /// <summary>
        /// 拉取列表的最后一个用户的OPENID
        /// </summary>
        public string next_openid;
        #endregion

        #region 构造函数
        public WxUserEntity()
        {
            data = new WxUserDataEntity();
        }
        #endregion
    }

    [Serializable]
    public class WxUserDataEntity
    {
        #region 属性
        /// <summary>
        /// 用户openid列表
        /// </summary>
        public List<string> openid { get; set; } 
	    #endregion

        #region 方法
        /// <summary>
        /// 构造函数
        /// </summary>
        public WxUserDataEntity()
        {
            openid = new List<string>();
        }
        #endregion
    }
}