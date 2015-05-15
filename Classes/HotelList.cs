using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class HotelList
    {
        private List<Hotel> hotels;

        public HotelList()
        {
            hotels = new List<Hotel>();
        }

        public List<Hotel> Hotels { get; set; }

    }
}
