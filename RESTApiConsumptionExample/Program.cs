using System;

namespace RESTApiConsumptionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("HttpClient");
            var gitHubHttpClient = new GitHubHttpClient();
            var httpClientResponse = gitHubHttpClient.GetListOfUserRepos("mwalczynski").Result;
            if (httpClientResponse != null)
            {
                foreach (var repo in httpClientResponse)
                {
                    Console.WriteLine($"Name: {repo.Name}, Link: {repo.Url}");
                }
            }
            gitHubHttpClient.Dispose();

            Console.WriteLine("RestSharp");
            var gitHubRestSharp = new GitHubRestSharp();   
            var restSharpResponse = gitHubRestSharp.GetListOfUserRepos("mwalczynski");
            foreach (var repo in restSharpResponse)
            {
                Console.WriteLine($"Name: {repo.Name}, Link: {repo.Url}");
            }

            Console.ReadKey();
        }
    }
}
