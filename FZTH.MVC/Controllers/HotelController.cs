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
        private HotelList hotels = new HotelList(); 
        //
        // GET: /Hotel/
        [HttpGet]
        public ActionResult Index()
        {
            Room room1 = new Room("room1", 1, 12, 2, RoomTypes.Single);
            Room room2 = new Room("room2", 2, 14, 4, RoomTypes.Double);

            Room[] rooms = new Room[2] { room1, room2 };
            Hotel hotelClass = new Hotel(1, "Hoooteeel", "desc hotel", "My address", 3, 30, DateTime.Now, rooms, 5);
            Hotel hotelClass1 = new Hotel(2, "Hoooteeel1", "desc hotel", "My address", 1, 30, DateTime.Now, rooms, 5);

            hotels.Hotels.Add(hotelClass);
            hotels.Hotels.Add(hotelClass1);

            ViewBag.MyList = hotels.Hotels;
            

            return View("Index");
        }
        
        public ActionResult Detail(int id)
        {
            var hotel = hotels.Hotels.FirstOrDefault(x => x.Id == id);

            if (hotel != null)
            {
                return Json(hotel, JsonRequestBehavior.AllowGet);
            }
            return HttpNotFound();

        }

     
	}
}