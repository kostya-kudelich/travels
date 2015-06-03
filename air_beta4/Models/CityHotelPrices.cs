using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace air_beta4.Models

{
    [BsonIgnoreExtraElements]
    public class CityHotelPrices
    {
        public List<List<HotelPrice>> list3;
        public List<List<HotelPrice>> list7;
        public List<List<HotelPrice>> list15;
        public string city;

        public CityHotelPrices(string city, List<List<HotelPrice>> list3, List<List<HotelPrice>> list7, List<List<HotelPrice>> list15)
        {
            this.city = city;
            this.list3 = list3;
            this.list7 = list7;
            this.list15 = list15;
        } 
    }
}