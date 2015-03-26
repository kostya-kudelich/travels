using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace air_beta4.Models
{
    public class Ticket
    {

        /*public int price {get; set;}
        public string airline {get; set;}
        public string flight_number {get; set;}
        public string departure_at {get; set;}
        public string return_at {get; set;}
        public string expires_at {get; set;}*/

        public int price;
        public string airline;
        public int flight_number;
        public string departure_at;
        public string return_at;
        public string expires_at;

        public Ticket(int price, string airline, int flight_number, string departure_at, string return_at, string expires_at)
        {
            this.price = price;
            this.airline = airline;
            this.flight_number = flight_number;
            this.departure_at = departure_at;
            this.return_at = return_at;
            this.expires_at = expires_at;
        }

    }
}