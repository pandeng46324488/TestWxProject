using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestWxProject.Units;
using Entity;

namespace TestWxProject.Controllers
{
    public class FanUserController : Controller
    {
        /// <summary>
        /// 用户列表
        /// </summary>
        /// <returns></returns>
        public ActionResult UserList( int page = 1)
        {
            WxUserEntity DataObj = WxHelper.GetWxUserList();
            
            return View(DataObj);
        }

    }
}
