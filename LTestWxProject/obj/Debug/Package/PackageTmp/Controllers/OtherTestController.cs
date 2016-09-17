//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using TestWxProject.Units;
//using Entity;
//using System.Net;
//using System.IO;
//using System.Data;
//using Entity;

//namespace TestWxProject.Controllers
//{
//    public class OtherTestController : Controller
//    {
//        //
//        // GET: /OtherTest/

//        public ActionResult Index()
//        {
//            return View();
//        }
//        #region Post处理
//        [ValidateInput(false)]        
//        public string PostRrequestTest()
//        {
//            //string Paras = Request.Form["Paras"];
//            //string ParasA = Request.Form["ParasA"];
//            //return string.Format("I have receive the parameters:{0},{1}", Paras, ParasA);

//            Stream s = Request.GetBufferedInputStream();
//            StreamReader Sr = new StreamReader(s, System.Text.Encoding.UTF8);
//            string Buffer = Sr.ReadToEnd();
//            return string.Format("请求文件类型：{0}，内容：{1}",Request.ContentType,Buffer);
//            //return string.Format("Form:{0}------------<br/>{1}", Request.GetBufferedInputStream);
//        }
//        #endregion

//        #region Post请求
//        public ActionResult CreatePostRequest()
//        {
//            return View();
//        }

//        [HttpPost]
//        public ActionResult CreatePostRequest(string ParasA)
//        {
//            HttpWebRequest webReq = (HttpWebRequest)HttpWebRequest.Create(new Uri("http://peter.TestWxProject.com/Validate/ValidateToken"));


//            string formStr = string.Format("<xml><ToUserName><![CDATA[toUser]]></ToUserName><FromUserName><![CDATA[fromUser]]></FromUserName><CreateTime>1348831860</CreateTime><MsgType><![CDATA[text]]></MsgType><Content><![CDATA[{0}]]></Content><MsgId>1234567890123456</MsgId></xml>",ParasA);

//            webReq.Method = "POST";
//            webReq.KeepAlive = false;
//            webReq.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
//            webReq.ContentType = MIMETypeEnum.XML_TYPE;// "application/x-www-form-urlencoded";

//            byte[] postData = System.Text.Encoding.UTF8.GetBytes(formStr);
//            webReq.ContentLength = postData.Length;

//            Stream reqStream = webReq.GetRequestStream();
//            reqStream.Write(postData, 0, postData.Length);
//            //reqStream.Flush();
//            reqStream.Close();
//            string result = "无数据";
//            using (HttpWebResponse webRes = webReq.GetResponse() as HttpWebResponse)
//            {
//                Stream responseStream = webRes.GetResponseStream();
//                StreamReader sr = new StreamReader(responseStream, System.Text.Encoding.UTF8);
//                result = sr.ReadToEnd();
//            }

//            return RedirectToAction("ShowResult", new { resultStr = result });
//        }

//        [ValidateInput(false)]
//        public ActionResult ShowResult(string resultStr)
//        {
//            ViewBag.ResultStr = resultStr;
//            return View();
//        }
//        #endregion

//        #region 测试获取Ef对象
//        public ActionResult TestEF()
//        {
//            try
//            {
//                BLL.VoteInfoBLL bllObje = new VoteInfoBLL();
//                WeChat_VoteInfoEntity A = bllObje.FindById(6);
//                ViewData["A"] = A;
//                return View();
//            }
//            catch (Exception Ex)
//            {
//                ViewData["Ex"] = Ex;
//                return View();
//            }
//        }
//        #endregion
//    }
//}
