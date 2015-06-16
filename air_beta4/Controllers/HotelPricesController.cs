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

            MongoCollection<CityHotelPrices> collection = (MongoCollection<CityHotelPrices>)db.GetCollection<CityHotelPrices>("hotelPrices");
            MongoCursor<CityHotelPrices> cursor = collection.FindAllAs<CityHotelPrices>();

            
            List<CityHotelPrices> prices = new List<CityHotelPrices>();

            foreach (CityHotelPrices c in cursor)
            {
                prices.Add(c);
            }

            List<CityHotelPrices> sortedList = prices.OrderBy(x => x.city).ToList();

            MongoCollection<CityHotelPrices> sortedCollection = (MongoCollection<CityHotelPrices>)db.GetCollection<CityHotelPrices>("sortedHotelPrices");

            foreach (CityHotelPrices c in sortedList)
            {
                sortedCollection.Insert<CityHotelPrices>(c);
            }
            

      
            int a;

            return sortedList;
        }

    }
}
