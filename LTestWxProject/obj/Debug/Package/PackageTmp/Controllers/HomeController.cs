using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestWxProject.Units;
using Entity;
using System.Text;

namespace TestWxProject.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// 导航页
        /// </summary>
        /// <param name="code">code作为换取access_token的票据，每次用户授权带上的code将不一样，code只能使用一次，5分钟未被使用自动过期。</param>
        /// <param name="state">写回调url时传入的参数</param>
        /// <returns></returns>
        public ActionResult Index( string code = "", string state = "")
        {
            try
            {

                ViewBag.Status = true;

                WebPageAccessTokenEntity PageAccessToken = WebPageHelper.GetWebPageAccessToken(code);

                #region 获取WebPageAccessToken
                if (string.IsNullOrEmpty(code))
                {
                    //如果未能获取到code，转跳到错误页面，或者让用户重新进入。 
                    //return RedirectToAction("Index", "Error", new { Ex = new Exception("非常抱歉，获取用户信息时发生异常，请重新进入此页面。") });
                    ViewBag.UserStatus = false;
                    ViewBag.Errors = new WxErrorEntity(-1, "未能获取到code");
                    return View();
                }

                if (string.IsNullOrEmpty(state))
                {
                    //如果获取不到参数，得不到项目ID
                    //return RedirectToAction("Index", "Error", new {Ex = new Exception("非常抱歉，获取不到项目信息，无法获取数据，请联系我们进行处理，谢谢您的支持。") });
                    ViewBag.UserStatus = false;
                    ViewBag.Errors = new WxErrorEntity(-1, "获取不到参数，得不到项目ID");
                    return View();
                }
                #endregion


                //获取用户基本信息
                WxWebPageUserEntity UserInfoObj = WxUserHelper.GetWebPageUserInfo(PageAccessToken.access_token, PageAccessToken.openid);

                ViewBag.UserStatus = true;
                if (UserInfoObj.errorObj != null) //获取用户信息失败
                {
                    ViewBag.UserStatus = false;
                    ViewBag.Errors = UserInfoObj.errorObj;
                    UserInfoObj = null;
                }

                ViewData["UserInfoObj"] = UserInfoObj;

                LogHelper LogObj = new LogHelper();
                //日志记录信息
                if (PageAccessToken != null)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendFormat("\r\n|--------- 获取授权用户信息 access_token ------------|\r\n DateTime:{0}   openid:{1}, accesstoken:{2}\r\n",
                            PageAccessToken.last_get_time.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                            PageAccessToken.openid,
                            PageAccessToken.access_token
                    );

                    if (UserInfoObj != null)
                    {
                        sb.AppendFormat(
                            "-----------------------------\r\n   基本信息如下： nickname:{0}, headimgurl:{1}",
                            UserInfoObj.nickname,
                            UserInfoObj.headimgurl
                        );
                    }
                    else
                    {
                        if (UserInfoObj.errorObj != null)
                        {
                            sb.AppendFormat("无法获取到基本信息，发生错误，信息如下--- code:{0} || msg:{1}\r\n", UserInfoObj.errorObj.errcode, UserInfoObj.errorObj.errmsg);
                        }
                    }

                    sb.Append("|-------------------------|\r\n");

                    LogObj.SaveInfo(
                        sb.ToString(),
                        "OtherLog"
                     );
                }

                return View(PageAccessToken);
            }
            catch (Exception Ex)
            {
                ViewBag.UserStatus = false;
                ViewBag.Errors = new WxErrorEntity( -1, Ex.Message);
                return View( new WebPageAccessTokenEntity());
            }
        }
    }
}
