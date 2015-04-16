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

namespace air_beta4.Controllers
{
    public class CountriesController : ApiController
    {

        public List<Country> Get()
        {

          
            var client = new MongoClient();
            MongoServer server = client.GetServer();


            MongoDatabase db = server.GetDatabase("travelsDB");

            MongoCollection<Country> collection = (MongoCollection<Country>)db.GetCollection<Country>("Countries");




        /*    var countryRequest = new WebClient().DownloadString("http://api.travelpayouts.com/data/countries.json");
            List<Country> countries = (List<Country>)JsonConvert.DeserializeObject(countryRequest, typeof(List<Country>));
            countries.Sort((x, y) => x.name.CompareTo(y.name));
         */


            List<Country> countries = new List<Country>();


            MongoCursor<Country> count = collection.FindAllAs<Country>();
            
            foreach (var c in count)
            {
                countries.Add(c);
            }


            return countries;
        }

    }
}
