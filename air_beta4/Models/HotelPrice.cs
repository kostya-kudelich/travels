using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace air_beta4.Models
{
    public class HotelPrice
    {
        public int stars { get; set; }
        public int locationId { get; set; }
        public double priceFrom { get; set; }
        public string hotelName { get; set; }
        public HotelLocation location { get; set; }
        public int hotelId { get; set; }

     }
}