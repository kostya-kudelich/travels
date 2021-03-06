﻿using air_beta4.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace air_beta4.Controllers
{
    public class TicketsController : ApiController
    {

        public List<Ticket> Get(string originCountry, string originCity, string destinationCountry, string destinationCity, string departDate, string returnDate, string currency)
        {
            RequestController rq = new RequestController(originCountry, originCity, destinationCountry, destinationCity);
            CheapestTickets cheapestTickets = new CheapestTickets(rq.originCity.code, rq.destinationCity.code, departDate, returnDate, currency);
            return cheapestTickets.list;
        }

    }
}
