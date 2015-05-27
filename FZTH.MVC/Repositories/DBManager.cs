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

        public void AddNewHotel(Entities.Hotel hotel)
        {
            using (var transaction = session.BeginTransaction())
            {
                Location location = GetLocation(hotel.Location.City, hotel.Location.County);

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
            }
          
        } 
    }
}