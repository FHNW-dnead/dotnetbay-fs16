using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using DotNetBay.Core.Execution;
using DotNetBay.Data.EF;
using DotNetBay.SignalR;
using Newtonsoft.Json;
using Microsoft.AspNet.SignalR;

namespace DotNetBay.WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static IAuctionRunner AuctionRunner { get; private set; }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // DotNetBay startup
            var mainRepository = new EFMainRepository();
            mainRepository.SaveChanges();

            // SignalR Configuration
            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
            serializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;

            var serializer = JsonSerializer.Create(serializerSettings);
            GlobalHost.DependencyResolver.Register(typeof(JsonSerializer), () => serializer);

            AuctionRunner = new AuctionRunner(mainRepository);

            AuctionRunner.Auctioneer.BidAccepted += (sender, args) =>
            #pragma warning disable SA1501 // Statement must not be on a single line
            { AuctionsHub.NotifyBidAccepted(args.Auction, args.Bid); };

            AuctionRunner.Auctioneer.BidDeclined += (sender, args) =>
                { AuctionsHub.NotifyBidDeclined(args.Auction, args.Bid); };

            AuctionRunner.Auctioneer.AuctionStarted += (sender, args) =>
                { AuctionsHub.NotifyAuctionStarted(args.Auction); };

            AuctionRunner.Auctioneer.AuctionEnded += (sender, args) =>
                { AuctionsHub.NotifyAuctionEnded(args.Auction); };

            #pragma warning restore SA1501 // Statement must not be on a single line
            AuctionRunner.Start();
        }
    }
}
