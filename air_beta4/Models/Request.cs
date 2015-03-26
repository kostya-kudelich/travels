using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace air_beta4.Models
{
    public class Request
    {
        public string ans;
        public List<CheapestTicketHotel> list;
        public BestProposal bP;
        public Request(Country originCountry, City originCity, Country destinationCountry, City destinationCity, string checkIn, string checkOut, List<Country> countries, List<City> cities, int personCount, double maxPrice, string currency)
        {
            if (originCity != null && destinationCity != null)
            {

                CheapestTickets cheapestTickets = new CheapestTickets(originCity.code, destinationCity.code, checkIn, checkOut, currency);
                HotelRequest ht = new HotelRequest(destinationCity.code, checkIn, checkOut, personCount, "en", currency);
                HotelList temp = new HotelList(ht);

                int hotelLength = temp.list.Count;
                int ticketsLength = cheapestTickets.list.Count;
                if (hotelLength > 10)
                {
                    hotelLength = 10;
                }
                if (ticketsLength > 10)
                {
                    ticketsLength = 10;
                }

                bP = new BestProposal(new List<Ticket>(), new List<Hotel>());
                if (cheapestTickets.list[0].price + temp.list[0].minPriceTotal <= maxPrice)
                {
                    bP = new BestProposal(cheapestTickets.list.GetRange(0, ticketsLength), temp.list.GetRange(0, hotelLength));
                }

                ans = (string)JsonConvert.SerializeObject(bP);
                //HotelsRequestResult HRR = (HotelsRequestResult)JsonConvert.DeserializeObject(request, typeof(HotelsRequestResult));
                //ans = new JavaScriptSerializer().Serialize(bP);
            }

            if (destinationCity == null)
            {

                List<City> toCities = new List<City>();
                for (int i = 0; i < cities.Count; i++)
                {
                    if (destinationCountry.code == cities[i].country_code)
                    {
                        toCities.Add(cities[i]);
                    }
                }

                list = new List<CheapestTicketHotel>();
                for (int i = 0; i < toCities.Count; i++)
                {
                    destinationCity = toCities[i];
                    CheapestTickets cheapestTickets = new CheapestTickets(originCity.code, destinationCity.code, checkIn, checkOut, currency);
                    if (cheapestTickets.list.Count != 0)
                    {
                        HotelRequest ht = new HotelRequest(destinationCity.code, checkIn, checkOut, 1, "en", "USD");
                        HotelList temp = new HotelList(ht);

                        if (cheapestTickets.list[0].price + temp.list[0].minPriceTotal <= maxPrice)
                        {
                            CheapestTicketHotel cth = new CheapestTicketHotel(cheapestTickets.list[0], temp.list[0], destinationCountry.name, destinationCity.name);
                            list.Add(cth);
                        }
                    }
                }

                ans = (string)JsonConvert.SerializeObject(list);

                //ans = new JavaScriptSerializer().Serialize(list);


            }
        }



    }
}
