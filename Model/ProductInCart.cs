using System.Text.Json.Serialization;

namespace StoreApp.Model
{
    public class ProductInCart
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("productFk")]
        public int ProductFK { get; set; }
        [JsonPropertyName("count")]
        public int ProductCount { get; set; }
        [JsonPropertyName("price")]
        public string TotalPrice { get; set; }

        public ProductInCart(int id, int productId, int count, string price)
        {
            Id = id;
            ProductFK = productId;
            ProductCount = count;
            TotalPrice = price;
        }
    }
}
