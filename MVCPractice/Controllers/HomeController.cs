using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPractice.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public string Index(int i, string name)
        {
            //string version = typeof(Controller).Assembly.GetName().Version.ToString();
            //return version;
            //return "Value of I is "+i+" The value of Name is "+name;
            string param1 = Request.QueryString["i"] == null ? string.Empty : Request.QueryString["i"].ToString();
            string param2 = Request.QueryString["name"] == null ? string.Empty : Request.QueryString["name"].ToString();
            return "Value of parma1 is " + param1 + " The value of param2 is " + param2;
        }

        public ActionResult ViewStateAndViewBag()
        {
            ViewBag.FirstName = "Nazeer Basha";
            ViewData["LastName"] = "Shaik";

            return View();
        }
    }
}
