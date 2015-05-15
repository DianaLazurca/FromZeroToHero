using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Classes;

namespace FZTH.MVC.Controllers
{
    public class HotelController : Controller
    {
        //
        // GET: /Hotel/
        [HttpGet]
        public ActionResult Index()
        {
            
            return Content("Here will be the list of hotels");
        }
        [HttpGet]
        public ActionResult Detail(int id)
        {
            Hotel hotel = new Hotel();
            Property p = new Property()
            return Content("Here will be the list of hotels");
        }


	}
}