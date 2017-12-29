using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RESTApiConsumptionExample.Models;

namespace RESTApiConsumptionExample.Interfaces
{
    public interface IGitHubDataProvider
    {
        Task<ICollection<GitHubRepoSimplifiedModel>> GetUserReposAsync(string userName);
    }
}
