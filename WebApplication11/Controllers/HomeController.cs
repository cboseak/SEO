using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace WebApplication11.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Spin()
        {
            if (Request.QueryString["text"] != null)
            {
                if (Request.QueryString["method"] != null)
                {
                    switch (Request.QueryString["method"])
                    {
                        case "Spinner":
                            return Content(Library.Spinner.SpinText(Request.QueryString["text"]));
                        case "Spun":
                            return Content(Library.Spinner.GetSpunText(Request.QueryString["text"]));
                        case "Light":
                            return Content(Library.Spinner.GetLightSpunText(Request.QueryString["text"]));
                    }
                }
                
                return Content(Library.Spinner.SpinText(Request.QueryString["text"]));
            }

            return Content("");
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
    }
}