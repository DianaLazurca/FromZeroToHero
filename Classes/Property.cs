
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    class Property
    {
        private string name;
        private string description;
        protected string address;
        private int stars;
        private double distanceToCenter;
        private DateTime openingDate;
        private static string distanceMesurementUnit;
        private Room[] rooms;
        public bool hasIndoorPool;
        public bool hasFreeWiFi;

       public Property(string name, string description, string address, int stars, double distanceToCenter, DateTime openingDate, Room[] rooms)
        {
            Name = name;
            Description = description;
            Address = address;
            Stars = stars;
            DistanceToCenter = distanceToCenter;
            OpeningDate = openingDate;
            Rooms = rooms;
           
        }

       public Property()
       {

       }

       static Property()
       {
           distanceMesurementUnit = "Miles";
       }
       #region props
       public bool HasIndoorPool { get; set; }
       public bool HasFreeWiFi { get; set; }
       public Room[] Rooms { get; set; }

       public DateTime OpeningDate
       {
           get { return this.openingDate; }
           set
           {
               if (DateTime.Compare(value, new DateTime(1880, 1, 1)) < 0 || DateTime.Compare(value, DateTime.Now) > 0)
               {
                   Console.WriteLine(" Datetime invalid");
                   this.openingDate = DateTime.Now;
               }
               else
               {
                   this.openingDate = value;
               }
           }
       }


       public string Name
       {
           get { return this.name; }
           set
           {
               if (value.Length > 50)
               {
                   Console.WriteLine(" Hotel name to long");
                   this.name = "";
               }
               else
               {
                   this.name = value;
               }
           }
       }

       public double DistanceToCenter
       {
           get { return this.distanceToCenter; }
           set
           {
               if (value < 0 || value >= 100)
               {
                   Console.WriteLine(" distance to center negative or above 100 ");
                   this.distanceToCenter = 0d;
               }
               else
               {
                   this.distanceToCenter = value;
               }
           }
       }

       public int Stars
       {
           get { return this.stars; }
           set
           {
               if ( value < 0 || value > 5)
               {
                   Console.WriteLine(" Number of stars to big");
                   this.stars = 0;
               }
               else
               {
                   this.stars = value;
               }
           }
       }
       public string Address
       {
           get { return this.address; }
           set
           {
               if (value.Length > 100)
               {
                   Console.WriteLine(" Hotel adress too long");
                   this.address = "";
               }
               else
               {
                   this.address = value;
               }
           }
       }
       public string Description
       {
           get { return this.description; }
           set
           {
               if (value.Length > 500)
               {
                   Console.WriteLine(" Hotel description too big");
                   this.description = "";
               }
               else
               {
                   this.description = value;
               }
           }
       }
       #endregion

       public virtual  double CalculateRating()
       {
           return 2 * Stars;
       }

       public double GetDistance(string unit)
       {
           if (distanceMesurementUnit.Equals(unit))
           {
               return DistanceToCenter;
           }
           else
           {
               if (unit.Equals("KM"))
               {
                   return DistanceMeasurementConverter.ConvertMilesInKM(distanceToCenter);
               }
               else
                   if (unit.Equals("Miles"))
                   {
                       return DistanceMeasurementConverter.ConvertKmInMiles(distanceToCenter);
                   }
           }
           return 0d;
       }

       public void SetDistanceMeasurementUnit(string measurementUnit)
       {
           distanceMesurementUnit = measurementUnit;
       }

       public string GetDistanceMeasurementUnit()
       {
           return distanceMesurementUnit;
       }

        public void DisplayInfo()
        {
            Console.WriteLine("Display hotel : {0}" , Name);
            Console.WriteLine("Decription : {0} ", Description);
            Console.WriteLine("Address : {0}" , Address);
            Console.WriteLine("Distance to Center : {0} {1} " , DistanceToCenter, GetDistanceMeasurementUnit());
            Console.WriteLine("Opening date : {0}" , OpeningDate);
            Console.WriteLine("\n--------Displaying rooms -----------");
            for (int i = 0; i < Rooms.Length; i++)
            {
                Console.WriteLine("Display room  {0} of hotel ", (i + 1));
                Rooms[i].DisplayInfo();
            }
        }
    }
}
