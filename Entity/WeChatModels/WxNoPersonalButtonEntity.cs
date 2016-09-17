using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity
{
    /// <summary>
    /// 非个性化菜单
    /// </summary>
    [Serializable]
    public class WxNoPersonalButtonEntity : BaseWeChatEntity
    {
        #region 属性
        public Wx_NoPersonal_Button_LevelOne_Entity menu { get; set; }
        #endregion

        #region 方法
        public WxNoPersonalButtonEntity()
        {
            menu = new Wx_NoPersonal_Button_LevelOne_Entity();
        }
        #endregion
    }

    /// <summary>
    /// 一级菜单
    /// </summary>
    [Serializable]
    public class Wx_NoPersonal_Button_LevelOne_Entity
    {
        #region 属性
        /// <summary>
        /// 按钮
        /// </summary>
        public List<WxNoPersonalItemButtonEntity> button { get; set; }

        /// <summary>
        /// 调用新增永久素材接口返回的合法media_id
        /// </summary>
        public string menuid { get; set; }
        #endregion

        #region 方法
        public Wx_NoPersonal_Button_LevelOne_Entity()
        {
            button = new List<WxNoPersonalItemButtonEntity>();
        }
        #endregion
    }

    /// <summary>
    /// 非个性化单个按钮实体类
    /// </summary>
    [Serializable]
    public class WxNoPersonalItemButtonEntity
    {
        #region 属性
        /// <summary>
        /// 菜单的响应动作类型
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// 菜单标题，不超过16个字节，子菜单不超过60个字节
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 菜单KEY值，用于消息接口推送，不超过128字节
        /// </summary>
        public string key { get; set; }

        /// <summary>
        /// 网页链接，用户点击菜单可打开链接，不超过1024字节
        /// </summary>
        public string url { get; set; }

        public List<WxNoPersonalItemButtonEntity> sub_button { get; set; }
        #endregion

        #region 方法
        public WxNoPersonalItemButtonEntity()
        {
            sub_button = new List<WxNoPersonalItemButtonEntity>();
        }
        #endregion
    }
}