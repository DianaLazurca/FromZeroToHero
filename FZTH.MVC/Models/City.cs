using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FZTH.MVC.Models
{
    public class City
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public County County { get; set; }
    }
}