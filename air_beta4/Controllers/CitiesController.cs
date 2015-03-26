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
    public class CitiesController : ApiController
    {

        public List<City> Get()
        {
            var cityRequest = new WebClient().DownloadString("http://api.travelpayouts.com/data/cities.json");
            List<City> cities = (List<City>)JsonConvert.DeserializeObject(cityRequest, typeof(List<City>));
            cities.Sort((x, y) => x.name.CompareTo(y.name));

            return cities;
        }

    }
}
