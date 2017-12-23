using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace RESTApiConsumptionExample
{
    public class GitHubRestSharp
    {
        public async Task<ICollection<GitHubRepoSimplifiedModel>> GetListOfUserRepos(string userName)
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
