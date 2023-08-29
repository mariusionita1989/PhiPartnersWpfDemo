using PhiPartnersWpfDemo.Dto;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using Newtonsoft.Json;

namespace PhiPartnersWpfDemo.Services
{
    public class HackerNewsWebService : IHackerNewsWebService
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly string _apiBaseUrl;
        private readonly string _bestStoriesUrl;

        public HackerNewsWebService(string apiBaseUrl, string bestStoriesUrl)
        {
            _apiBaseUrl = apiBaseUrl;
            _bestStoriesUrl = bestStoriesUrl;
        }
        public async Task<List<StoryDto>?> GetBestStoriesAsync()
        {
            var response = await _httpClient.GetAsync($"{_apiBaseUrl}{_bestStoriesUrl}");
            List<StoryDto>? result = new List<StoryDto>();
            if (response.IsSuccessStatusCode)
            {

                var json = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(json))
                    result = JsonConvert.DeserializeObject<List<StoryDto>>(json);
            }
            else
                throw new Exception($"Failed to retrieve best stories. Status code: {response.StatusCode}");

            return result;
        }
    }
}
