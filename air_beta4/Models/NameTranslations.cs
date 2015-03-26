using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace air_beta4.Models
{
    public class NameTranslations
    {
        [JsonProperty("de")]
        public string de { get; set; }

        [JsonProperty("en")]
        public string en { get; set; }

        [JsonProperty("zh-CN")]
        public string zh_CN { get; set; }

        [JsonProperty("tr")]
        public string tr { get; set; }

        [JsonProperty("ru")]
        public string ru { get; set; }

        [JsonProperty("fr")]
        public string fr { get; set; }

        [JsonProperty("es")]
        public string es { get; set; }

        [JsonProperty("it")]
        public string it { get; set; }

        [JsonProperty("th")]
        public string th { get; set; }
    }
}