using Microsoft.Owin.Hosting;
using System;

using DotNetBay.WebApi;

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

            Console.WriteLine("DotNetBay SelfHost");

            using (WebApp.Start<Startup>(url: "http://localhost:9001/"))
            {


                Console.ReadLine();
            }
        }
    }
}
