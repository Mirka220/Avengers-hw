using Avengers_hw.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Avengers_hw.Filters;

namespace Avengers_hw.Controllers
{
    public class HomeController : Controller
    {

        private IHomeRepository repo;

        public HomeController(IHomeRepository r) 
        {
            repo = r;
        }

        [ActionFilter]
        [ExceptionFilter]
        [ActionName("MainPage")]
        public ActionResult Index()
        {
            return View();
        }

        [ExceptionFilter]
        public ActionResult One()
        {
            return View();
        }

        public ActionResult SeacrhAvenger()
        {
            repo.SeacrhAvenger();
            return View();
        }

        [Authorize(Roles = "admin", Users = "Kanaffin, Aidar")]
        public ActionResult SeacrhItem()
        {
            repo.SeacrhItem();
            return PartialView();
        }

        [HttpPost]
        public ActionResult Results(string fName)
        {
            var searching = repo.Results(fName);

            return PartialView(searching);
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult LinkResults()
        {

            ViewBag.Heroes = repo.LinkResults();

            return PartialView();
        }

        public JsonResult SendAsJson(string name)
        {
            var searching = repo.SendAsJson(name);

            return Json(searching, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult GetTable()
        {
            return View(repo.GetTable());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public string Context()
        {
            HttpContext.Response.Write("<h1>HELLO IT STEP</h1>");
            string browser = HttpContext.Request.Browser.Browser; 
            string ip = HttpContext.Request.UserHostAddress;

            HttpContext.Request.Cookies["Name"].Value = "Miroslav";

            string cookies = HttpContext.Request.Cookies["Name"].Value;

            return "<p> Browser: " + browser + "<br> IP:" + ip + "Cookie:" + cookies + "</p>";
        }

        [ActionName("Time")]
        public string VyvodVremeni()
        {
            return TimeStamp();
        }

        [NonAction]
        public string TimeStamp()
        {
            return "Время :" + DateTime.Now.ToString();
        }
    }
}