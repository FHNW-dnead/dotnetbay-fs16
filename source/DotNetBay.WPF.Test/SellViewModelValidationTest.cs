using System;
using DotNetBay.Model;
using DotNetBay.WPF.ViewModel;

using NUnit.Framework;

namespace DotNetBay.WPF.Test
{

    public class SellViewModelValidationTest
    {
        [TestCase]
        public void TestValidation()
        {
            SellViewModel viewModel = new SellViewModel(null, null);

            // test for valid value
            Assert.IsFalse(viewModel.AuctionIsValid(new Auction()));

        }
    }
}
