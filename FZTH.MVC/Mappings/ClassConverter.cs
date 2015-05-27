using FZTH.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FZTH.MVC.Mappings
{
    public static class ClassConverter
    {
        public static Hotel ConvertToHotel(Entities.Hotel hotel)
        {
            Hotel newHotel = new Hotel
            {
                Id = hotel.Id,
                Name = hotel.Name,
                Description = "Hotel x",
                Address = "Adsress",
                City = new City
                {
                    Name = hotel.Location.City,
                    County = new County{ Name = hotel.Location.County}
                },
               DistanceToCenter = 20,
               OpeningDate = DateTime.Now,
               RoomNr = 3,
               Stars = 2

            };

            return newHotel;
        }
    }
}