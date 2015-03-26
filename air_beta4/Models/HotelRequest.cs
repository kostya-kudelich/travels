using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace air_beta4.Models
{
    public class HotelRequest
    {
        public string iata { get; set; }
        public string checkIn { get; set; }
        public string checkOut { get; set; }
        public int adultsCount { get; set; }
        public string lang { get; set; }
        public string currency { get; set; }

        public HotelRequest(string iata, string checkIn, string checkOut, int adultsCount, string lang, string currency)
        {
            this.iata = iata;
            this.checkIn = checkIn;
            this.checkOut = checkOut;
            this.adultsCount = adultsCount;
            this.lang = lang;
            this.currency = currency;
        }
    }
}