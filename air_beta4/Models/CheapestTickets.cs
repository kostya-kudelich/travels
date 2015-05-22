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



namespace air_beta4.Models
{

    public class CheapestTickets
    {
        public string api;
        public string token = "60be4bd09411cd4664933bd759ba8963";
        public List<Ticket> list = new List<Ticket>();

        public CheapestTickets(string origin, string destination, string departDate, string returnDate, string currency)
        {

            this.api = "http://api.travelpayouts.com/v1/prices/cheap?origin=" + origin + "&destination=" +
                destination + "&depart_date=" + departDate + "&return_date=" + returnDate + "&token=" + token + "&currency=" + currency;

            
            string request = new WebClient().DownloadString(api);
   
            
         
            HotelsRequestResult HRR = (HotelsRequestResult)JsonConvert.DeserializeObject(request, typeof(HotelsRequestResult));

            //dynamic tickets = (dynamic)JsonConvert.DeserializeObject(request);

            JObject d = JObject.Parse(request);
            //Dictionary<string, object> dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(request);



            if (d.SelectToken("data").Count() != 0)
            {
                foreach (dynamic i in d["data"][destination])
                {
                    foreach (dynamic j in i)
                    {
                        int price = j["price"];
                        string airline = j["airline"];
                        int flight_number = j["flight_number"];
                        string departure_at = j["departure_at"];
                        string return_at = j["return_at"];
                        string expires_at = j["expires_at"];
                        Ticket t = new Ticket(price, airline, flight_number, departure_at, return_at, expires_at);
                        list.Add(t);

                    }

                }


                list.Sort((x, y) => x.price.CompareTo(y.price));
            }


        }


    }
}