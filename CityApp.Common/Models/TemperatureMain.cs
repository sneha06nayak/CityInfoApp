using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CityApp.Common.Models
{
    public class TemperatureMain
    {
        [JsonProperty("temp")]
        public string Temperature { get; set; }
    }
}
