using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace RESTApiConsumptionExample
{
    public class GitHubApiHandler : IDisposable
    {
        private readonly HttpClient _httpClient;

        public GitHubApiHandler()
        {
            _httpClient = new HttpClient();
           // _httpClient.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8");
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.84 Safari/537.36");
        }

        public async Task<ICollection<GitHubRepoSimplifiedModel>> GetListOfUserReposByHttpClient(string userName)
        {
            var url = $"https://api.github.com/users/{userName}/repos";
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var listOfRepos = JsonConvert.DeserializeObject<ICollection<GitHubRepoSimplifiedModel>>(content);
                return listOfRepos;
            }

            return null;
        }

        public ICollection<GitHubRepoSimplifiedModel> GetListOfUserReposByRestSharp(string userName)
        {
            var url = $"https://api.github.com/users/{userName}/repos";
            var client = new RestClient(url);
            var response = client.Execute<List<GitHubRepoSimplifiedModel>>(new RestRequest());
            var repos = response.Data;
            return repos;
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
}
