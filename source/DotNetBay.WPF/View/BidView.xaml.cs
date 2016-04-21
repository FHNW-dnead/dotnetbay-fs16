using System.Windows;

using DotNetBay.Core;
using DotNetBay.Model;
using DotNetBay.WPF.ViewModel;
using DotNetBay.WPF.Services;

namespace DotNetBay.WPF.View
{
    /// <summary>
    /// Interaction logic for SellView.xaml
    /// </summary>
    public partial class BidView : Window
    {
        public BidView(Auction selectedAuction)
        {
            this.InitializeComponent();

            var app = Application.Current as App;

            var auctionService = new RemoteAuctionService();

            this.DataContext = new BidViewModel(selectedAuction, auctionService);
        }
    }
}