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
        public ViewResult Index()
        {
        

            return View(HotelList.Hotels);
        }
        
        public ActionResult Detail(int id)
        {
            /*var hotel = hotels.Hotels.FirstOrDefault(x => x.Id == id);

            if (hotel != null)
            {
                return Json(hotel, JsonRequestBehavior.AllowGet);
            }*/
            return HttpNotFound();

        }

     
	}
}