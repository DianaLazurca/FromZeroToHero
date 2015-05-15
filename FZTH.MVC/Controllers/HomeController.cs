using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FZTH.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

    //[AcceptVerbs(HttpVerbs.Get)]
        [HttpGet]
        public string Hello(Person person)
        {
            return person.ToString();

        }

       public  class Person
        {
            public int Age { get; set; }
            public string Name  { get; set; }

            public override string ToString()
            {
                return String.Format("Hello {0} of age {1}", Name, Age );
            }
        }
    }

}