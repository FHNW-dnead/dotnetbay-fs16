using Microsoft.AspNet.SignalR;
using DotNetBay.Model;
using System;

namespace DotNetBay.SignalR
{
    public class AuctionsHub : Hub
    {
        public static void NotifyNewAuction(Auction auction)
        {
            GlobalHost.ConnectionManager.GetHubContext<AuctionsHub>().Clients.All.NewAuction(auction);
        }

        public static void NotifyNewBid(Auction auction, Bid newBid)
        {
            GlobalHost.ConnectionManager.GetHubContext<AuctionsHub>().Clients.All.NewBid(auction);
        }

        public static void NotifyBidAccepted(Auction auction, Bid bid)
        {
            GlobalHost.ConnectionManager.GetHubContext<AuctionsHub>().Clients.All.BidAccepted(auction, bid);
        }

        public static void NotifyBidDeclined(Auction auction, Bid bid)
        {
            GlobalHost.ConnectionManager.GetHubContext<AuctionsHub>().Clients.All.BidDeclined(auction, bid);
        }

        public static void NotifyAuctionStarted(Auction auction)
        {
            GlobalHost.ConnectionManager.GetHubContext<AuctionsHub>().Clients.All.AuctionStarted(auction);
        }

        public static void NotifyAuctionEnded(Auction auction)
        {
            GlobalHost.ConnectionManager.GetHubContext<AuctionsHub>().Clients.All.AuctionEnded(auction);
        }
    }
}
