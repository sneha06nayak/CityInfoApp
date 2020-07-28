
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CityApp.Common.Models
{
    public class CityDetail
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("main")]
        public TemperatureMain Main { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
