using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Entity
{
    /// <summary>
    /// 自定义菜单接收Json实体类
    /// </summary>
    [Serializable]
    public class WxButtonJsonEntity : BaseWeChatEntity
    {
        #region 属性
        /// <summary>
        /// 菜单是否开启，0代表未开启，1代表开启
        /// </summary>
        public int is_menu_open { get; set; }

        /// <summary>
        /// 菜单信息
        /// </summary>
        public SelfMenu_Info_ENtity selftmenu_info { get; set; }
        #endregion

        #region 方法
        public WxButtonJsonEntity()
        {
            selftmenu_info = new SelfMenu_Info_ENtity();
        }
        #endregion
    }

    /// <summary>
    /// 菜单信息实体类
    /// </summary>
    [Serializable]
    public class SelfMenu_Info_ENtity
    {
        #region 属性
        /// <summary>
        /// 菜单按钮
        /// </summary>
        public List<ButtonEntity> button { get; set; }
        #endregion

        #region 方法
        public SelfMenu_Info_ENtity()
        {
            button = new List<ButtonEntity>();
        }
        #endregion
    }

    /// <summary>
    /// 菜单按钮实体类
    /// </summary>
    [Serializable]
    public class ButtonEntity
    {
        #region 属性
        /// <summary>
        /// 菜单的类型，公众平台官网上能够设置的菜单类型有view（跳转网页）、text（返回文本，下同）、img、photo、video、voice。使用API设置的则有8种，详见《自定义菜单创建接口》
        /// 使用API设置的接口类型总共有如下8种：
        /// 1、click：点击推事件用户点击click类型按钮后，微信服务器会通过消息接口推送消息类型为event的结构给开发者（参考消息接口指南），并且带上按钮中开发者填写的key值，开发者可以通过自定义的key值与用户进行交互；
        /// 2、view：跳转URL用户点击view类型按钮后，微信客户端将会打开开发者在按钮中填写的网页URL，可与网页授权获取用户基本信息接口结合，获得用户基本信息。
        /// 3、scancode_push：扫码推事件用户点击按钮后，微信客户端将调起扫一扫工具，完成扫码操作后显示扫描结果（如果是URL，将进入URL），且会将扫码的结果传给开发者，开发者可以下发消息。
        /// 4、scancode_waitmsg：扫码推事件且弹出“消息接收中”提示框用户点击按钮后，微信客户端将调起扫一扫工具，完成扫码操作后，将扫码的结果传给开发者，同时收起扫一扫工具，然后弹出“消息接收中”提示框，随后可能会收到开发者下发的消息。
        /// 5、pic_sysphoto：弹出系统拍照发图用户点击按钮后，微信客户端将调起系统相机，完成拍照操作后，会将拍摄的相片发送给开发者，并推送事件给开发者，同时收起系统相机，随后可能会收到开发者下发的消息。
        /// 6、pic_photo_or_album：弹出拍照或者相册发图用户点击按钮后，微信客户端将弹出选择器供用户选择“拍照”或者“从手机相册选择”。用户选择后即走其他两种流程。
        /// 7、pic_weixin：弹出微信相册发图器用户点击按钮后，微信客户端将调起微信相册，完成选择操作后，将选择的相片发送给开发者的服务器，并推送事件给开发者，同时收起相册，随后可能会收到开发者下发的消息。
        /// 8、location_select：弹出地理位置选择器用户点击按钮后，微信客户端将调起地理位置选择工具，完成选择操作后，将选择的地理位置发送给开发者的服务器，同时收起位置选择工具，随后可能会收到开发者下发的消息。
        /// 9、media_id：下发消息（除文本消息）用户点击media_id类型按钮后，微信服务器会将开发者填写的永久素材id对应的素材下发给用户，永久素材类型可以是图片、音频、视频、图文消息。请注意：永久素材id必须是在“素材管理/新增永久素材”接口上传后获得的合法id。
        /// 10、view_limited：跳转图文消息URL用户点击view_limited类型按钮后，微信客户端将打开开发者在按钮中填写的永久素材id对应的图文消息URL，永久素材类型只支持图文消息。请注意：永久素材id必须是在“素材管理/新增永久素材”接口上传后获得的合法id。
        /// </summary>
		public string type { get; set; }

        /// <summary>
        /// 菜单名称
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 对于不同的菜单类型，value的值意义不同。
        /// 
        /// 官网上设置的自定义菜单：
        ///     Text:保存文字到value； 
        ///     Img、voice：保存mediaID到value； 
        ///     Video：保存视频下载链接到value； 
        ///     News：保存图文消息到news_info，同时保存mediaID到value； 
        ///     View：保存链接到url。
        /// 使用API设置的自定义菜单： 
        ///     click、scancode_push、scancode_waitmsg、pic_sysphoto、pic_photo_or_album、
        ///     pic_weixin、location_select：保存值到key；
        ///     view：保存链接到url
        /// </summary>
        public string value { get; set; }

        /// <summary>
        /// 子菜单
        /// </summary>
        public Sub_ButtonEntity sub_button { get; set; }

        /// <summary>
        /// 图文消息的信息
        /// </summary>
        public News_InfoEntity news_info { get; set; }
	    #endregion

        #region 方法
        public ButtonEntity()
        {
            sub_button = new Sub_ButtonEntity();
            news_info = new News_InfoEntity();
        }
        #endregion
    }

    /// <summary>
    /// 子菜单集合
    /// </summary>
    [Serializable]
    public class Sub_ButtonEntity
    {
        #region 属性
        public List<ButtonEntity> list { get; set; }
        #endregion

        #region 方法
        public Sub_ButtonEntity()
        {
            list = new List<ButtonEntity>();
        }
        #endregion
    }

    /// <summary>
    /// 图文消息的消息实体类
    /// </summary>
    public class News_InfoEntity
    {
        #region 属性
        public List<News_InfoItemEntity> list { get; set; }
        #endregion

        #region 方法
        public News_InfoEntity()
        {
            list = new List<News_InfoItemEntity>();
        }
        #endregion
    }

    /// <summary>
    /// 图文消息的消息单个实体类
    /// </summary>
    public class News_InfoItemEntity
    {
        #region 属性
        /// <summary>
        /// 图文消息的标题
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// 作者
        /// </summary>
        public string author { get; set; }

        /// <summary>
        /// 摘要
        /// </summary>
        public string digest { get; set; }

        /// <summary>
        /// 是否显示封面，0为不显示，1为显示
        /// </summary>
        public string show_cover { get; set; }

        /// <summary>
        /// 封面图片的URL
        /// </summary>
        public string cover_url { get; set; }

        /// <summary>
        /// 正文的URL
        /// </summary>
        public string content_url { get; set; }

        /// <summary>
        /// 原文的URL，若置空则无查看原文入口
        /// </summary>
        public string source_url { get; set; }
        #endregion
    }
}