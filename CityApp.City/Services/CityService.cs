using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CityApp.City.Comparers;
using CityApp.City.Enums;
using CityApp.Common;
using CityApp.Common.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace CityApp.City.Services
{
    public class CityService : ICity
    {
        IConfiguration _configuration;
        IHttpClientFactory _clientFactory;
        IInfoComparer<CityDetail> _cityInfoComparer;

        public CityService(IConfiguration configuration, IHttpClientFactory clientFactory, IInfoComparer<CityDetail> cityInfoComparer)
        {
            _configuration = configuration;
            _clientFactory = clientFactory;
            _cityInfoComparer = cityInfoComparer;
        }


        public async Task<CityDetail> GetCityInfo(string city)
        {
            var appId = _configuration[Constants.ApplicationId];
            var baseUrl = _configuration[Constants.BaseUrl];
            var httpClient = _clientFactory.CreateClient(Constants.cityClient);
            var url = new Uri($"{baseUrl}?q={city}&appid={appId}");

            var response = await httpClient.GetAsync(url).ConfigureAwait(false);
            var result = await response.Content.ReadAsStringAsync();
            
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
                return JsonConvert.DeserializeObject<CityDetail>(result);

            return null;
        }

        public IEnumerable<CityDetail> SortCityInfo(List<CityDetail> cityDetails)
        {
            _cityInfoComparer.CompareField = SortBy.Temperature;
            cityDetails.Sort(_cityInfoComparer);
            return cityDetails;
        }
        
    }
}
