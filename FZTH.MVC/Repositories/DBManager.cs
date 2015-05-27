using FZTH.MVC.Entities;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate.Linq;

namespace FZTH.MVC.Repositories
{
    public class DBManager
    {
        ISession session;
        public DBManager(ISession session)
        {
            this.session = session;
        }

        public IList<Hotel> GetAllHotels()
        {
            return session.Query<Hotel>().ToList();
        }

        public Location GetLocation(string city, string county)
        {
          return  (Location)session.QueryOver<Location>().Where(x => x.City == city && x.County == county).SingleOrDefault();
        }

        public void DeleteHotel(int id)
        {
            using (var transaction = session.BeginTransaction())
            {
                Hotel hotel = (Hotel)session.QueryOver<Hotel>().Where(x => x.Id == id).SingleOrDefault();
                if (hotel != null)
                {
                    session.Delete(hotel);
                }


               transaction.Commit();
            }
        }

        public Entities.Hotel AddNewHotel(Entities.Hotel hotel)
        {
            using (var transaction = session.BeginTransaction())
            {
                Location location =   GetLocation(hotel.Location.City, hotel.Location.County);

                if (location != null)
                {
                    hotel.Location = location;                    
                }
                else
                {
                    // cream locatia
                    Location loc = new Location
                    {
                        City = hotel.Location.City,
                        County = hotel.Location.County
                    };
                    session.SaveOrUpdate(loc);
                    hotel.Location = loc;
                    
                }
                session.SaveOrUpdate(hotel);
                transaction.Commit();
                return hotel;
            }
          
        }

        public Entities.Hotel GetHotelById(int id)
        {
            return session.QueryOver<Hotel>().Where(x => x.Id == id).SingleOrDefault();
        } 

        public  void EditHotel(Hotel entityHotel)
        {
            using (var transaction = session.BeginTransaction())
            {
                Location loc = GetLocation(entityHotel.Location.City, entityHotel.Location.County);
                Hotel updatedHotel = session.QueryOver<Hotel>().Where( x => x.Id == entityHotel.Id).SingleOrDefault();

                updatedHotel.Name = entityHotel.Name;

                if (loc != null)
                {
                    updatedHotel.Location = loc;
                }
                else
                {
                    Location location = new Location
                    {
                        City = entityHotel.Location.City,
                        County = entityHotel.Location.County
                    };

                    session.SaveOrUpdate(location);
                    updatedHotel.Location = location;
                }
                session.SaveOrUpdate(updatedHotel);
                transaction.Commit();
            }
        }
    }
}