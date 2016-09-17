using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace TestWxProject.Units
{
    public class Setting
    {

        #region 微信主机信息
        /// <summary>
        /// 静态微信主机信息：隐藏字段
        /// </summary>
        private static string[] _WxDomain = null;

        /// <summary>
        /// 静态微信主机信息
        /// </summary>
        public static string[] WxDomain
        {
            get
            {
                try
                {
                    if (null == _WxDomain) //如果为空，进行初始化
                    {
                        if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["WxDomain"]))
                        {
                            _WxDomain = ConfigurationManager.AppSettings["WxDomain"].ToString().Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries); //读取配置文件
                        }
                        else
                        {
                            _WxDomain = new string[] { };
                        }
                    }
                    return _WxDomain;
                }
                catch (Exception Ex)
                {
                    return new string[] { };
                }
            }
        }


        #region 服务器地址
        private static string _ServiceAddress { get; set; }
        /// <summary>
        /// 服务器地址
        /// </summary>
        public static string ServiceAddress
        {
            get
            {
                if (string.IsNullOrEmpty(_ServiceAddress))
                {
                    _ServiceAddress = GetAppSettingByKey("ServiceAddress");
                }
                return _ServiceAddress;
            }
        }
        #endregion

        #region 测试图片上传
        private static string _ServicePhotoTest { get; set; }

        public static string ServicePhoneTest
        {
            get
            {
                if( string.IsNullOrEmpty( _ServiceAddress ) )
                {
                    _ServiceAddress = GetAppSettingByKey( "ServicePhotoTest" );
                }

                return _ServiceAddress;
            }
        }
        #endregion

        #endregion

        #region 微信验证
        /// <summary>
        /// 微信验证
        /// </summary>
        public static string GetWxConfigToken
        {
            get
            {
                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["WxConfig_Token"]))
                {
                    return ConfigurationManager.AppSettings["WxConfig_Token"].ToString();
                }
                return string.Empty;
            }
        }
        #endregion

        #region 获取指定AppSetting名称的值
        /// <summary>
        /// 获取指定AppSetting名称的值
        /// </summary>
        /// <param name="Key">关键字</param>
        /// <returns></returns>
        public static string GetAppSettingByKey(string Key)
        {
            if (!string.IsNullOrEmpty(Key))
            {
                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings[Key]))
                {
                    return ConfigurationManager.AppSettings[Key];
                }
            }
            return string.Empty;
        }
        #endregion

        #region 获取微信公众号配置
        /// <summary>
        /// AppId
        /// </summary>
        private static string _AppId = string.Empty;

        /// <summary>
        /// AppSecret
        /// </summary>
        private static string _AppSecret = string.Empty;

        /// <summary>
        /// AppId
        /// </summary>
        public static string AppId
        {
            get
            {
                if (string.IsNullOrEmpty(_AppId))
                {
                    _AppId = Setting.GetAppSettingByKey("AppId");
                }

                return _AppId;
            }
        }

        /// <summary>
        /// AppSecret
        /// </summary>
        public static string AppSecret
        {
            get
            {
                if (string.IsNullOrEmpty(_AppSecret))
                {
                    _AppSecret = Setting.GetAppSettingByKey("AppSecret");
                }

                return _AppSecret;
            }
        }
        #endregion

        #region 日志配置
        private static int _Switch_Error = -1;
        private static int _Switch_Request = -1;
        private static int _Switch_Validate = -1;

        private static string _OtherInfoLog { get; set; }

        //public static string OtherInfoLog
        //{
        //    get
        //    {
        //        //if (string.IsNullOrEmpty(_OtherInfoLog))
        //        //{
        //        //    _OtherInfoLog = GetAppSettingByKey("OtherLog");
        //        //}

        //        //return _OtherInfoLog;
        //    }
        //}

        /// <summary>
        /// 是否启用错误记录功能
        /// </summary>
        public static bool ErrorEnable
        {
            get
            {
                if (_Switch_Error < 0)
                {
                    _Switch_Error = string.Compare("true", GetAppSettingByKey("Error_Enable"), true) == 0 ? 1 : 0;
                }

                return _Switch_Error > 0;
            }
        }

        /// <summary>
        /// 是否启用记录请求
        /// </summary>
        public static bool RequestEnable
        {
            get
            {
                if (_Switch_Request < 0)
                {
                    _Switch_Request = string.Compare("true", GetAppSettingByKey("Request_Enable"), true) == 0 ? 1 : 0;
                }

                return _Switch_Request > 0;
            }
        }

        /// <summary>
        /// 是否启用验证记录
        /// </summary>
        public static bool ValidateEnable
        {
            get
            {
                if (_Switch_Validate < 0)
                {
                    _Switch_Validate = string.Compare("true", GetAppSettingByKey("Validate_Enable"), true) == 0 ? 1 : 0;
                }

                return _Switch_Validate > 0 ;
            }
        }
        #endregion

        #region 请求时长
        private static int _RequestTimeout = -1;

        /// <summary>
        /// 请求时长
        /// </summary>
        public static int RequestTimeout
        {
            get
            {
                if( _RequestTimeout <= -1 )
                {
                    if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["RequestTimeout"]))
                    {
                        _RequestTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["RequestTimeout"].ToString());
                    }
                }

                return _RequestTimeout;
            }
        }
        #endregion

    }

    public static class MIMETypeEnum
    {
        /// <summary>
        /// XML
        /// </summary>
        public static string XML_TYPE = "text/xml";

        /// <summary>
        /// Html
        /// </summary>
        public static string HTML_TYPE = "text/html";

        /// <summary>
        /// Html-表单
        /// </summary>
        public static string HTML_FORM_TYPE = "application/x-www-form-urlencoded";
    }
}