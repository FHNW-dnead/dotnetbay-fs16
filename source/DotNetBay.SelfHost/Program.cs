using Microsoft.Owin.Hosting;
using System;

using DotNetBay.WebApi;
using DotNetBay.WebApi.Controller;
using System.Net.Http;

namespace DotNetBay.SelfHost
{
    /// <summary>
    /// Main Entry for program
    /// </summary>
    public static class Program
    {
        public static void Main()
        {
            var type = typeof(StatusController);

            var host = "http://localhost:9001/";

            using (WebApp.Start<Startup>(url: host))
            {
                // SelfCheck
                var client = new HttpClient();
                client.BaseAddress = new Uri(host);

                var response = client.GetAsync("/api/status").Result;

                Console.WriteLine(response);

                Console.Write("Press enter to quit.");
                Console.ReadLine();
            }
        }
    }
}
