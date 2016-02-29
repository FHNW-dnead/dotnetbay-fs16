using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DotNetBay.Core;
using DotNetBay.Model;

namespace DotNetBay.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Auction> auctions = new ObservableCollection<Auction>();
        private AuctionService auctionService;

        public ObservableCollection<Auction> Auctions
        {
            get { return this.auctions; }
            set
            {
                this.auctions = value;
                this.OnPropertyChanged();
            }
        }

        public MainWindow()
        {
            this.InitializeComponent();

            this.DataContext = this;

            var app = Application.Current as App;
            this.auctionService = new AuctionService(app.MainRepository, new SimpleMemberService(app.MainRepository));

            this.Auctions = new ObservableCollection<Auction>(this.auctionService.GetAll());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
