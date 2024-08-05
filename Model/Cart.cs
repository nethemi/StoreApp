
using System.Text.Json.Serialization;

namespace StoreApp.Model
{
    public class Cart
    {
        [JsonPropertyName("id")]
        public int CartId { get; set; }
        [JsonPropertyName("totalcost")]
        public string TotalCost { get; set; }
    }
}
