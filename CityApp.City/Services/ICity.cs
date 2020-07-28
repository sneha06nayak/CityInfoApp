
using CityApp.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CityApp.City.Services
{
    public interface ICity
    {
        Task<CityDetail> GetCityInfo(string city);
        IEnumerable<CityDetail> SortCityInfo(List<CityDetail> cityDetails);
    }
}
