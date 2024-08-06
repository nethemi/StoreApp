using StoreApp.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace StoreApp.ViewModel
{
    public class StoreVM : BaseVM
    {
        public List<Product> products {  get; }

        public StoreVM()
        {
            products = new List<Product>();
            LoadProducts();
        }

        private void LoadProducts()
        {
            try
            {
                products.Clear();
                DataOperation data = new DataOperation();
                var list = data.LoadProducts();
                foreach (var item in list)
                {
                    products.Add(item);
                    Debug.WriteLine(item);
                }
            } 
            catch { 
            
            }
            
        }
    }
}
