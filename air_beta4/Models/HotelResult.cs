using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace air_beta4.Models
{
    public class HotelResult
    {
        [JsonProperty("status")]
        public string status { get; set; }

        [JsonProperty("result")]
        public List<Hotel> result { get; set; }


    }
}