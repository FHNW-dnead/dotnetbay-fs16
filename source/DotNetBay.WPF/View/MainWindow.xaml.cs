using System.Windows;

using DotNetBay.Core;
using DotNetBay.WPF.Services;
using DotNetBay.WPF.ViewModel;

namespace DotNetBay.WPF.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();

            var app = Application.Current as App;

            var auctionService = new RemoteAuctionService();

            this.DataContext = new MainViewModel(null, auctionService);
        }
    }
}