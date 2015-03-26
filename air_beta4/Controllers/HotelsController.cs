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
    public class HotelsController : ApiController
    {

        public List<Hotel> Get(string country, string city, string checkIn, string checkOut, int personCount, string currency)
        {
            RequestController rq = new RequestController(null, null, country, city);

            HotelRequest ht = new HotelRequest(rq.destinationCity.code, checkIn, checkOut, personCount, "en", currency);
            HotelList temp = new HotelList(ht);

            return temp.list;
        }

    }
}