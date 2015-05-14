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
            Room room3 = new Room("room3", 4, 3, 3, RoomTypes.Single);

            Room[] rooms = new Room[3] {room1, room2, room3};

            Hotel hotel = new Hotel("My Hotel", "desc hotel", "My address", 3, 30, DateTime.Now, rooms);
          

            Hotel newHotel = new Hotel("Hotel2", "description", "some address", 5, 70, DateTime.Now, rooms);
            Console.WriteLine(" ------ From miles to km {0} ------ \n ", newHotel.GetDistance("KM"));
            newHotel.SetDistanceMeasurementUnit("KM");
            
            Console.WriteLine(" ------ New measurement unit {0} ------ \n ", newHotel.GetDistanceMeasurementUnit());
            Console.WriteLine(" ------ From km to miles {0} ------ \n ", newHotel.GetDistance("KM"));
            hotel.DisplayInfo();
            Console.WriteLine(" -    - - - - - - - - - - - - - - - - - \n");
            //newHotel.DisplayInfo();
            Console.ReadLine();

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
