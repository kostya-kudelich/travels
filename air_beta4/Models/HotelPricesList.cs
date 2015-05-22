using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace air_beta4.Models
{
    public class HotelPricesList
    {
       
        public List<CityHotelPrices> list = new List<CityHotelPrices>();
      

        public HotelPricesList()
        {


            var client = new MongoClient();
            MongoServer server = client.GetServer();
            MongoDatabase db = server.GetDatabase("travelsDB");

            MongoCollection<City> cityCollection = (MongoCollection<City>)db.GetCollection<City>("filteredCities");
            MongoCursor<City> cityCursor = cityCollection.FindAllAs<City>();

            MongoCollection<CityHotelPrices> hotelPrices = (MongoCollection<CityHotelPrices>)db.GetCollection<CityHotelPrices>("hotelPrices");


     
            

            int ff = 0;
            foreach (City c in cityCursor)
            {

                DateTime dateCheckIn = new DateTime(2015, 5, 1);
                DateTime dateCheckOut3 = new DateTime(2015, 5, 4);
                DateTime dateCheckOut7 = new DateTime(2015, 5, 8);
                DateTime dateCheckOut15 = new DateTime(2015, 5, 16);
                int month = dateCheckIn.Month;

                List<List<HotelPrice>> monthPrices3 = new List<List<HotelPrice>>();
                List<List<HotelPrice>> monthPrices7 = new List<List<HotelPrice>>();
                List<List<HotelPrice>> monthPrices15 = new List<List<HotelPrice>>();

                ff++;
                
                while (dateCheckIn.Month == month)
                {
                   
                    string checkIn = dateCheckIn.ToString("yyyy-MM-dd");
                    string checkOut3 = dateCheckOut3.ToString("yyyy-MM-dd");
                    string checkOut7 = dateCheckOut7.ToString("yyyy-MM-dd");
                    string checkOut15 = dateCheckOut15.ToString("yyyy-MM-dd");


                    string api3 = "http://yasen.hotellook.com/api/v2/cache.json?location=" + c.code + "&currency=usd&checkIn=" + checkIn + "&checkOut=" + checkOut3 + "&limit=10";
                    var request3 = new WebClient().DownloadString(api3);
                    List<HotelPrice> prices3 = (List<HotelPrice>)JsonConvert.DeserializeObject(request3, typeof(List<HotelPrice>));

                    string api7 = "http://yasen.hotellook.com/api/v2/cache.json?location=" + c.code + "&currency=usd&checkIn=" + checkIn + "&checkOut=" + checkOut7 + "&limit=10";
                    var request7 = new WebClient().DownloadString(api7);
                    List<HotelPrice> prices7 = (List<HotelPrice>)JsonConvert.DeserializeObject(request7, typeof(List<HotelPrice>));

                    string api15 = "http://yasen.hotellook.com/api/v2/cache.json?location=" + c.code + "&currency=usd&checkIn=" + checkIn + "&checkOut=" + checkOut15 + "&limit=10";
                    var request15 = new WebClient().DownloadString(api15);
                    List<HotelPrice> prices15 = (List<HotelPrice>)JsonConvert.DeserializeObject(request15, typeof(List<HotelPrice>));

                    monthPrices3.Add(prices3);
                    monthPrices7.Add(prices7);
                    monthPrices15.Add(prices15);

                    dateCheckIn = dateCheckIn.AddDays(1);
                    dateCheckOut3 = dateCheckOut3.AddDays(1);
                    dateCheckOut7 = dateCheckOut7.AddDays(1);
                    dateCheckOut15 = dateCheckOut15.AddDays(1);
                    
                }

                list.Add(new CityHotelPrices(c.name, monthPrices3, monthPrices7, monthPrices15));
                if (ff == 5)
                {
                    break;
                }
                
            }

            foreach (CityHotelPrices chp in list)
            {
                hotelPrices.Insert<CityHotelPrices>(chp);
            }


        

        }
    }
}