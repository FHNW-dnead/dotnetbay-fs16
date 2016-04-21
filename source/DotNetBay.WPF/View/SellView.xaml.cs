using System.Windows;

using DotNetBay.Core;
using DotNetBay.WPF.Services;
using DotNetBay.WPF.ViewModel;

namespace DotNetBay.WPF.View
{
    /// <summary>
    /// Interaction logic for SellView.xaml
    /// </summary>
    public partial class SellView : Window
    {
        public SellView()
        {
            this.InitializeComponent();

            var app = Application.Current as App;

            var auctionService = new RemoteAuctionService();

            this.DataContext = new SellViewModel(auctionService);
        }
    }
}