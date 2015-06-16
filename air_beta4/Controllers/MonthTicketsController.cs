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

        public MonthTicketsFromCityToCity Get(string originCity, string destinationCity, string departDate,
            string returnDate)
        {


            var client = new MongoClient();
            MongoServer server = client.GetServer();

            MongoDatabase db = server.GetDatabase("travelsDB");
            MongoCollection<City> cityCollection = (MongoCollection<City>)db.GetCollection<City>("filteredCities");


            MongoCursor<City> cityCursor = cityCollection.FindAllAs<City>();

            string[] originCities = new string[] { "MOW", "LED", "OVB", "SVX", "KZN", "KUF" };
            string[] originCitiesNames = new string[] { "Moscow", "Saint Petersburg", "Novosibirsk", "Ekaterinburg", "Kazan", "Samara" };


            /*     for (int i = 0; i < originCities.Length; i++)
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
            
     */
            MongoCollection<AllMonthTicketsFromCity> collection = (MongoCollection<AllMonthTicketsFromCity>)db.GetCollection<AllMonthTicketsFromCity>("allMonthTicketsFromCity");
            MongoCursor<AllMonthTicketsFromCity> cursor = collection.FindAllAs<AllMonthTicketsFromCity>();


            MonthTicketsFromCityToCity ans = new MonthTicketsFromCityToCity("", new List<MonthTicketsResult>(), new List<MonthTicketsResult>());



            foreach (AllMonthTicketsFromCity mt in cursor)
            {
                if (mt.city.Equals(originCity))
                {
                    foreach (MonthTicketsFromCityToCity c in mt.tickets)
                    {
                        if (c.city.Equals(destinationCity))
                        {
                            ans = c;
                        }
                    }
                }
            }



            return ans;            


        }
    }
}
