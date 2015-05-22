using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace air_beta4.Models
{
    [BsonIgnoreExtraElements]
    public class AllMonthTicketsFromCity
    {
        public string city;
        public List<MonthTicketsFromCityToCity> tickets;
        public AllMonthTicketsFromCity(string city, List<MonthTicketsFromCityToCity> tickets)
        {
            this.city = city;
            this.tickets = tickets;
        }
    }
}