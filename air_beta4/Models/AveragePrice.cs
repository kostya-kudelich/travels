using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace air_beta4.Models
{

    public class AveragePrice
    {
        public class Info
        {
            public string city;
            public double hotelPrice, ticketPrice, fullPrice;
  
            public Info(string city, double ticketPrice) 
            {
                this.city = city;
                this.ticketPrice = ticketPrice;
            }

        }

        public List<Info> info;
        public string city;

        public AveragePrice(string city) 
        {
            this.city = city;
            info = new List<Info>();
        }


    }
}