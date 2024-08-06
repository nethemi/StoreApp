using System.IO;
using System.Collections.Generic;
using Windows.Storage;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Linq;
using Newtonsoft.Json;
using System;

namespace StoreApp.Model
{
    public class DataOperation
    {
        public string pathProduct = Path.Combine(ApplicationData.Current.LocalFolder.Path, "Products.json");
        public string pathCart = Path.Combine(ApplicationData.Current.LocalFolder.Path, "ProductsInCarts.json");
        public List<Product> LoadProducts()
        {
            List<Product> allProducts = new List<Product>();
            using (StreamReader file = File.OpenText(pathProduct))
            {
                var json = file.ReadToEnd();
                allProducts = JsonConvert.DeserializeObject<List<Product>>(json);
            }
            return allProducts;
        }

        public void AddProductInCart(Product product)
        {
            int id = GetLastProductInCart() + 1;
            var cart = LoadProductsInCart();

            ProductInCart productInCart = new ProductInCart(id, product.ProductId, product.ProductName, product.ProductImage, 1, product.ProductPrice);
            cart.Add(productInCart);

            string newCart = JsonConvert.SerializeObject(cart, Formatting.Indented);
            File.WriteAllText(pathCart, newCart);
        }

        public void UpdateAddProductInCart(ProductInCart productInCart)
        {
            var product = GetProduct(productInCart.ProductFK);
            productInCart.ProductCount += 1;

            double price = product.ProductPrice;
            price *= productInCart.ProductCount;
            productInCart.TotalPrice = price;

            var cart = LoadProductsInCart();
            cart[productInCart.Id - 1] = productInCart;

            string newCart = JsonConvert.SerializeObject(cart, Formatting.Indented);
            File.WriteAllText(pathCart, newCart);
        }

        public void UpdateMinusProductInCart(ProductInCart productInCart)
        {
            var product = GetProduct(productInCart.ProductFK);
            productInCart.ProductCount -= 1;

            double price = product.ProductPrice;
            price *= productInCart.ProductCount;
            productInCart.TotalPrice = price;

            var cart = LoadProductsInCart();
            cart[productInCart.Id - 1] = productInCart;

            string newCart = JsonConvert.SerializeObject(cart, Formatting.Indented);
            File.WriteAllText(pathCart, newCart);
        }

        public void DeleteProductInCart(ProductInCart productInCart)
        {
            var cart = LoadProductsInCart();
            cart.RemoveAt(productInCart.Id - 1);
            string newCart = JsonConvert.SerializeObject(cart, Formatting.Indented);
            File.WriteAllText(pathCart, newCart);
        }

        public List<ProductInCart> LoadProductsInCart()
        {
            List<ProductInCart> allProducts = new List<ProductInCart>();
            using (StreamReader file = File.OpenText(pathCart))
            {
                var json = file.ReadToEnd();
                allProducts = JsonConvert.DeserializeObject<List<ProductInCart>>(json);
            }
            return allProducts;
        }

        public int GetLastProductInCart()
        {
            var products = LoadProductsInCart();
            if (products.LastOrDefault() == null) return 0;
            return products.LastOrDefault().Id;
        }

        public ProductInCart GetProductInCart(int id)
        {
           return LoadProductsInCart().Where(x => x.Id == id).First();
        }

        public Product GetProduct(int id)
        {
            return LoadProducts().Where(x => x.ProductId == id).First();
        }

        public bool IsProductInCart(int id)
        {
            Debug.WriteLine(GetProductInCart(id));
            if (GetProductInCart(id) != null) return true;
            else return false;
        }
    }
   
}