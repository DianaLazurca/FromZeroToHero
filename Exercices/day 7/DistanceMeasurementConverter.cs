using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercices.day_7
{
   public static class DistanceMeasurementConverter
    {
       public static double ConvertMilesInKM(double distance)
       {
           return distance * 1.609d;
       }

       public static double ConvertKmInMiles(double distance)
       {
           return (distance / 1.609d);
       }
    }
}
