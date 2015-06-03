using air_beta4.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
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
    public class MonthTicketsController : ApiController
    {

        public int Get(string originCountry, string originCity, string destinationCountry, string destinationCity, string departDate,
            string returnDate, int tripDuration)
        {


            var client = new MongoClient();
            MongoServer server = client.GetServer();

            MongoDatabase db = server.GetDatabase("travelsDB");
            MongoCollection<City> cityCollection = (MongoCollection<City>)db.GetCollection<City>("filteredCities");


            MongoCursor<City> cityCursor = cityCollection.FindAllAs<City>();

            string[] originCities = new string[] { "MOW", "LED", "OVB", "SVX", "KZN", "KUF" };
            string[] originCitiesNames = new string[] { "Moscow", "Saint Petersburg", "Novosibirsk", "Ekaterinburg", "Kazan", "Samara" };

            


            for (int i = 0; i < originCities.Length; i++)
            {
                List<MonthTicketsFromCityToCity> tickets = new List<MonthTicketsFromCityToCity>();

                foreach (City c in cityCursor)
                {
                    if (!c.code.Equals(originCities[i]))
                    {
                        MonthTickets ticketsTo = new MonthTickets(originCities[i], c.code, "2015-06", "USD");
                        MonthTickets ticketsFrom = new MonthTickets(c.code, originCities[i], "2015-06", "USD");


                        MonthTicketsFromCityToCity mt = new MonthTicketsFromCityToCity(c.name, ticketsTo.list, ticketsFrom.list);
                        if (ticketsFrom.list.Count != 0 && ticketsTo.list.Count != 0)
                        {
                            tickets.Add(mt);
                        }
                     
                    }
                }
                AllMonthTicketsFromCity almt = new AllMonthTicketsFromCity(originCitiesNames[i], tickets);
                MongoCollection<AllMonthTicketsFromCity> collection = (MongoCollection<AllMonthTicketsFromCity>)db.GetCollection<AllMonthTicketsFromCity>("allMonthTicketsFromCity");
                collection.Insert<AllMonthTicketsFromCity>(almt);

            }
            



            
            MongoCollection<AllMonthTicketsFromCity> col = (MongoCollection<AllMonthTicketsFromCity>)db.GetCollection<AllMonthTicketsFromCity>("allMonthTicketsFromCity");

            MongoCursor<AllMonthTicketsFromCity> cursor = col.FindAllAs<AllMonthTicketsFromCity>();

            foreach (AllMonthTicketsFromCity c in cursor)
            {
                AllMonthTicketsFromCity aaa = c;
                int aaaa = 1;
            }


            
            /*var query = Query.Matches("city", originCity);
            AllMonthTicketsFromCity aaa = (AllMonthTicketsFromCity)collection.FindOne(query);
            */

            return 5;
        }
    }
}
