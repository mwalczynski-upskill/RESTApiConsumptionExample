using System;

namespace RESTApiConsumptionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var gitHubClientHandler = new GitHubApiHandler();

            Console.WriteLine("HttpClient");
            var httpClientResponse = gitHubClientHandler.GetListOfUserReposByHttpClient("mwalczynski").Result;
            if (httpClientResponse != null)
            {
                foreach (var repo in httpClientResponse)
                {
                    Console.WriteLine($"Name: {repo.Name}, Link: {repo.Url}");
                }
            }

            Console.WriteLine("RestSharp");
            var restSharpResponse = gitHubClientHandler.GetListOfUserReposByRestSharp("mwalczynski");
            foreach (var repo in restSharpResponse)
            {
                Console.WriteLine($"Name: {repo.Name}, Link: {repo.Url}");
            }

            gitHubClientHandler.Dispose();

            Console.ReadKey();
        }
    }
}
