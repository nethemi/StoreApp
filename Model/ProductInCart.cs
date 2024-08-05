using System.Text.Json.Serialization;

namespace StoreApp.Model
{
    public class ProductInCart
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("cartFk")]
        public int CartFK { get; set; }
        [JsonPropertyName("productFk")]
        public int ProductFK { get; set; }
        [JsonPropertyName("count")]
        public int ProductCount { get; set; }
        [JsonPropertyName("price")]
        public string TotalPrice { get; set; } //price

        public ProductInCart(int id, int cartId, int productId, int count, string price)
        {
            Id = id;
            CartFK = cartId;
            ProductFK = productId;
            ProductCount = count;
            TotalPrice = price;
        }
    }
}
