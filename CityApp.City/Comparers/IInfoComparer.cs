using CityApp.City.Enums;
using System.Collections.Generic;

namespace CityApp.City.Comparers
{
    public interface IInfoComparer<T> : IComparer<T>
    {
         SortBy CompareField { get; set; }
    }
}
