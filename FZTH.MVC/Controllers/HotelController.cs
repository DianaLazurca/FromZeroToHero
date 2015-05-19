using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FZTH.MVC.Models;

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
            }
            catch
            {
                return View();
            }

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