using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace air_beta4.Models
{
    public class Hotel
    {
        [JsonProperty("fullUrl")]
        public string fullUrl { get; set; }

        [JsonProperty("maxPrice")]
        public int maxPrice { get; set; }

        [JsonProperty("maxPricePerNight")]
        public int maxPricePerNight { get; set; }

        [JsonProperty("price")]
        public int price { get; set; }

        [JsonProperty("minPriceTotal")]
        public int minPriceTotal { get; set; }

        [JsonProperty("photoCount")]
        public int photoCount { get; set; }

        [JsonProperty("guestScore")]
        public int guestScore { get; set; }

        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("distance")]
        public float distance { get; set; }

        [JsonProperty("amenities")]
        public List<int> amenities { get; set; }

        [JsonProperty("adress")]
        public string adress { get; set; }

        [JsonProperty("location")]
        public Coordinates location { get; set; }

        [JsonProperty("stars")]
        public int stars { get; set; }

        [JsonProperty("url")]
        public string url { get; set; }

        [JsonProperty("rating")]
        public int rating { get; set; }

        [JsonProperty("rooms")]
        public List<HotelResultRooms> rooms { get; set; }


    }
}