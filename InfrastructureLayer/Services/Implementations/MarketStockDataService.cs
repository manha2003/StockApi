using ApplicationLayer.DTOs.Stock;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace InfrastructureLayer.Services.Implementations
{
    public class MarketStockDataService
    {
        private readonly HttpClient _httpClient;
        private readonly string _alphaAvantageApiKey;
        private readonly string _finhubApiKey;

        public MarketStockDataService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _alphaAvantageApiKey = configuration["AlphaAvantageApiKey"];
            _finhubApiKey = configuration["FinhubApiKey"];
        }

        public async Task<CompanyOverviewDto?> GetCompanyOverviewAsync(string symbol)
        {
            var url = $"https://www.alphavantage.co/query?function=OVERVIEW&symbol={symbol}&apikey={_alphaAvantageApiKey}";
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
