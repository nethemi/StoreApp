using System.Text.Json;
using System.IO;
using System.Collections.Generic;
using Windows.Storage;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Linq;

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
            }
            return allProducts;
        }

        public async void AddProductInCart(int id, int product, string price)
        {
            if (IsProductInCart(id))
            {
               int count = GetProductInCart(id).ProductCount + 1;
            }
            else
            {
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    ProductInCart productInCart = new ProductInCart(id, product, 1, price);
                    await JsonSerializer.SerializeAsync<ProductInCart>(fs, productInCart);
                }
            }         
        }

        public async void UpdateProductInCart(int id, int product, int count, string price)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                JObject jsonObj = JObject.Parse(path);
                //jsonObj[id-1]. = 
                //await JsonSerializer.SerializeAsync<ProductInCart>(fs, productInCart);
            }
        }

        public List<ProductInCart> LoadProductsInCart()
        {
            List<ProductInCart> allProducts = new List<ProductInCart>();
            using (StreamReader file = File.OpenText(path))
            {
                var json = file.ReadToEnd();
                Dictionary<string, object> result = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
                string product = result["ProductsInCarts"].ToString();
                allProducts = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ProductInCart>>(product);
            }
            return allProducts;
        }

        public int GetLastProductInCart()
        {
            int id;
            var products = LoadProductsInCart();
            id = products.LastOrDefault().Id;
            return id;
        }

        public ProductInCart GetProductInCart(int id)
        {
           return LoadProductsInCart().Where(x => x.Id == id).First();
        }

        public bool IsProductInCart(int id)
        {
            if (GetProductInCart(id) != null) return true;
            else return false;
        }
    }
   
}