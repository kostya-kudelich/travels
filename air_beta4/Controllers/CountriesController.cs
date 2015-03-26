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
    public class CountriesController : ApiController
    {

        public List<Country> Get()
        {
            var countryRequest = new WebClient().DownloadString("http://api.travelpayouts.com/data/countries.json");
            List<Country> countries = (List<Country>)JsonConvert.DeserializeObject(countryRequest, typeof(List<Country>));
            countries.Sort((x, y) => x.name.CompareTo(y.name));

            return countries;
        }

    }
}
