using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace air_beta4.Models
{
    public class MonthTicketsResult
    {
        /*public string origin { get; set; }
        public string destination {get; set; }
        public int price { get; set; }
        public int transfers { get; set; }
        public string airline { get; set; }
        public string departure_at { get; set; }
        public string return_at { get; set; }
        public string source { get; set; }
        */


        public string origin;
        public string destination;
        public int price;
        public int transfers;
        public string airline;
        public string departure_at;
        public string return_at;
        public string source;

        public MonthTicketsResult(string origin, string destination, int price, int transfers, string airline, string departure_at, string return_at, string source)
        {
            this.origin = origin;
            this.destination = destination;
            this.price = price;
            this.transfers = transfers;
            this.airline = airline;
            this.departure_at = departure_at;
            this.return_at = return_at;
            this.source = source;
        }

    }
}