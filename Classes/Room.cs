using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public  enum RoomTypes { 
        Single, 
        Double, 
        Twin, 
        Duplex,
        KingBedroom
    };

   public  class Room
    {
        private string description;
        private int places;
        private int number;
        private int floor;
        private RoomTypes type;
        public bool hasAirConditioning;
        public bool hasFlatTVSceen;

        public Room(string description, int places, int number, int floor, RoomTypes type)
        {
            Description = description;
            Places = places;
            Number = number;
            Floor = floor;
            Type = type;
        }

        #region Fields
        public bool HasAirConditioning { get; set; }
        public bool HasFlatTVSceen { get; set; }
        public RoomTypes Type { get; set; }
        public string Description
        {
            get { return this.description; }
            set
            {
                if (value.Length > 500)
                {
                    Console.WriteLine(" Room description to big");
                    this.description = "";
                }
                else
                {
                    this.description = value;
                }
            }
        }

        public int Floor
        {
            get { return this.floor; }
            set
            {
                if (value < 0 || value > 1000)
                {
                    Console.WriteLine("Invalid Floor number");
                    this.floor = 0;
                }
                else
                {
                    this.floor = value;
                }
            }
        }


        public int Number
        {
            get { return this.number; }
            set
            {
                if (value < 0 || value > 10000)
                {
                    Console.WriteLine("Invalid room number");
                    this.floor = 0;
                }
                else
                {
                    this.number = value;
                }
            }
        }
        public int Places
        {
            get { return this.places; }
            set
            {
                if (Type == RoomTypes.Single)
                {
                    if (value != 1)
                    {
                        Console.WriteLine("Room Single, places != 1");
                        this.places = 0;
                    }
                    else
                    {
                        this.places = value;
                    }
                    
                }

                if (Type == RoomTypes.Double || Type == RoomTypes.Twin)
                {
                    if (value < 0 || value > 2)
                    {
                        Console.WriteLine("Room Double/Twin, places > 2 or < 0");
                        this.places = 0;
                    }
                    else
                    {
                        this.places = value;
                    }

                }

                if (Type == RoomTypes.KingBedroom)
                {
                    if (value < 2 || value > 4)
                    {
                        Console.WriteLine("Room , KingBedroom places > 2 or < 0");
                        this.places = 0;
                    }
                    else
                    {
                        this.places = value;
                    }

                }

                if (Type == RoomTypes.Duplex)
                {
                    if (value < 2 || value > 6)
                    {
                        Console.WriteLine("Room , Duplex places > 2 or < 0");
                        this.places = 0;
                    }
                    else
                    {
                        this.places = value;
                    }

                }
                
            }
        }
        #endregion

        public void DisplayInfo()
        {
            Console.WriteLine(" Room number : {0}", Number);
            Console.WriteLine(" Decription : {0}" , Description);
            Console.WriteLine(" Places : {0}" , Places);            
            Console.WriteLine(" Floor : {0}" , Floor);
            Console.WriteLine(" Room type : {0}" , Type);
        }
    }
}
