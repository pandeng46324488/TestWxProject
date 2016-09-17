using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.XPath;
using System.Xml;

namespace TestWxProject.Units
{
    /// <summary>
    /// 消息帮助类
    /// </summary>
    public class MessageHelper
    {
        #region 发送消息

        #region 发送消息-被动回复
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string PassiveReply( string XML)
        {
            try
            {
                XmlDocument XDocObj = new XmlDocument();
                XDocObj.LoadXml(XML);

                XmlNode RootObj = XDocObj.ChildNodes[0];

                XmlNodeList SubNodeList = RootObj.ChildNodes;

                string FromName = string.Empty, ToName = string.Empty, FContent = string.Empty;

                foreach (XmlNode item in SubNodeList)
                {
                    if (item.Name.Equals("ToUserName"))
                    {
                        ToName = item.InnerText;
                    }

                    if (item.Name.Equals("FromUserName"))
                    {
                        FromName = item.InnerText;
                    }

                    if (item.Name.Equals("Content"))
                    {
                        FContent = item.InnerText;
                    }
                }

                if (FContent.Equals("微投票链接"))
                {
                    FContent = string.Format("<a href='{0}'>{1}</a>,直接给出链接：{2}", Setting.ServiceAddress, "微投票链接",Setting.ServiceAddress);
                }

                DateTime StartTime = new DateTime(1970,1,1,0,0,0);
                
                return string.Format("<xml><ToUserName><![CDATA[{0}]]></ToUserName><FromUserName><![CDATA[{1}]]></FromUserName><CreateTime>{2}</CreateTime><MsgType><![CDATA[text]]></MsgType><Content><![CDATA[你输入的信息是：{3}]]></Content></xml>", FromName, ToName, (DateTime.Now.Ticks - StartTime.Ticks) / 10000000, FContent);
                
            }
            catch (Exception Ex)
            {
                return "";
            }
        }
        #endregion

        #region 解析XML
        #endregion
        #endregion
    }
}