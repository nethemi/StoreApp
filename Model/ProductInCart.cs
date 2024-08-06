using System;
using System.IO;
using System.Text.Json.Serialization;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;

namespace StoreApp.Model
{
    public class ProductInCart
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("product_id")]
        public int ProductFK { get; set; }
        [JsonPropertyName("name")]
        public string ProductName { get; set; }
        [JsonPropertyName("image")]
        public BitmapImage ProductImage { get; set; }
        [JsonPropertyName("count")]
        public int ProductCount { get; set; }
        [JsonPropertyName("price")]
        public double TotalPrice { get; set; }

        public ProductInCart(int id, int fk, string productName, BitmapImage image, int count, double price)
        {
            Id = id;
            ProductFK = fk;
            ProductName = productName;
            ProductImage = image;
            ProductCount = count;
            TotalPrice = price;
        }
    }
}
