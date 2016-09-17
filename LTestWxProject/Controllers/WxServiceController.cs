using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;
using TestWxProject.Units;

namespace TestWxProject.Controllers
{
    public class WxServiceController : Controller
    {
        //
        // GET: /WxService/

        public ActionResult Index()
        {
            return View();
        }

        #region 获取微信服务器IP列表
        public ActionResult GetWxIpList()
        {
            IPAddressEntity IpList = WxHelper.GetServiceIpAddress();

            return View(IpList);
        }
        #endregion

    }
}
