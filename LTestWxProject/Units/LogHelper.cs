using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Threading;
using System.Runtime.Remoting.Messaging;

namespace TestWxProject.Units
{
    /// <summary>
    /// 日志帮助类
    /// </summary>
    public class LogHelper
    {
        #region 错误日志记录
        /// <summary>
        /// 错误日志记录
        /// </summary>
        /// <param name="Content">记录内容</param>
        /// <param name="webConfigKey">配置文件中的Key</param>
        /// <returns></returns>
        public bool SaveErrorLog( string Content, string webConfigKey = "ErrorLog" )
        {
            try
            {
                if (string.Compare("ErrorLog", webConfigKey) == 0 && !Setting.ErrorEnable)
                {
                    return true;
                }

                DG_AsnycWriteLog DG = new DG_AsnycWriteLog(AsyncWriteLog);
                DG.BeginInvoke(Content, webConfigKey, new AsyncCallback(AsyncWriteLogCallBack), DG);                
                return true;
            }
            catch( Exception Ex )
            {
                return false;
            }
        }

        /// <summary>
        /// 错误日志记录
        /// </summary>
        /// <param name="Ex">异常</param>
        /// <param name="webConfigKey">配置文件中的Key</param>
        /// <returns></returns>
        public bool SaveErrorLog( Exception Ex, string webConfigKey = "ErrorLog" )
        {
            try
            {
                if (string.Compare("ErrorLog", webConfigKey) == 0 && !Setting.ErrorEnable)
                {
                    return true;
                }

                if (string.Compare("RequestLog", webConfigKey) == 0 && !Setting.RequestEnable)
                {
                    return true;
                }

                if (string.Compare("ValidateWxLog", webConfigKey) == 0 && !Setting.ValidateEnable)
                {
                    return true;
                }

                DG_AsnycWriteLog DG = new DG_AsnycWriteLog(AsyncWriteLog);
                DG.BeginInvoke(string.Format( "{0}\r\nDateTime: {1} \r\n---- ErrorInfo: {2} \r\n",
                       "---------------------------------------\r\n",
                       DateTime.Now.ToString( "yyyy-MM-dd HH:mm:ss" ),
                       Ex.Message ), 
                       webConfigKey, 
                       new AsyncCallback(AsyncWriteLogCallBack), 
                 DG);

                return true;
            }
            catch( Exception ex )
            {
                return false;
            }
        }
        #endregion

        #region 信息记录
        /// <summary>
        /// 记录信息
        /// </summary>
        /// <param name="Content">记录的内容</param>
        /// <param name="webConfigKey">配置文件中的Key</param>
        /// <returns></returns>
        public void SaveInfo( string Content, string webConfigKey = "ValidateWxLog" )
        {
            try
            {
                if (string.Compare("ErrorLog", webConfigKey) == 0 && !Setting.ErrorEnable)
                {
                    return;
                }

                if (string.Compare("RequestLog", webConfigKey) == 0 && !Setting.RequestEnable)
                {
                    return;
                }

                if (string.Compare("ValidateWxLog", webConfigKey) == 0 && !Setting.ValidateEnable)
                {
                    return;
                }

                DG_AsnycWriteLog DG = new DG_AsnycWriteLog(AsyncWriteLog);
                DG.BeginInvoke(Content, webConfigKey, new AsyncCallback(AsyncWriteLogCallBack), DG);
            }
            catch( Exception Ex )
            {

            }
        }

        #region 异步写日志
        /// <summary>
        /// 异步写日志委托
        /// </summary>
        /// <param name="Content"></param>
        /// <param name="webConfigKey"></param>
        delegate void DG_AsnycWriteLog(string Content, string webConfigKey);

        /// <summary>
        /// 异步写日志
        /// </summary>
        /// <param name="Content"></param>
        /// <param name="webConfigKey"></param>
        public void AsyncWriteLog(string Content, string webConfigKey)
        {
            lock (this)
            {
                Common ComObj = new Common();

                string filePath = ComObj.GetLogFilePath(webConfigKey);

                System.IO.File.AppendAllText(ComObj.GetLogFilePath(webConfigKey), Content);
            }
        }

        /// <summary>
        /// 异步写日志回调
        /// </summary>
        /// <param name="ar"></param>
        public void AsyncWriteLogCallBack( IAsyncResult ar )
        {
            AsyncResult AC = (AsyncResult)ar;
            DG_AsnycWriteLog DGObj = (DG_AsnycWriteLog)AC.AsyncDelegate;
            DGObj.EndInvoke(ar);
        }
        #endregion

        #endregion

    }
}