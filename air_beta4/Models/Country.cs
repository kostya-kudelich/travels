using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using MongoDB.Bson;
using System.Xml.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace air_beta4.Models
{
    [BsonIgnoreExtraElements]
    public class Country
    {

        
       // public ObjectId id { get; set; }

        [JsonProperty("code")]
        public string code { get; set; } // country code

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("currency")]
        public string currency { get; set; }

        [JsonProperty("name_translations")]
        public NameTranslations name_translations { get; set; }

    }
}