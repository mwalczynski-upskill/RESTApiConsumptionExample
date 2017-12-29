using System;
using System.Threading.Tasks;
using RESTApiConsumptionExample.Implementations;

namespace RESTApiConsumptionExample
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var userName = "mwalczynski";
            var gitHubHttpClient = new GitHubHttpClient();       
            var httpClientResponse = gitHubHttpClient.GetUserReposAsync(userName);
            var gitHubRestSharp = new GitHubRestSharpClient();
            var restSharpResponse = gitHubRestSharp.GetUserReposAsync(userName);

            Console.WriteLine("HttpClient");
            foreach (var repo in await httpClientResponse)
            {
                Console.WriteLine($"Name: {repo.Name}, Link: {repo.Url}");
            }
            gitHubHttpClient.Dispose();

            Console.WriteLine("RestSharp");      
            foreach (var repo in await restSharpResponse)
            {
                Console.WriteLine($"Name: {repo.Name}, Link: {repo.Url}");
            }

            Console.ReadKey();
        }
    }
}
