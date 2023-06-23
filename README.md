# SS_UseCase1 Application

## Description

SS_UseCase1 is a dynamic web application built on ASP.NET Core. It offers a simple, yet robust, country lookup service, enabling users to fetch data related to various countries. Utilizing modern programming paradigms like dependency injection and asynchronous operations, the application ensures efficient and highly performant service. It fetches data from an external API (https://restcountries.com/v3.1/all), then filters, sorts, and limits the data based on the parameters received in the request. The application's service offers functionalities like searching by country name, filtering by population, sorting, and limiting the number of results.

The `CountryController` class, the heart of this application, processes the incoming HTTP requests. The method `GetCountriesAsync`, decorated with the `[HttpGet("list")]` attribute, serves as the service endpoint. This method takes optional parameters from the query string and header — `name`, `population`, `order`, and `take` respectively, to fetch, filter, sort, and slice the data before responding to the client. These operations are performed asynchronously, contributing to the service's high performance.

## Running the Application Locally

1. Clone the repository to your local machine.
2. Ensure that the .NET Core SDK is installed (requires .NET Core 5.0 or later).
3. Navigate to the cloned repository's root directory using the terminal or command prompt.
4. Use `dotnet run` command to run the application.

## Example URLs

Below are some example URLs to test the application's endpoint:

1. Fetch all countries: `http://localhost:5000/country/list`
2. Search country by name: `http://localhost:5000/country/list?name=France`
3. Filter countries by population: `http://localhost:5000/country/list?population=50000000` (finds countries with a population of at least 50,000,000)
4. Sort countries by name in ascending order: `http://localhost:5000/country/list?order=asc`
5. Sort countries by name in descending order: `http://localhost:5000/country/list?order=desc`
6. Limit the number of results: Add `take: 5` in your request header to limit the results to 5 countries.
7. Search country by name and sort in ascending order: `http://localhost:5000/country/list?name=India&order=asc`
8. Filter by population and limit results: `http://localhost:5000/country/list?population=10000000` with `take: 3` in your request header.
9. Combination of all parameters: `http://localhost:5000/country/list?name=United&population=10000000&order=desc` with `take: 2` in your request header.
10. Fetch all countries with a specific starting name and population: `http://localhost:5000/country/list?name=Can&population=35000000` 

Remember to replace `localhost:5000` with your application's host and port.

**Note:** For limiting the number of results, include `take` in your request header and set its value to the desired limit. For instance, `take: 5`.
