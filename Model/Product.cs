using System.Text.Json.Serialization;

namespace StoreApp.Model
{
    public class Product
    {
        [JsonPropertyName("id")]
        public int ProductId { get; set; }
        [JsonPropertyName("name")]
        public string ProductName { get; set; }
        [JsonPropertyName("price")]
        public string ProductPrice { get; set; }
        [JsonPropertyName("image")]
        public string ProductImage { get; set; }
    }
}
