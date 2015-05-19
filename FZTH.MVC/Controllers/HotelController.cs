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

        public ActionResult Create()
        {
            
            return View();
        }
        
        public ActionResult Delete(int id)
        {
           
            var hotel = HotelList.Hotels.FirstOrDefault(x => x.Id == id);
            return View(hotel);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var hotel = HotelList.Hotels.FirstOrDefault(x => x.Id == id);
                HotelList.Hotels.Remove(hotel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }
        public ActionResult Edit(int id)
        {
            var hotel = HotelList.Hotels.FirstOrDefault(x => x.Id == id);
           
            return View(hotel);
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