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
        private HotelList hotelList = new HotelList(); 
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
            Room room1 = new Room("room1", 1, 12, 2, RoomTypes.Single);
            Room room2 = new Room("room2", 2, 14, 4, RoomTypes.Double);

            Room[] rooms = new Room[2] { room1, room2 };
            Hotel hotelClass = new Hotel("Hoooteeel", "desc hotel", "My address", 3, 30, DateTime.Now, rooms,5);
            
            return Content("Here will be the list of hotels");
        }


	}
}