
using CityApp.City.Enums;
using CityApp.Common.Models;

namespace CityApp.City.Comparers
{
    public class CityInfoComparer: IInfoComparer<CityDetail>
    {
        public SortBy CompareField { get { return SortBy.Temperature; } set { } }

        public int Compare(CityDetail x, CityDetail y)
        {
            switch (CompareField)
            {
                case SortBy.Name:
                    return x.Name.CompareTo(y.Name);
                case SortBy.Id:
                    return x.Id.CompareTo(y.Id);
                case SortBy.Temperature:
                    return x.Main.Temperature.CompareTo(y.Main.Temperature);
                default:
                    return x.Main.Temperature.CompareTo(y.Main.Temperature);
            }
        }
    }
}
