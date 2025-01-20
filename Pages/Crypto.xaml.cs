using StockScreener.Models1;
using StockScreener.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockScreener.Pages
{
    public partial class Crypto : ContentPage
    {
        private readonly DatabaseService _databaseService;

        public Crypto()
        {
            InitializeComponent();
            _databaseService = new DatabaseService();
            LoadStocks();
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            var stock = new Stock
            {
                Symbol = SymbolEntry.Text,
                Name = NameEntry.Text,
                Description = DescriptionEditor.Text,
                CreatedAt = DateTime.Now
            };

            _databaseService.SaveStock(stock);
            await DisplayAlert("Success", "Stock information saved.", "OK");
            LoadStocks();
        }

        private void LoadStocks()
        {
            var stocks = _databaseService.GetStocks();
            StocksCollectionView.ItemsSource = stocks;
        }
    }
}
