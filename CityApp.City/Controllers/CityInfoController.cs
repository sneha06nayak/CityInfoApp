using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityApp.City.Services;
using CityApp.Common.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CityApp.City.Controllers
{
    [ApiController]
    public class CityInfoController : ControllerBase
    {
        ILogger<CityInfoController> _logger;
        ICity _cityInfoService;

        public CityInfoController(ILogger<CityInfoController> logger, ICity cityInfoService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _cityInfoService = cityInfoService;
        }

        /// <summary>
        /// Returns information on temperature for the cities passed
        /// </summary>
        /// <param name="cities"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/cities/temperatures")]
        public async Task<IActionResult> GetTemperature(string cities)
        {
           var cityList = cities.Split(',');
           List<CityDetail> cityDetails = new List<CityDetail>();

           foreach(var city in cityList)
           {
                var cityInfo = await _cityInfoService.GetCityInfo(city);
                if(cityInfo != null)
                  cityDetails.Add(cityInfo);
           }
           if(cityDetails.Count > 0)
            return Ok(_cityInfoService.SortCityInfo(cityDetails).ToList());
           return NoContent();
        }
    }
}
