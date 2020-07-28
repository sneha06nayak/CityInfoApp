using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CityApp.Common.Models
{
    class CityInfoResponse
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("temp")]
        public string Temperature { get; set; }

        [JsonProperty("index")]
        public string Id { get; set; }
    }
}
