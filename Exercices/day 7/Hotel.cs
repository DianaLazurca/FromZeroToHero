using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercices.day_7
{
    sealed class Hotel : Property
    {
        public int Likes { get; set; }
        public Hotel(string name, string description, string address, int stars, double distanceToCenter, DateTime openingDate, Room[] rooms, int likes) 
            :base(name,description,address, stars,distanceToCenter,openingDate,rooms) {
                Likes = likes;
        }

        public void ChangeHotelAddress(string newAddress)
        {
            address = newAddress;
        }

        public override double CalculateRating()
        {
            double stars2 = base.CalculateRating() * 0.7d;
            if (Likes > 10000)
            {
                Likes = 10;
            }
            return (Convert.ToDouble(Likes) / 1000d) * 0.3d + stars2;
        }
    }
}
