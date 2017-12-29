using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using RESTApiConsumptionExample.Interfaces;
using RESTApiConsumptionExample.Models;

namespace RESTApiConsumptionExample.Implementations
{
    public class GitHubRestSharpClient : IGitHubDataProvider
    {
        public async Task<ICollection<GitHubRepoSimplifiedModel>> GetUserReposAsync(string userName)
        {
            var url = $"https://api.github.com/users/{userName}/repos";
            var client = new RestClient(url);

            var task = new TaskCompletionSource<ICollection<GitHubRepoSimplifiedModel>>();
            client.ExecuteAsync<List<GitHubRepoSimplifiedModel>>(new RestRequest(), response =>
            {
                if (response.ErrorException == null)
                {
                    task.SetResult(response.Data);
                }
                else
                {
                    task.SetResult(new List<GitHubRepoSimplifiedModel>());
                }
            });

            return await task.Task;
        }
    }
}
