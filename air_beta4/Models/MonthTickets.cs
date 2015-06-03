using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using air_beta4.Models;
using System.Net;
using System.Web.Helpers;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using MongoDB.Bson.Serialization.Attributes;
namespace air_beta4.Models
{
    [BsonIgnoreExtraElements]
    public class MonthTickets
    {
   
        public List<MonthTicketsResult> list = new List<MonthTicketsResult>();
        public MonthTickets(string origin, string destination, string departDate, string currency)
        {
            
            string token = "60be4bd09411cd4664933bd759ba8963";
           // string api = "http://api.travelpayouts.com/v1/prices/calendar?" + origin + "&destination=" +
           //     destination + "&depart_date=" + departDate + "&calendar_type=departure_date" + "&token=" + token + "&currency=" + currency;

            string api = "http://api.travelpayouts.com/v1/prices/calendar?depart_date=" + departDate + "&origin=" + origin + "&destination=" + destination +
                "&calendar_type=departure_date" + "&token=" + token + "&currency=" + currency;

            string request = new WebClient().DownloadString(api);


            JObject d = JObject.Parse(request);
            

            if (d.SelectToken("data").Count() != 0)
            {
                foreach (dynamic i in d["data"])
                {
                    foreach (dynamic j in i)
                    {
                        string orig = j["origin"];
                        string dest = j["destination"];
                        int price = j["price"];
                        int transfers = j["transfers"];
                        string airline = j["airline"];
                        string departure_at = j["departure_at"];
                        string return_at = j["return_at"];
                        string source = j["expires_at"];
                        MonthTicketsResult t = new MonthTicketsResult(orig, dest, price, transfers, airline, departure_at, return_at, source);

                        list.Add(t);
                    }

                }

            }
        }
    }
}