namespace SS_UseCase1.Tests;

using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using SS_UseCase1.Models;
using SS_UseCase1.Extensions;

public class CountryCollectionExtensionsTests
{
    private List<Country> GetDummyCountries()
    {
        return new List<Country>
        {
            new Country { Name = new Name { Common = "Country1" }, Population = 10000000 },
            new Country { Name = new Name { Common = "Country2" }, Population = 20000000 },
            new Country { Name = new Name { Common = "Country3" }, Population = 30000000 }
        };
    }

    [Fact]
    public void FilterByName_ValidName_ReturnsFilteredCountries()
    {
        // Arrange
        var countries = GetDummyCountries();

        // Act
        var result = countries.FilterByName("Country1");

        // Assert
        Assert.Single(result);
        Assert.Equal("Country1", result.First().Name.Common);
    }

    [Fact]
    public void FilterByPopulation_ValidPopulation_ReturnsFilteredCountries()
    {
        // Arrange
        var countries = GetDummyCountries();

        // Act
        var result = countries.FilterByPopulation(20); // Assuming the population is in millions

        // Assert
        Assert.Equal(2, result.Count());
        Assert.Contains(result, x => x.Name.Common == "Country1");
        Assert.Contains(result, x => x.Name.Common == "Country2");
    }

    [Fact]
    public void SortByName_ValidOrder_ReturnsSortedCountries()
    {
        // Arrange
        var countries = GetDummyCountries();

        // Act
        var result = countries.SortByName("ascend");

        // Assert
        Assert.Equal("Country1", result.First().Name.Common);
    }

    [Fact]
    public void TakeFirst_ValidNumber_ReturnsFirstNCountries()
    {
        // Arrange
        var countries = GetDummyCountries();

        // Act
        var result = countries.TakeFirst(2);

        // Assert
        Assert.Equal(2, result.Count());
    }

    // Tests for FilterByName
    [Fact]
    public void FilterByName_NullName_ReturnsAllCountries()
    {
        // Arrange
        var countries = GetDummyCountries();

        // Act
        var result = countries.FilterByName(null);

        // Assert
        Assert.Equal(3, result.Count());
    }

    [Fact]
    public void FilterByName_EmptyName_ReturnsAllCountries()
    {
        // Arrange
        var countries = GetDummyCountries();

        // Act
        var result = countries.FilterByName("");

        // Assert
        Assert.Equal(3, result.Count());
    }

    [Fact]
    public void FilterByName_WhiteSpaceName_ReturnsAllCountries()
    {
        // Arrange
        var countries = GetDummyCountries();

        // Act
        var result = countries.FilterByName(" ");

        // Assert
        Assert.Equal(3, result.Count());
    }

    // Tests for FilterByPopulation
    [Fact]
    public void FilterByPopulation_NullPopulation_ReturnsAllCountries()
    {
        // Arrange
        var countries = GetDummyCountries();

        // Act
        var result = countries.FilterByPopulation(null);

        // Assert
        Assert.Equal(3, result.Count());
    }

    [Fact]
    public void FilterByPopulation_ZeroPopulation_ReturnsAllCountries()
    {
        // Arrange
        var countries = GetDummyCountries();

        // Act
        var result = countries.FilterByPopulation(0);

        // Assert
        Assert.Equal(3, result.Count());
    }

    // Tests for SortByName
    [Fact]
    public void SortByName_NullOrder_ReturnsSameOrder()
    {
        // Arrange
        var countries = GetDummyCountries();

        // Act
        var result = countries.SortByName(null);

        // Assert
        Assert.Equal("Country1", result.First().Name.Common);
    }

    [Fact]
    public void SortByName_EmptyOrder_ReturnsSameOrder()
    {
        // Arrange
        var countries = GetDummyCountries();

        // Act
        var result = countries.SortByName("");

        // Assert
        Assert.Equal("Country1", result.First().Name.Common);
    }

    [Fact]
    public void SortByName_WhiteSpaceOrder_ReturnsSameOrder()
    {
        // Arrange
        var countries = GetDummyCountries();

        // Act
        var result = countries.SortByName(" ");

        // Assert
        Assert.Equal("Country1", result.First().Name.Common);
    }

    [Fact]
    public void SortByName_InvalidOrder_ThrowsArgumentException()
    {
        // Arrange
        var countries = GetDummyCountries();

        // Act & Assert
        Assert.Throws<ArgumentException>(() => countries.SortByName("invalid"));
    }

    // Tests for TakeFirst
    [Fact]
    public void TakeFirst_NullNumber_ReturnsAllCountries()
    {
        // Arrange
        var countries = GetDummyCountries();

        // Act
        var result = countries.TakeFirst(null);

        // Assert
        Assert.Equal(3, result.Count());
    }

    [Fact]
    public void TakeFirst_NegativeNumber_ReturnsEmptySequence()
    {
        // Arrange
        var countries = GetDummyCountries();

        // Act
        var result = countries.TakeFirst(-1);

        // Assert
        Assert.Empty(result);
    }
}
