using air_beta4.Models;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace air_beta4.Models
{
    public class RequestController
    {
        public Country originCountry, destinationCountry;
        public City originCity, destinationCity;
        public List<Country> countries = new List<Country>();
        public List<City> cities = new List<City>();
        public RequestController(string originCountry, string originCity, string destinationCountry, string destinationCity)
        {

            var client = new MongoClient();
            MongoServer server = client.GetServer();
            MongoDatabase db = server.GetDatabase("db");

            MongoCollection<City> cityCollection = (MongoCollection<City>)db.GetCollection<City>("Cities");
            MongoCollection<Country> countryCollection = (MongoCollection<Country>)db.GetCollection<Country>("Countries");

       /*     var countryRequest = new WebClient().DownloadString("http://api.travelpayouts.com/data/countries.json");
            countries = (List<Country>)JsonConvert.DeserializeObject(countryRequest, typeof(List<Country>));
            countries.Sort((x, y) => x.name.CompareTo(y.name));


            var cityRequest = new WebClient().DownloadString("http://api.travelpayouts.com/data/cities.json");
            cities = (List<City>)JsonConvert.DeserializeObject(cityRequest, typeof(List<City>));
        */

            MongoCursor<Country> countryCursor= countryCollection.FindAllAs<Country>();
            foreach (var c in countryCursor)
            {
                countries.Add(c);
            }
            MongoCursor<City> cityCursor = cityCollection.FindAllAs<City>();
            foreach (var c in cityCursor)
            {
                cities.Add(c);
            }


            var queryOriginCountry = new QueryDocument("name", originCountry);
            this.originCountry = countryCollection.FindOne(queryOriginCountry);

            var queryOriginCity = new QueryDocument("name", originCity);
            this.originCity = cityCollection.FindOne(queryOriginCity);

            var queryDestinationCountry = new QueryDocument("name", destinationCountry);
            this.destinationCountry = countryCollection.FindOne(queryDestinationCountry);

            if (destinationCity != null)
            {
                var queryDestinationCity = new QueryDocument("name", destinationCity);
                this.destinationCity = cityCollection.FindOne(queryDestinationCity);
            }

          /*  int originCountryId = 0;
            int destinationCountryId = 0;
            int originCityId = 0;
            int destinationCityId = 0;

            for (int i = 0; i < countries.Count; i++)
            {
                if (countries[i].name.Equals(originCountry))
                {
                    originCountryId = i;
                }
                if (countries[i].name.Equals(destinationCountry))
                {
                    destinationCountryId = i;
                }
            }


            for (int i = 0; i < cities.Count; i++)
            {
                if (cities[i].name.Equals(originCity) && cities[i].country_code.Equals(countries[originCountryId].code))
                {
                    originCityId = i;
                }
                if (destinationCity != null) {
                    if (cities[i].name == destinationCity && cities[i].country_code.Equals(countries[destinationCountryId].code))
                    {
                        destinationCityId = i;
                    }
                }
            }


            this.originCountry = countries[originCountryId];
            this.originCity = cities[originCityId];
            this.destinationCountry = countries[destinationCountryId];
            if (destinationCity != null)
            {
                this.destinationCity = cities[destinationCityId];
            }
          */

        }
    }
}