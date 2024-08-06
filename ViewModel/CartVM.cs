using CommunityToolkit.Mvvm.Input;
using StoreApp.Model;
using StoreApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Windows.Storage;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace StoreApp.ViewModel
{
    public class CartVM : BaseVM
    {
        public Frame frame = Window.Current.Content as Frame;

        ApplicationDataContainer localParam = ApplicationData.Current.LocalSettings;

        private string selectedParam;
        public string SelectedParam
        {
            get => selectedParam;
            set
            {
                SetProperty(ref selectedParam, value);
                localParam.Values["param"] = value;
            }
        }

        private string message;
        public string Message
        {
            get => message;
            set => SetProperty(ref message, value);
        }

        private int count;
        public int Count
        {
            get => count;
            set => SetProperty(ref count, value);
        }

        private double totalPrice;
        public double TotalPrice
        {
            get => totalPrice;
            set => SetProperty(ref totalPrice, value);
        }

        public List<ProductInCart> products { get; set; }

        #region commands
        private ICommand _DeleteProductCommand;
        public ICommand DeleteProductCommand => this._DeleteProductCommand ?? (this._DeleteProductCommand = new RelayCommand<ProductInCart>(ExecuteDeleteProductCommand));

        private ICommand _AddProductCommand;
        public ICommand AddProductCommand => this._AddProductCommand ?? (this._AddProductCommand = new RelayCommand<ProductInCart>(ExecuteAddProductCommand));

        private ICommand _MinusProductCommand;
        public ICommand MinusProductCommand => this._MinusProductCommand ?? (this._MinusProductCommand = new RelayCommand<ProductInCart>(ExecuteMinusProductCommand));
        #endregion

        private async void ExecuteDeleteProductCommand(ProductInCart product)
        {
            if (product == null) return;

            DataOperation operation = new DataOperation();
            MessageDialog dialog = new MessageDialog("Вы уверены, что хотите удалить товар из корзины?", "Удаление");
            dialog.Commands.Add(new UICommand("Да", null));
            dialog.Commands.Add(new UICommand("Нет", null));
            dialog.DefaultCommandIndex = 1;
            dialog.CancelCommandIndex = 0;
            var cmd = await dialog.ShowAsync();

            if (cmd.Label == "Да")
            {
                TotalPrice -= product.TotalPrice;
                try
                {
                    operation.DeleteProductInCart(product);
                    frame.Navigate(typeof(MainView));
                }
                catch
                {
                    MessageDialog error = new MessageDialog("Произошла ошибка");
                    await error.ShowAsync();
                }
                
            }
        }

        private async void ExecuteAddProductCommand(ProductInCart product)
        {
            if (product == null) return;

            DataOperation operation = new DataOperation();
            try
            {
                operation.UpdateAddProductInCart(product);
                frame.Navigate(typeof(MainView));
            }
            catch
            {
                MessageDialog dialog = new MessageDialog("Произошла ошибка");
                await dialog.ShowAsync();
            }
          
        }

        private async void ExecuteMinusProductCommand(ProductInCart product)
        {
            if (product == null) return;

            DataOperation operation = new DataOperation();
            if (product.ProductCount > 1)
            {
                try
                {
                    operation.UpdateMinusProductInCart(product);
                    frame.Navigate(typeof(MainView));
                }
                catch
                {
                    MessageDialog dialog = new MessageDialog("Произошла ошибка");
                    await dialog.ShowAsync();
                }
            }
            else ExecuteDeleteProductCommand(product);
        }

        public CartVM() 
        {
            products = new List<ProductInCart>();
            Count = 0;
            TotalPrice = 0.0;
            Message = "";
            LoadProductsInCart();
        }

        private void LoadProductsInCart()
        {
            try
            {
                Message = "";

                products.Clear();
                DataOperation data = new DataOperation();
                var list = data.LoadProductsInCart();

                foreach (var item in list)
                {
                    products.Add(item);

                    Count += item.ProductCount;
                    TotalPrice += item.TotalPrice;
                }

            }
            catch
            {
                Message = "Корзина пуста :(";
            }

        }

    }
}
