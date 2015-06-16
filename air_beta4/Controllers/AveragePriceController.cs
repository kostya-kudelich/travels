using air_beta4.Models;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace air_beta4.Controllers
{
    public class AveragePriceController : ApiController
    {
        private double averageSum(List<List<HotelPrice>> list, int duration)
        {

            int count = 0;
            double res = 0;

            for (int i = 0; i < list.Count; i++)
            {
                double sum = 0;

                List<HotelPrice> sortedList = list[i].OrderBy(x => x.priceFrom).ToList();
                if (sortedList.Count != 0)
                {
                    count++;
                    for (int j = 0; j < sortedList.Count; j++)
                    {
                        sum += sortedList[j].priceFrom;
                        if (j == 4 || j == sortedList.Count - 1)
                        {
                            sum = sum / j;
                            break;
                        }
                    }
                }
                res += sum / duration;
            }
            res /= count;

            return res;
        }
        public AveragePrice Get(string originCountry, string originCity, int duration)
        {

            var client = new MongoClient();
            MongoServer server = client.GetServer();


            MongoDatabase db = server.GetDatabase("travelsDB");

            /*

            MongoCollection<AllMonthTicketsFromCity> collection = (MongoCollection<AllMonthTicketsFromCity>)db.GetCollection<AllMonthTicketsFromCity>("allMonthTicketsFromCity");

            MongoCursor<AllMonthTicketsFromCity> cursor = collection.FindAllAs<AllMonthTicketsFromCity>();


            MongoCollection<CityHotelPrices> hotelPrices = (MongoCollection<CityHotelPrices>)db.GetCollection<CityHotelPrices>("hotelPrices");
            MongoCursor<CityHotelPrices> hotelPricesCursor = hotelPrices.FindAllAs<CityHotelPrices>();



            List<AveragePrice> list = new List<AveragePrice>();
            foreach (AllMonthTicketsFromCity c in cursor)
            {
                AveragePrice price = new AveragePrice(c.city);
                foreach (MonthTicketsFromCityToCity m in c.tickets)
                {
                    if (!m.city.Equals(c.city))
                    {
                        price.info.Add(new AveragePrice.Info(m.city, m.averagePrice));
                    }
                }
                int counter = 0;
                foreach (CityHotelPrices chp in hotelPricesCursor)
                {


                    if (counter < price.info.Count && !chp.city.Equals(c.city) && chp.city.Equals(price.info[counter].city))
                    {

                        double res = (averageSum(chp.list3, 3) + averageSum(chp.list7, 7) + averageSum(chp.list15, 15)) / 3;
                        //res *= duration;
                        price.info[counter].hotelPrice = res;
                        price.info[counter].fullPrice = res + price.info[counter].ticketPrice;
                        counter++;

                    }
                }
                list.Add(price);
            }

            
            MongoCollection<AveragePrice> averagePriceCollection = (MongoCollection<AveragePrice>)db.GetCollection<AveragePrice>("averagePrice");
            
            for (int i = 0; i < list.Count; i++)
            {
                averagePriceCollection.Insert<AveragePrice>(list[i]);
            }

            */

            MongoCollection<AveragePrice> averagePriceCollection = (MongoCollection<AveragePrice>)db.GetCollection<AveragePrice>("averagePrice");
            MongoCursor<AveragePrice> cursor = averagePriceCollection.FindAllAs<AveragePrice>();
            AveragePrice res = new AveragePrice("city");

            foreach (AveragePrice a in cursor)
            {
                if (a.city.Equals(originCity))
                {
                    res = a;
                    for (int i = 0; i < res.info.Count; i++)
                    {
                        res.info[i].hotelPrice *= duration;
                    }
                        break;
                }
            }

            return res;

        }

    }
}
