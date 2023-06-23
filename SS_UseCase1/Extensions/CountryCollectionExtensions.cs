using System;
using SS_UseCase1.Models;

namespace SS_UseCase1.Extensions
{
	public static class CountryCollectionExtensions
	{
        public static IEnumerable<Country> FilterByName(this IEnumerable<Country> source, string name)
        {
            return source.Where(x => x.Name.Common.Contains(name, StringComparison.InvariantCultureIgnoreCase));
        }

        public static IEnumerable<Country> FilterByPopulation(this IEnumerable<Country> source, int population)
        {
            population *= 1000000;
            return source.Where(x => x.Population <= population);
        }

        public static IEnumerable<Country> SortByName(this IEnumerable<Country> source, string order)
        {
            if(string.IsNullOrWhiteSpace(order))
            {
                return source;
            }

            switch (order)
            {
                case "ascend":
                    return source.OrderBy(x => x.Name.Common);
                case "descend":
                    return source.OrderByDescending(x => x.Name.Common);
                default:
                    throw new ArgumentException(nameof(order));
            }
        }
    }
}

