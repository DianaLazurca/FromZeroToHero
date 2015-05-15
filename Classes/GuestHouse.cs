using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    class GuestHouse : Property
    {
        public int ComfortIndex { get; set; }

        public GuestHouse(string name, string description, string address, int stars, double distanceToCenter, DateTime openingDate, Room[] rooms,int comfortIndex) 
            :base(name,description,address, stars,distanceToCenter,openingDate,rooms) {
                ComfortIndex = comfortIndex;
        }

        public override double CalculateRating()
        {
            double stars2 = base.CalculateRating() * 0.4d;

            return (Convert.ToDouble(ComfortIndex) * 0.6d)+ stars2;
        }
    }
}
