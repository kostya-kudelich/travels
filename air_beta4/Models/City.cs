using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace air_beta4.Models
{
    [BsonIgnoreExtraElements]
    public class City
    {
        public string name { get; set; }
        public string code { get; set; }
        public Coordinates coordinates { get; set; }
        public NameTranslations name_translations { get; set; }
        public string country_code { get; set; }



    }
}