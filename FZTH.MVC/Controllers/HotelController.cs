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
                // avem hotel de tip Models.Hotel, ar trebui sa-l transformam in hotel de tip Entity

                Entities.Hotel entityHotel = ClassConverter.FromModelHotelToEntityHotel(hotel);
                DBManager dbManager = new DBManager(NHibernateHelper.OpenSession());
               Entities.Hotel h =  dbManager.AddNewHotel(entityHotel);
               /* int newID = 0;
                foreach(Hotel h in HotelList.Hotels) {
                    if (h.Id > newID)
                    {
                        newID = h.Id;
                    }
                }

                hotel.Id = newID + 1;
                hotel.Rooms = new Room[2];
                HotelList.Hotels.Add(hotel);*/
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
                DBManager dbManager = new DBManager(NHibernateHelper.OpenSession());
                dbManager.DeleteHotel(id);
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
                allHotelsToBeSent.Add(ClassConverter.FromEntityHotelToModelHotel(hotelEntity));
            }

            return Json(allHotelsToBeSent, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Edit(int id)
        {
            DBManager dbManager = new DBManager(NHibernateHelper.OpenSession());
            Entities.Hotel newHotel = dbManager.GetHotelById(id);
            if (newHotel != null)
            {
                return View(ClassConverter.FromEntityHotelToModelHotel(newHotel));
            }
            return new HttpStatusCodeResult(404);
        }
        [HttpPost]
        public ActionResult Edit(Hotel hotel)
        {

            if (ModelState.IsValid)
            {
                DBManager dbManager = new DBManager(NHibernateHelper.OpenSession());
                Entities.Hotel entityHotel = ClassConverter.FromModelHotelToEntityHotel(hotel);
                dbManager.EditHotel(entityHotel);

                //foreach (Hotel h in HotelList.Hotels)
                //{
                //    if (h.Id == hotel.Id)
                //    {
                //        h.Name = hotel.Name;
                //        h.Description = hotel.Description;
                //        h.Stars = hotel.Stars;
                //        h.OpeningDate = hotel.OpeningDate;
                //        h.DistanceToCenter = hotel.DistanceToCenter;
                //        h.City.Name = hotel.City.Name;
                //        h.City.County.Name = hotel.City.County.Name;
                //        h.RoomNr = hotel.RoomNr;
                //        h.Rooms = new Room[hotel.RoomNr];
                //    }
                //}
                //Response.StatusCode = 200;
                //return Json(hotel);
               return RedirectToAction("Index");
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