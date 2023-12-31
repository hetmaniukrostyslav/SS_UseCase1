﻿using System;
using System.Xml.Linq;
using SS_UseCase1.Models;

namespace SS_UseCase1.Extensions
{
    public static class CountryCollectionExtensions
    {
        public static IEnumerable<Country> FilterByName(this IEnumerable<Country> source, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return source;
            }

            return source.Where(x => x.Name.Common.Contains(name, StringComparison.InvariantCultureIgnoreCase));
        }

        public static IEnumerable<Country> FilterByPopulation(this IEnumerable<Country> source, int? population)
        {
            if (!population.HasValue || population == 0)
            {
                return source;
            }

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

        public static IEnumerable<Country> TakeFirst(this IEnumerable<Country> source, int? take)
        {
            if (!take.HasValue)
            {
                return source;
            }

            return source.Take(take.Value);
        }
    }
}

