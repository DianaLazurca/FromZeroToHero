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
    }
}