using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FZTH.MVC.Models;
using FZTH.MVC.Repositories;
using FZTH.MVC.Mappings;

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

        [HttpPost]
        public ActionResult Create(Hotel hotel)
        {

            if (ModelState.IsValid)
            {
                int newID = 0;
                foreach(Hotel h in HotelList.Hotels) {
                    if (h.Id > newID)
                    {
                        newID = h.Id;
                    }
                }

                hotel.Id = newID + 1;
                hotel.Rooms = new Room[2];
                HotelList.Hotels.Add(hotel);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        
        
        public ActionResult Delete(int id)
        {
           
            var hotel = HotelList.Hotels.FirstOrDefault(x => x.Id == id);
            if (hotel == null)
            {
                return HttpNotFound();
            }
            return View(hotel);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var hotel = HotelList.Hotels.FirstOrDefault(x => x.Id == id);
                if (hotel == null)
                {
                    return HttpNotFound();
                }
                HotelList.Hotels.Remove(hotel);
                return RedirectToAction("Index");
               // return Json(HotelList.Hotels, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return View();
            }

        }
        [HttpGet]
        public JsonResult HotelsJS()
        {
            DBManager dbManager = new DBManager(NHibernateHelper.OpenSession());

            List<Entities.Hotel> allHotels = dbManager.GetAllHotels().ToList();
            List<Models.Hotel> allHotelsToBeSent = new List<Hotel>();

            foreach (Entities.Hotel hotelEntity in allHotels)
            {
                allHotelsToBeSent.Add(ClassConverter.ConvertToHotel(hotelEntity));
            }

            return Json(allHotelsToBeSent, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Edit(int id)
        {
            var hotel = HotelList.Hotels.FirstOrDefault(x => x.Id == id);
            if (hotel == null)
            {
                return HttpNotFound();
            }
            return View(hotel);
        }
        [HttpPost]
        public ActionResult Edit(Hotel hotel)
        {

            if (ModelState.IsValid)
            {
                foreach (Hotel h in HotelList.Hotels)
                {
                    if (h.Id == hotel.Id)
                    {
                        h.Name = hotel.Name;
                        h.Description = hotel.Description;
                        h.Stars = hotel.Stars;
                        h.OpeningDate = hotel.OpeningDate;
                        h.DistanceToCenter = hotel.DistanceToCenter;
                        h.City.Name = hotel.City.Name;
                        h.City.County.Name = hotel.City.County.Name;
                        h.RoomNr = hotel.RoomNr;
                        h.Rooms = new Room[hotel.RoomNr];
                    }
                }
                Response.StatusCode = 200;
                return Json(hotel);

            }
            else
            {
                return HttpNotFound();
            }
            
        }

        [HttpPost]
        public ActionResult EditHotel(Hotel hotel)
        {

            if (ModelState.IsValid)
            {
                foreach (Hotel h in HotelList.Hotels)
                {
                    if (h.Id == hotel.Id)
                    {
                        h.Name = hotel.Name;
                        h.Description = hotel.Description;
                        h.Stars = hotel.Stars;
                        h.OpeningDate = hotel.OpeningDate;
                        h.DistanceToCenter = hotel.DistanceToCenter;
                        h.City.Name = hotel.City.Name;
                        h.City.County.Name = hotel.City.County.Name;
                        h.RoomNr = hotel.RoomNr;
                        h.Rooms = new Room[hotel.RoomNr];
                    }
                }
                return RedirectToAction("Index");

            }
            else
            {
                return View();
            }

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