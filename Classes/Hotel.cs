using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.ComponentModel;

namespace Classes
{
     public class Hotel
    {
        public int Likes { get; set; }
      
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
        protected int id;

        public Hotel()
        {

        }

        public Hotel(int id, string name, string description, string address, int stars, double distanceToCenter, DateTime openingDate, Room[] rooms, int likes) 
        {
                Likes = likes;
                Id = id;
                Name = name;
                Description = description;
                Address = address;
                Stars = stars;
                DistanceToCenter = distanceToCenter;
                OpeningDate = openingDate;
                Rooms = rooms;
        }

        public int Id { get; set; }
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
                if (value < 0 || value > 5)
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

        public void ChangeHotelAddress(string newAddress)
        {
            address = newAddress;
        }

      /*  public override double CalculateRating()
        {
          /*  double stars2 = base.CalculateRating() * 0.7d;
            if (Likes > 10000)
            {
                Likes = 10;
            }
            return (Convert.ToDouble(Likes) / 1000d) * 0.3d + stars2;
        }*/
    }
}
