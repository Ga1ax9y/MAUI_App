using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Stanishewski253505.Entities;


namespace Stanishewski253505.Services
{
     class RateService : IRateService
    {
        private readonly HttpClient _httpClient;
        private readonly List<string> CurAbbreviations = new() { "RUB", "EUR", "USD", "CHF", "CNY", "GBP" };
        public RateService(HttpClient client) 
        {
            _httpClient = client; 
        }
         public IEnumerable<Rate>? GetRates(DateTime date)
        {
            List<Rate> rates = new();
            string url = $"https://api.nbrb.by/exrates/rates?ondate={date:yyyy-MM-dd}&periodicity=0";
            var response = _httpClient.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                rates = JsonSerializer.Deserialize<List<Rate>>(content);
            }
            return rates?.Where(x => CurAbbreviations.Contains(x.Cur_Abbreviation));
        }
    }
}
