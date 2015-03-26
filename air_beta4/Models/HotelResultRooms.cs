using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using air_beta4.Models;

namespace air_beta4.Models
{
    public class HotelResultRooms
    {
        [JsonProperty("type")]
        public string type { get; set; }

        [JsonProperty("desc")]
        public string desc { get; set; }

        [JsonProperty("total")]
        public int total { get; set; }

        [JsonProperty("price")]
        public int price { get; set; }

        [JsonProperty("tax")]
        public int tax { get; set; }

        [JsonProperty("options")]
        public HotelResultRoomsOptions options { get; set; }

        [JsonProperty("bookingURL")]
        public string bookingURL { get; set; }

        [JsonProperty("fullBookingURL")]
        public string fullBookingURL { get; set; }

        [JsonProperty("internalTypeId")]
        public string internalTypeId { get; set; }

        [JsonProperty("agencyId")]
        public string agencyId { get; set; }

        [JsonProperty("agencyName")]
        public string agencyName { get; set; }


    }
}