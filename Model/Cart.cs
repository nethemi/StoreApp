
using StoreApp.ViewModel;
using System.Text.Json.Serialization;

namespace StoreApp.Model
{
    public class Cart
    {
        [JsonPropertyName("id")]
        public int CartId { get; set; }
        [JsonPropertyName("totalcost")]
        public string TotalCost { get; set; }

        public Cart(int id, string cost)
        {
            CartId = id;
            TotalCost = cost;
        }
    }
}
