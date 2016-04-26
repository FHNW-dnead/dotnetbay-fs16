using System;

using DotNetBay.Core.Execution;
using DotNetBay.Model;

using Microsoft.AspNet.SignalR.Client;

namespace DotNetBay.WPF.Services
{
    internal class RemoteAuctioneer : IAuctioneer
    {
        private IHubProxy hubProxy;

        private readonly string remoteHubAddress = "http://localhost:52287/";

        public RemoteAuctioneer()
        {
            // TODO: Implement an RemoteAuctioneer with all the Events
            var hubConnection = new HubConnection(this.remoteHubAddress);
            hubConnection.TraceLevel = TraceLevels.All;
            hubConnection.TraceWriter = Console.Out;

            this.hubProxy = hubConnection.CreateHubProxy("AuctionsHub");
            this.WireEvents();

            hubConnection.Start();
        }

        private void WireEvents()
        {
            this.hubProxy.On<Auction>("AuctionStarted", (auction) => this.OnAuctionStarted(new AuctionEventArgs() { Auction = auction }));
            this.hubProxy.On<Auction>("AuctionEnded", (auction) => this.OnAuctionEnded(new AuctionEventArgs() { Auction = auction }));
            this.hubProxy.On<Auction, Bid>("BidAccepted", (auction, bid) => this.OnBidAccepted(new ProcessedBidEventArgs() { Auction = auction, Bid = bid}));
            this.hubProxy.On<Auction, Bid>("BidDeclined", (auction, bid) => this.OnBidDeclined(new ProcessedBidEventArgs() { Auction = auction, Bid = bid}));
        }

        public event EventHandler<AuctionEventArgs> AuctionEnded;
        public event EventHandler<AuctionEventArgs> AuctionStarted;
        public event EventHandler<ProcessedBidEventArgs> BidAccepted;
        public event EventHandler<ProcessedBidEventArgs> BidDeclined;

        protected virtual void OnAuctionEnded(AuctionEventArgs e)
        {
            this.AuctionEnded?.Invoke(this, e);
        }

        protected virtual void OnAuctionStarted(AuctionEventArgs e)
        {
            this.AuctionStarted?.Invoke(this, e);
        }

        protected virtual void OnBidAccepted(ProcessedBidEventArgs e)
        {
            this.BidAccepted?.Invoke(this, e);
        }

        protected virtual void OnBidDeclined(ProcessedBidEventArgs e)
        {
            this.BidDeclined?.Invoke(this, e);
        }
    }
}