using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;
using Common;
using TestWxProject.Units;
using Newtonsoft.Json;
using System.Web.Security;

namespace LTestWxProject.Controllers
{
    public class PhotoTestController : Controller
    {
        public ActionResult Index( string code ="", string state = "")
        {
            try
            {
                #region 获取WebPageAccessToken
                if( string.IsNullOrEmpty( code ) )
                {
                    //如果未能获取到code，转跳到错误页面，或者让用户重新进入。 
                    return RedirectToAction( "Index", "Error", new { Ex = new Exception( "非常抱歉，获取用户信息时发生异常，请重新进入此页面。" ) } );
                }

                if( string.IsNullOrEmpty( state ) )
                {
                    //如果获取不到参数，得不到项目ID
                    return RedirectToAction( "Index", "Error", new { Ex = new Exception( "非常抱歉，获取不到项目信息，无法获取数据，请联系我们进行处理，谢谢您的支持。" ) } );
                }
                #endregion

                //获取Token
                WebPageAccessTokenEntity TokenObj = WebPageHelper.GetWebPageAccessToken( code );

                #region 基本信息

                //获取用户基本信息
                WxWebPageUserEntity UserInfoObj = WxUserHelper.GetWebPageUserInfo( TokenObj.access_token, TokenObj.openid );

                ViewBag.NickName = UserInfoObj.nickname;
                ViewBag.UserOpenId = TokenObj.openid;      //用户ID
                #endregion


                return View();
            }
            catch( Exception Ex )
            {
                return View();
            }
        }

        public string GetWebSignature()
        {
            try
            {
                WebPageTicketEntity TicketObj = TestWxProject.Units.Common.WebPageTicket;

                JsonWebPageTicketEntity ReturnObj = new JsonWebPageTicketEntity();
                ReturnObj.noncestr = GetRandomStr();
                ReturnObj.timestamp = GetTimeStamp();
                ReturnObj.appid = Setting.AppId;

                string Url = Setting.ServicePhoneTest+"/phototest/index";
                string ToDecryStr = string.Format( "jsapi_ticket={0}&noncestr={1}&timestamp={2}&ur={3}", TicketObj.ticket, ReturnObj.noncestr, ReturnObj.timestamp, Url );
                
                //加密
                ReturnObj.signature = FormsAuthentication.HashPasswordForStoringInConfigFile( ToDecryStr, "SHA1" );

                return JsonConvert.SerializeObject( ReturnObj );               
            }
            catch( Exception Ex )
            {
                return string.Empty;
            }
        }

        private string GetRandomStr()
        {
            Random r = new Random( (int)DateTime.Now.Ticks%1000000 );
            return r.Next(111111, 1111111111).ToString();
        }

        /// <summary>
        /// 返回从1970年1月1日0时0分0秒到现在的毫秒数
        /// </summary>
        /// <returns></returns>
        private string GetTimeStamp()
        {
            DateTime S = new DateTime( 1970, 1, 1, 0, 0, 0 );
            return ( ( DateTime.Now.Ticks - S.Ticks ) / 10000 ).ToString();
        }
    }
}
