using System;
using System.Threading.Tasks;

namespace RESTApiConsumptionExample
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("HttpClient");
            var gitHubHttpClient = new GitHubHttpClient();
            var httpClientResponse = gitHubHttpClient.GetListOfUserRepos("mwalczynski").Result;
            foreach (var repo in httpClientResponse)
            {
                Console.WriteLine($"Name: {repo.Name}, Link: {repo.Url}");
            }
            gitHubHttpClient.Dispose();

            Console.WriteLine("RestSharp");
            var gitHubRestSharp = new GitHubRestSharp();
            var restSharpResponse = gitHubRestSharp.GetListOfUserRepos("mwalczynski").Result;
            foreach (var repo in restSharpResponse)
            {
                Console.WriteLine($"Name: {repo.Name}, Link: {repo.Url}");
            }

            Console.ReadKey();
        }
    }
}
