using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;

namespace RESTApiConsumptionExample
{
    public class GitHubRestSharp
    {
        public ICollection<GitHubRepoSimplifiedModel> GetListOfUserRepos(string userName)
        {
            var url = $"https://api.github.com/users/{userName}/repos";
            var client = new RestClient(url);
            var response = client.Execute<List<GitHubRepoSimplifiedModel>>(new RestRequest());
            var repos = response.Data;
            return repos;
        }
    }
}
