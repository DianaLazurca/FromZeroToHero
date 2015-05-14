using Exercices.day_7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercices
{
    class Program
    {
        static void Main(string[] args)
        {
            Room room1 = new Room("room1", 1, 12, 2, RoomTypes.Single);
            Room room2 = new Room("room2", 2, 14, 4, RoomTypes.Double);

            Room[] rooms = new Room[2] {room1, room2};

            Property hotel = new Property("My Property", "desc hotel", "My address", 3, 30, DateTime.Now, rooms);
          

            Property newHotel = new Property() 
            {
            
              Name = "Hotel2",
              Description = "description",
              Address = "some address",
              Stars = 2,
              DistanceToCenter = 30,
              OpeningDate = DateTime.Now,
              Rooms = rooms
            };
            
            
            Console.WriteLine(" ------ From miles to km {0} ------ \n ", newHotel.GetDistance("KM"));
            newHotel.SetDistanceMeasurementUnit("KM");
            
            Console.WriteLine(" ------ New measurement unit {0} ------ \n ", newHotel.GetDistanceMeasurementUnit());
            Console.WriteLine(" ------ From km to miles {0} ------ \n ", newHotel.GetDistance("KM"));
           // hotel.DisplayInfo();
            Console.WriteLine(" -    - - - - - - - - - - - - - - - - - \n");
          // newHotel.DisplayInfo();
           

            GuestHouse gh1 = new GuestHouse("Guest House 1", "desc hotel", "My address", 3, 30, DateTime.Now, rooms, 3);
            GuestHouse gh2 = new GuestHouse("GuestHouse 2", "desc hotel", "My address", 3, 30, DateTime.Now, rooms, 3);

            Hotel hotelClass = new Hotel("Hoooteeel", "desc hotel", "My address", 3, 30, DateTime.Now, rooms,5);
            hotelClass.ChangeHotelAddress("This is the new Address");
            hotelClass.DisplayInfo();

            //gh1.DisplayInfo();
            //gh2.DisplayInfo();

          //  Console.ReadLine();

          /*  Hotel hotel = new Hotel();
            hotel.description = "desc";
            hotel.address = "Address";
            hotel.name = "Hotel name";
            hotel.openingDate =  DateTime.Now;
            hotel.stars = 3;

            Room room = new Room();
            room.description = "room1";
            room.floor = 2;
            room.number = 2;
            room.type = RoomTypes.Single;
            room.places = 1;

            Room room1 = new Room();
            room1.description = "room2";
            room1.floor = 2;
            room1.number = 4;
            room1.type = RoomTypes.Double;
            room1.places = 2;
            hotel.rooms =new Room[2] {room, room1};*/

           /* Console.WriteLine("Name = " + hotel.name);
            Console.WriteLine("Address = " + hotel.address);
            Console.WriteLine("Opening Year = " + (hotel.openingDate).Year);
            Console.WriteLine("Number of rooms = " + (hotel.rooms).Length);*/
            
        }
    }
}
