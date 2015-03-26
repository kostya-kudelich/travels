using air_beta4.Models;
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
        public List<Country> countries;
        public List<City> cities;
        public RequestController(string originCountry, string originCity, string destinationCountry, string destinationCity)
        {
            var countryRequest = new WebClient().DownloadString("http://api.travelpayouts.com/data/countries.json");
            countries = (List<Country>)JsonConvert.DeserializeObject(countryRequest, typeof(List<Country>));
            countries.Sort((x, y) => x.name.CompareTo(y.name));


            var cityRequest = new WebClient().DownloadString("http://api.travelpayouts.com/data/cities.json");
            cities = (List<City>)JsonConvert.DeserializeObject(cityRequest, typeof(List<City>));

            int originCountryId = 0;
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

        }
    }
}