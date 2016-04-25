using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using DotNetBay.Core.Execution;
using DotNetBay.Data.EF;
using DotNetBay.SignalR;

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

            AuctionRunner = new AuctionRunner(mainRepository);

            AuctionRunner.Auctioneer.BidAccepted += (sender, args) =>
                { AuctionsHub.NotifyBidAccepted(args.Auction, args.Bid); };

            AuctionRunner.Auctioneer.AuctionStarted += (sender, args) =>
                { AuctionsHub.NotifyAuctionStarted(args.Auction); };

            AuctionRunner.Auctioneer.AuctionEnded += (sender, args) =>
                { AuctionsHub.NotifyAuctionEnded(args.Auction); };

            AuctionRunner.Start();
        }
    }
}
