using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using Entity;
using TestWxProject.Units;
using Newtonsoft.Json;

namespace TestWxProject.Units
{
    public class Common
    {
        #region 微信验证服务器请求日志路径
        /// <summary>
        /// 微信验证服务器请求日志路径 : 隐藏字段
        /// </summary>
        private static string _ValidateWxLog = string.Empty;

        /// <summary>
        /// 微信验证服务器请求日志路径
        /// </summary>
        public static string ValidateWxLog
        {
            get
            {
                if (string.IsNullOrEmpty(_ValidateWxLog))
                {
                    _ValidateWxLog = Setting.GetAppSettingByKey("ValidateWxLog");
                }

                return _ValidateWxLog;
            }
        }
        #endregion

        #region 日志记录文件路径
        /// <summary>
        /// 日志记录文件路径：隐藏字段
        /// </summary>
        private static string _LogFilePath = string.Empty;

        /// <summary>
        /// 日志记录文件路径
        /// </summary>
        public static string LogFilePath
        {
            get
            {
                if (string.IsNullOrEmpty(_LogFilePath))
                {
                    Common ComObj = new Common();
                    return _LogFilePath = ComObj.GetLogFilePath("ErrorLog");
                }

                return _LogFilePath;
            }
        }
        #endregion

        #region 获取日志记录文件路径
        /// <summary>
        /// 获取日志记录文件路径
        /// </summary>
        /// <returns></returns>
        public string GetLogFilePath(string Key)
        {
            lock (this)
            {
                string DictoryPath = AppDomain.CurrentDomain.BaseDirectory + Setting.GetAppSettingByKey(Key);

                if (!Directory.Exists(DictoryPath))
                {
                    Directory.CreateDirectory(DictoryPath);
                }
                return DictoryPath + DateTime.Now.ToString("yyyyMMdd") + ".txt";
            }
        }
        #endregion

        #region 获取Access_Token
        /// <summary>
        /// 私有的AccessToken属性
        /// </summary>
        private static AccessTokenEntity AcccessTokenData = null;

        /// <summary>
        /// 当获取token发生错误时,记录Error信息
        /// </summary>
        public static WxErrorEntity ErrorObj = null;

        /// <summary>
        /// 用于判断获取Token是否发生了错误
        /// </summary>
        public static bool IsAccessTokenError = false;

        /// <summary>
        /// 获取token
        /// </summary>
        public static string Access_Token
        {
            get
            {
                if (IsAccessTokenError)
                {
                    //每求获取时，如果上一次状态发生了错误，则重置。
                    IsAccessTokenError = false;
                    ErrorObj = null;
                }
                
                if (null == AcccessTokenData)                               //如果当前属性值为null,则获取token
                {                    
                    GetTokenData();         //获取token
                }
                else
                {
                    long SpanTime = (DateTime.Now.Ticks - AcccessTokenData.LastGetTime.Ticks) / 10000000;   //计算过期时间
                    if (SpanTime >= AcccessTokenData.expires_in)            //如果已经超时
                    {
                        GetTokenData();     //获取token
                    }
                }

                return AcccessTokenData.access_token;
            }
        }

        /// <summary>
        /// 获取Token
        /// </summary>
        /// <param name="errorEntity">错误信息</param>
        /// <returns></returns>
        public static AccessTokenEntity GetTokenData()
        {
            //请求路径
            string RequestUrl = string.Format("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}",Setting.AppId,Setting.AppSecret);

            AcccessTokenData = new AccessTokenEntity();  //设置当前静态属性

            string JsonResult = GetJsonResult(RequestUrl);                  //获取请求返回结果

            if (IsErrorMessage(JsonResult)) //判断是否是错误信息返回
            {
                AcccessTokenData.errorObj = JsonConvert.DeserializeObject<WxErrorEntity>(JsonResult);  //如果是错误的消息
            }
            else
            {
                AcccessTokenData = JsonConvert.DeserializeObject<AccessTokenEntity>(JsonResult);       //正常的请求
            }

            AcccessTokenData.LastGetTime = DateTime.Now;                   //记录下获取的时间，如果下次获取时过期则重新获取，防止过度请求超出限制

            if (AcccessTokenData.errorObj != null)                         //如果错误属性不为空，则说明请求时发生错误
            {
                IsAccessTokenError = true;                          //更改状态
                ErrorObj = AcccessTokenData.errorObj;               //记录错误
            }

            return AcccessTokenData;
        }                
        #endregion

        #region 获取网页Ticket
        private static WebPageTicketEntity _WebPageTicket { get; set; }

        public static WebPageTicketEntity WebPageTicket
        {
            get
            {
                if( null == _WebPageTicket  )
                {
                    GetWebPageTicket();
                }
                else{
                    if( ( DateTime.Now.Ticks - _WebPageTicket.LastGetTime.Ticks ) / 10000000 >= _WebPageTicket.expires_in )
                    {
                        GetWebPageTicket();
                    }
                }

                return _WebPageTicket;
            }
        }

        private static void GetWebPageTicket()
        {
            string ResultJson = Common.GetJsonResult(
                string.Format( "" ),
                IsHttps: true
            );

            _WebPageTicket = JsonConvert.DeserializeObject<WebPageTicketEntity>( ResultJson );
        }
        #endregion

        #region 请求获取数据
        /// <summary>
        /// 请求指定Url
        /// </summary>
        /// <param name="url">请求的地址</param>
        /// <param name="Method">请求的方式</param>
        /// <param name="IsHttps">是否使用安全嵌套协议</param>
        /// <param name="PostData">POST请求时的参数列表,格式:"A=1&B=2&C=3"</param>
        /// <returns>经过处理的字符串,主要针对错误消息处理</returns>
        public static string GetJsonResult(string url, string Method = "GET", string PostData = "", bool IsHttps = false)
        {
            HttpWebRequest wr = System.Net.WebRequest.Create(url) as HttpWebRequest;

            //配置请求信息
            wr.Method = Method;
            wr.Accept = "text/html,application/xhtml+xml,applicatoin/xml,application/json;q=0.9,*/*;q=0.8";
            wr.Timeout = Setting.RequestTimeout; //请求超过10s，则断开请求

            //如果是https请求
            if (IsHttps)
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
            }

            //POST请求
            if (string.Compare(Method, "POST", true) == 0)
            {
                byte[] postData     = System.Text.Encoding.UTF8.GetBytes(PostData);     //http报文主体内容
                wr.Method           = "POST";                                           //post请求
                wr.ContentType      = "application/x-www-form-urlencoded";              //提交方式
                wr.ContentLength    = postData.Length;                                  //请求体内容长度

                Stream wrStream = wr.GetRequestStream();
                wrStream.Write(postData, 0, postData.Length);                           //写入流中
                wrStream.Flush();
                wrStream.Close();
            }

            string ResultJson = string.Empty;

            //获取返回数据
            using (WebResponse WRes = wr.GetResponse() as WebResponse)
            {
                try
                {
                    StreamReader sr = new StreamReader(WRes.GetResponseStream());           //获取响应流中的数据

                    ResultJson = sr.ReadToEnd();
                }
                catch (Exception Ex)
                {
                    //异常处理
                    LogHelper LogObj = new LogHelper();
                    LogObj.SaveErrorLog(Ex, "ErrorLog");
                    return WxReturnJsonHelper.JsonDeal("", Ex);
                }
            }

            LogHelper logObj = new LogHelper();
            logObj.SaveInfo(
                string.Format("\r\n-----------------\r\n RequestUrl:{0}\r\n Method:{1}\r\n Accept:{2}\r\n PostData:{3} \r\n Response: {4}\r\n",
                wr.RequestUri.AbsoluteUri,
                wr.Method,
                wr.Accept,
                PostData,
                ResultJson
                ),
                "RequestLog"
            );

            return WxReturnJsonHelper.JsonDeal(ResultJson);

        }

        /// <summary>
        /// 使用SSL请求时必须使用的检查证书的方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="certificate"></param>
        /// <param name="chain"></param>
        /// <param name="errors"></param>
        public static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain,
            SslPolicyErrors errors)
        {
            return true;
        }
        #endregion

        #region 错误消息检测
        /// <summary>
        /// 错误消息检测
        /// </summary>
        /// <param name="jsonResult">待检测的串</param>
        /// <returns>检测结果</returns>
        public static bool IsErrorMessage(string jsonResult)
        {
            return ( string.IsNullOrEmpty(jsonResult) || jsonResult.IndexOf("errcode") > -1 || jsonResult.IndexOf("errmsg") > -1 );
        }
        #endregion
    }
}