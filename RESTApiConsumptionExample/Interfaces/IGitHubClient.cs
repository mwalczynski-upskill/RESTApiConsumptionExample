using System.Collections.Generic;
using System.Threading.Tasks;
using RESTApiConsumptionExample.Models;

namespace RESTApiConsumptionExample.Interfaces
{
    public interface IGitHubDataProvider
    {
        Task<IEnumerable<GitHubRepoSimplifiedModel>> GetUserReposAsync(string userName);
    }
}
