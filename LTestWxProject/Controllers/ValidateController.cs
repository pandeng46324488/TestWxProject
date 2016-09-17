using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestWxProject.Units;
using System.Web.Security;
using System.IO;
using System.Text;
using System.Collections.Specialized;

namespace TestWxProject.Controllers
{
    public class ValidateController : Controller
    {
        public string ValidateToken(string signature, string timestamp, string nonce, string echostr)
        {
            try
            {
                string SortStr = string.Format("{0}{1}{2}", timestamp, nonce, Setting.GetWxConfigToken);

                string LocalSignature = FormsAuthentication.HashPasswordForStoringInConfigFile(SortStr, "SHA1");
                LogHelper Log = new LogHelper();
                Log.SaveInfo( 
                    string.Format("{0}DateTime: {1}\r\n----  Paras:\r\n signature:{2}\r\n timestamp:{3}\r\n nonce:{4}\r\n echostr:{5}\r\n----LocalSignature:{6}\r\n\r\n",
                        "---------------------------------------\r\n",
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        signature, timestamp, nonce, echostr, LocalSignature),                   
                        "ValidateWxLog"
                );

                if (LocalSignature.ToLower().Equals(signature))
                {
                    return echostr;
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception Ex)
            {
                LogHelper LogObj = new LogHelper();
                LogObj.SaveErrorLog(Ex, "ErrorLog");
                return string.Empty;
            }
        }

        /// <summary>
        /// 接收消息-被动回复
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public string ValidateToken()
        {
            StringBuilder sb = new StringBuilder( 
                string.Format("\r\n---- Func[ValidateToken][DateTime:{0}]\r\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") )
                );

            StringBuilder ContentForm = new StringBuilder();
            string XMLStr = string.Empty;
            if(  string.Compare( Request.RequestType, "POST", true) == 0 )
            {
                Stream SM = Request.InputStream;
                StreamReader SR = new StreamReader(SM, System.Text.Encoding.UTF8);

                XMLStr = SR.ReadToEnd();
                ContentForm.AppendFormat("\r\n  --- FORM Content:{0}\r\n", XMLStr);

                for( int i=0; i<Request.Form.Count;i++)
                {
                    ContentForm.AppendFormat( "     \r\nIndex:{0},Value:{1}", i, Request.Form[i]);
                }
                ContentForm.Append("\r\n");
            }

            if (string.Compare(Request.RequestType, "GET", true) == 0)
            {
                for (int i = 0; i < Request.Params.Count; i++)
                {
                    ContentForm.AppendFormat("     \r\nIndex:{0},Value:{1}", i, Request.Form[i]);
                }
                ContentForm.Append("\r\n");
            }

            LogHelper LogObj = new LogHelper();
            LogObj.SaveInfo(
                string.Format("\r\n|==============|\r\nRequest.ContentType:{0},Request.ContentLength:{1},UserHostAddress{2},UserHostName:{3}\r\n    UserAgent:{4},Url:{5},RequestType:{6},Form.Count:{7},FormContent:{8}"
                ,
                Request.ContentType,
                Request.ContentLength,
                Request.UserHostAddress,
                Request.UserHostName,
                Request.UserAgent,
                Request.Url,
                Request.RequestType,
                Request.Form.Count,
                ContentForm
                ),
                "RequestLog"
            );

            return MessageHelper.PassiveReply(XMLStr);

            //return "success";

            //if (string.Compare(this.HttpContext.Request.ContentType, MIMETypeEnum.XML_TYPE, true) == 0)
            //{

            //    //Stream sObj = Request.GetBufferedInputStream();
            //    //StreamReader SrObj = new StreamReader(sObj, System.Text.Encoding.UTF8);
            //    //string Xml = SrObj.ReadToEnd();

            //    sb.AppendFormat(
            //            "|----------------------- XML --------------------|\r\n{0}|----------------------- XML --------------------|\r\n", XMLStr);

            //    LogObj.SaveInfo(sb.ToString());

            //    //如果返回了XML数据,进行记录
            //    return MessageHelper.PassiveReply(XMLStr);
            //};

            //if (string.Compare(this.HttpContext.Request.ContentType, MIMETypeEnum.HTML_FORM_TYPE, true) == 0)
            //{
            //    NameValueCollection valueKey = this.HttpContext.Request.Params;
            //    for (int i = 0; i < valueKey.Count; i++)
            //    {
            //        sb.AppendFormat("---- i:{0}, Value = {1} \r\n", i, valueKey[i]);
            //    }
            //    sb.Append("--------------END OF POST ---------------\r\n\r\n");

            //    LogObj.SaveInfo(sb.ToString());
            //    return "success";
            //}

            //return string.Empty;
        }
    }
}
