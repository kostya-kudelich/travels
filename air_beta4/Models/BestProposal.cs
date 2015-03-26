using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace air_beta4.Models
{
    public class BestProposal
    {

        public List<Ticket> tickets;
        public List<Hotel> hotels;
        public BestProposal(List<Ticket> tickets, List<Hotel> hotels)
        {
            this.tickets = tickets;
            this.hotels = hotels;
        }


    }
}