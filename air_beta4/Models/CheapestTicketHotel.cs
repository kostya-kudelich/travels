using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace air_beta4.Models
{
    public class CheapestTicketHotel
    {

        public Ticket ticket;
        public Hotel hotel;
        public String country, city;
        public CheapestTicketHotel(Ticket ticket, Hotel hotel, string country, string city)
        {
            this.ticket = ticket;
            this.hotel = hotel;
            this.country = country;
            this.city = city;
        }
    }
}