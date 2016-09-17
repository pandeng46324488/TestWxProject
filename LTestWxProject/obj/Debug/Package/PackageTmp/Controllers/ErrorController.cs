using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestWxProject.Controllers
{
    public class ErrorController : Controller
    {
        //
        // GET: /Error/

        public ActionResult Index( Exception  Ex )
        {

            return View(Ex);
        }

        public ActionResult ServerWithEx( Exception Ex)
        {
            return View();
        }

    }
}
