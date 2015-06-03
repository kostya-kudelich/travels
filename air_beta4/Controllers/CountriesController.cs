using air_beta4.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

using System.Web.Helpers;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDB.Bson.Serialization;
using MongoDB.Driver.Builders;
using System.Text;

namespace air_beta4.Controllers
{
    public class CountriesController : ApiController
    {

        public List<Country> Get()
        {


            var client = new MongoClient();
            MongoServer server = client.GetServer();


            MongoDatabase db = server.GetDatabase("travelsDB");

            MongoCollection<Country> countryCollection = (MongoCollection<Country>)db.GetCollection<Country>("filteredCountries");




            /*var countryRequest = new WebClient().DownloadString("http://api.travelpayouts.com/data/countries.json");
            List<Country> countries = (List<Country>)JsonConvert.DeserializeObject(countryRequest, typeof(List<Country>));
            countries.Sort((x, y) => x.name.CompareTo(y.name));

            var cityRequest = new WebClient().DownloadString("http://api.travelpayouts.com/data/cities.json");
            List<City> cities = (List<City>)JsonConvert.DeserializeObject(cityRequest, typeof(List<City>));
            cities.Sort((x, y) => x.name.CompareTo(y.name));
            */


            List<Country> countries = new List<Country>();
            MongoCursor<Country> countryCursor = countryCollection.FindAllAs<Country>();

            foreach (Country c in countryCursor)
            {
                countries.Add(c);
            }

            return countries;
        }

    }
}
