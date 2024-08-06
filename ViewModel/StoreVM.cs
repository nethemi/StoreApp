using CommunityToolkit.Mvvm.Input;
using StoreApp.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace StoreApp.ViewModel
{
    public class StoreVM : BaseVM
    {
        private string message;
        public string Message
        {
            get => message;
            set => SetProperty(ref message, value);
        }

        public List<Product> products {  get; }

        private ICommand _AddProductCommand;
        public ICommand AddProductCommand => this._AddProductCommand ?? (this._AddProductCommand = new RelayCommand<Product>(ExecuteAddProductCommand));

        private void ExecuteAddProductCommand(Product product)
        {
            if (product == null) return;

            DataOperation operation = new DataOperation();
            var inCart = operation.LoadProductsInCart().Where(x => x.ProductFK == product.ProductId);
            
            if (inCart.Count() <= 0) operation.AddProductInCart(product);
            else operation.UpdateAddProductInCart(inCart.First());
        }

        public StoreVM()
        {
            products = new List<Product>();
            Message = "";
            LoadProducts();
        }

        private void LoadProducts()
        {
            try
            {
                Message = "";
                products.Clear();
                DataOperation data = new DataOperation();
                var list = data.LoadProducts();
                foreach (var item in list)
                {
                    products.Add(item);
                }
            } 
            catch 
            {
                Message = "Невозможно загрузить товары :(";
            }
            
        }
    }
}
