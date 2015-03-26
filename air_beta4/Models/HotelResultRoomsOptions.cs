using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace air_beta4.Models
{
    public class HotelResultRoomsOptions
    {
        [JsonProperty("breakfast")]
        public bool breakfast { get; set; }

        [JsonProperty("available")]
        public int available { get; set; }

        [JsonProperty("deposit")]
        public bool deposit { get; set; }

        [JsonProperty("refundable")]
        public bool refundable { get; set; }

        [JsonProperty("cardRequired")]
        public bool cardRequired { get; set; }
    }
}