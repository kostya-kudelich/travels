using air_beta4.Models;
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
    public class FromCityToCityController : ApiController
    {

        public BestProposal Get(string originCountry, string originCity, string destinationCountry, string destinationCity, string checkIn, string checkOut, int personCount, int maxPrice, string currency)
        {
            RequestController rq = new RequestController(originCountry, originCity, destinationCountry, destinationCity);
 
            
            Request req = new Request(rq.originCountry, rq.originCity, rq.destinationCountry, rq.destinationCity, checkIn, checkOut, rq.countries, rq.cities, personCount, maxPrice, currency);

            return req.bP;

        }

    }
}