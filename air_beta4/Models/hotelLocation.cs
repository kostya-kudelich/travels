using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace air_beta4.Models
{
    public class HotelLocation
    {
        public Coordinates geo { get; set; }
        public string name { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        
    }
}