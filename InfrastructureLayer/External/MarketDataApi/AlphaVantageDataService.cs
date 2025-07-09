using ApplicationLayer.DTOs.Stock;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace InfrastructureLayer.External.MarketDataApi
{
    public class AlphaVantageDataService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public AlphaVantageDataService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration.GetSection("AlphaVantage")["ApiKey"];
        }

        public async Task<CompanyOverviewDto?> GetCompanyOverviewAsync(string symbol)
        {
            var url = $"https://www.alphavantage.co/query?function=OVERVIEW&symbol={symbol}&apikey={_apiKey}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var json = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            return JsonSerializer.Deserialize<CompanyOverviewDto>(json, options);
        }
    }
}
