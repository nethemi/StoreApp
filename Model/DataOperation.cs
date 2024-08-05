using System.Text.Json;
using System.IO;

namespace StoreApp.Model
{
    public class DataOperation
    {
        public async void LoadProducts()
        {
            //using (FileStream fs = new FileStream("Products.json", FileMode.OpenOrCreate))
            //{
            //    List<Product> product = (await JsonSerializer.DeserializeAsync<Product>(fs)).ToList();
            //}

        }

        public async void AddProductInCart(int id, int cart, int product, int count, string price)
        {
            using (FileStream fs = new FileStream("ProductsInCarts.json", FileMode.OpenOrCreate))
            {
                ProductInCart productInCart = new ProductInCart(id, cart, product, count, price);
                await JsonSerializer.SerializeAsync<ProductInCart>(fs, productInCart);
            }
        }
       
    }
   
}