using StoreApp.ViewModel;
using System;
using System.IO;
using System.Text.Json.Serialization;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;

namespace StoreApp.Model
{
    public class Product
    {
        [JsonPropertyName("id")]
        public int ProductId { get; set; }
        [JsonPropertyName("name")]
        public string ProductName { get; set; }
        [JsonPropertyName("price")]
        public double ProductPrice { get; set; }
        [JsonPropertyName("image")]
        public BitmapImage ProductImage { get; set; }

        public Product(int id, string name, double price, string image)
        {
            ProductId = id;
            ProductName = name;
            ProductPrice = price;
            ProductImage = new BitmapImage(new Uri(Path.Combine(ApplicationData.Current.LocalFolder.Path, image)));
        }
    }
}
