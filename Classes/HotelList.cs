using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public  static class HotelList
    {
        public static List<Hotel> hotels = new List<Hotel>();

        static HotelList()
        {
            Room room1 = new Room("room1", 1, 12, 2, RoomTypes.Single);
            Room room2 = new Room("room2", 2, 14, 4, RoomTypes.Double);

            Room[] rooms = new Room[2] { room1, room2 };
            Hotel hotelClass = new Hotel(1, "Hoooteeel", "desc hotel1", "My address", 3, 30, DateTime.Now, rooms, 5);
            Hotel hotelClass1 = new Hotel(2, "Hoooteeel1", "desc hotel2", "My address", 1, 30, DateTime.Now, rooms, 5);

            Hotel hotelClass2 = new Hotel(4, "Hoooteeel2", "desc hotel3", "My address", 1, 30, DateTime.Now, rooms, 5);

            hotels.Add(hotelClass);
            hotels.Add(hotelClass1);
            hotels.Add(hotelClass2); 
        }
        public static  List<Hotel> Hotels 
        {
            
            get { 
                
                return hotels;
            }
            set { hotels = value; }
           
        }

    }
}
