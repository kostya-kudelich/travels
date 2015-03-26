using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace air_beta4.Models
{
    public class Coordinates
    {
        [JsonProperty("lon")]
        public double lon { get; set; }

        [JsonProperty("lat")]
        public double lat { get; set; }
    }
}