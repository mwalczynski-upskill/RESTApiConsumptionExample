using System;
using System.Threading.Tasks;

namespace RESTApiConsumptionExample
{
    public class Program
    {
        static void Main(string[] args)
        {
            Task.Run(async () =>
            {

                Console.WriteLine("HttpClient");
                var gitHubHttpClient = new GitHubHttpClient();
                var httpClientResponse = await gitHubHttpClient.GetListOfUserRepos("mwalczynski");
                foreach (var repo in httpClientResponse)
                {
                    Console.WriteLine($"Name: {repo.Name}, Link: {repo.Url}");
                }
                gitHubHttpClient.Dispose();

                Console.WriteLine("RestSharp");
                var gitHubRestSharp = new GitHubRestSharp();
                var restSharpResponse = await gitHubRestSharp.GetListOfUserRepos("mwalczynski");
                foreach (var repo in restSharpResponse)
                {
                    Console.WriteLine($"Name: {repo.Name}, Link: {repo.Url}");
                }

                Console.ReadKey();

            }).GetAwaiter().GetResult();
        }
    }
}
