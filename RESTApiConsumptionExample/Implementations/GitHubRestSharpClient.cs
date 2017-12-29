using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using RESTApiConsumptionExample.Interfaces;
using RESTApiConsumptionExample.Models;

namespace RESTApiConsumptionExample.Implementations
{
    public class GitHubRestSharpClient : IGitHubDataProvider
    {
        public async Task<IEnumerable<GitHubRepoSimplifiedModel>> GetUserReposAsync(string userName)
        {
            var url = $"https://api.github.com/users/{userName}/repos";
            var client = new RestClient(url);

            var task = new TaskCompletionSource<IEnumerable<GitHubRepoSimplifiedModel>>();
            client.ExecuteAsync<List<GitHubRepoSimplifiedModel>>(new RestRequest(), response =>
            {
                if (response.ErrorException == null)
                {
                    task.SetResult(response.Data);
                }
                else
                {
                    task.SetResult(Enumerable.Empty<GitHubRepoSimplifiedModel>());
                }
            });

            return await task.Task;
        }
    }
}
