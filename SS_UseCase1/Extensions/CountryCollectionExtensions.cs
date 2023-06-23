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
    }
}

