using air_beta4.Models;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Description;

namespace air_beta4.Controllers
{
    public class HotelPricesController : ApiController
    {

        public List<CityHotelPrices> Get()
        {

            var client = new MongoClient();

            MongoServer server = client.GetServer();
            MongoDatabase db = server.GetDatabase("travelsDB");

            MongoCollection<City> cityCollection = (MongoCollection<City>)db.GetCollection<City>("filteredCities");
            MongoCursor<City> cityCursor = cityCollection.FindAllAs<City>();



            
            HotelPricesList hotelPrices = new HotelPricesList();

            return hotelPrices.list;
        }

    }
}
