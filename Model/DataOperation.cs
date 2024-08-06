using System.Text.Json;
using System.IO;
using System.Collections.Generic;
using Windows.Storage;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace StoreApp.Model
{
    public class DataOperation
    {
        public string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, "Data.json");
        public List<Product> LoadProducts()
        {
            List<Product> allProducts = new List<Product>();
            using (StreamReader file = File.OpenText(path))
            {
                var json = file.ReadToEnd();
                Dictionary<string, object> result = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
                string product = result["Products"].ToString();
                allProducts = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Product>>(product);
                foreach (var item in allProducts)
                {
                    Debug.WriteLine(item.ProductImage);
                }
            }
            return allProducts;
        }

        public async void AddProductInCart(int id, int cart, int product, int count, string price)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                ProductInCart productInCart = new ProductInCart(id, cart, product, count, price);
                await JsonSerializer.SerializeAsync<ProductInCart>(fs, productInCart);
            }
        }

        public async void UpdateProductInCart(int id, int cart, int product, int count, string price)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                JObject jsonObj = JObject.Parse(path);
                //jsonObj[id-1]. = 
                //await JsonSerializer.SerializeAsync<ProductInCart>(fs, productInCart);
            }
        }

    }
   
}