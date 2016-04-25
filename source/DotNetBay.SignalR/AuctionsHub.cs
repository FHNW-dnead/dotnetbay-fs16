using Microsoft.AspNet.SignalR;
using DotNetBay.Model;

namespace DotNetBay.SignalR
{
    public class AuctionsHub : Hub
    {
        public static void NotifyNewAuction(Auction auction)
        {
            GlobalHost.ConnectionManager.GetHubContext<AuctionsHub>().Clients.All.NewAuction(auction.Id);
        }

        public static void NotifyBidAccepted(Auction auction, Bid bid)
        {
            GlobalHost.ConnectionManager.GetHubContext<AuctionsHub>().Clients.All.NotifyBidAccepted(auction.Id, bid.Id);
        }

        public static void NotifyAuctionStarted(Auction auction)
        {
            GlobalHost.ConnectionManager.GetHubContext<AuctionsHub>().Clients.All.NotifyAuctionStarted(auction.Id);
        }

        public static void NotifyAuctionEnded(Auction auction)
        {
            GlobalHost.ConnectionManager.GetHubContext<AuctionsHub>().Clients.All.NotifyAuctionEnded(auction.Id);
        }

    }
}
