using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;
using TestWxProject.Units;

namespace TestWxProject.Controllers
{
    public class MenuController : Controller
    {
        //
        // GET: /Menu/

        public ActionResult QueryMenu()
        {
            WxNoPersonalButtonEntity ObjData = MenuHelper.GetButtonList();
            return View(ObjData);
        }

        public ActionResult CreateButton()
        {
            string ButtonStr = "{\"button\":[{\"type\":\"view\",\"name\":\"微投票链接\",\"url\":\"https://open.weixin.qq.com/connect/oauth2/authorize?appid=" + Setting.AppId + "&redirect_uri=" + Url.Encode( Setting.ServiceAddress + "Vote/VoteDetails" ) + "&response_type=code&scope=snsapi_userinfo&state=6#wechat_redirect\"},{\"type\":\"view\",\"name\":\"上传图片\",\"url\":\"https://open.weixin.qq.com/connect/oauth2/authorize?appid=" + Setting.AppId + "&&redirect_uri="+Url.Encode(Setting.ServicePhoneTest+"PhotoTest/Index")+"&response_type=code&scope=snsapi_userinfo&state=6#wechat_redirect\"}]}";

            ViewBag.Status = false;
            if (MenuHelper.CreateButton(ButtonStr))
            {
                ViewBag.Status = true;
            }

            return View();
        }
    }
}
