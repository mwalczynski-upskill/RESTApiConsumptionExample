using System;
using System.Threading.Tasks;

namespace RESTApiConsumptionExample
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Waiting for response...");

            var gitHubHttpClient = new GitHubHttpClient();       
            var httpClientResponse = await gitHubHttpClient.GetListOfUserRepos("mwalczynski");
            var gitHubRestSharp = new GitHubRestSharp();
            var restSharpResponse = await gitHubRestSharp.GetListOfUserRepos("mwalczynski");

            Console.WriteLine("HttpClient");
            foreach (var repo in httpClientResponse)
            {
                Console.WriteLine($"Name: {repo.Name}, Link: {repo.Url}");
            }
            gitHubHttpClient.Dispose();

            Console.WriteLine("RestSharp");      
            foreach (var repo in restSharpResponse)
            {
                Console.WriteLine($"Name: {repo.Name}, Link: {repo.Url}");
            }

            Console.ReadKey();
        }
    }
}
