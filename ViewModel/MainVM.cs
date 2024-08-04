﻿using CommunityToolkit.Mvvm.Input;
using StoreApp.View;
using System;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace StoreApp.ViewModel
{
    public class MainVM : BaseVM
    {
        public Frame frame = new Frame();

        private ICommand _ItemInvokedCommand;
        public ICommand ItemInvokedCommand => this._ItemInvokedCommand ?? (this._ItemInvokedCommand = new RelayCommand<NavigationViewItemInvokedEventArgs>(OnItemInvoked));

        public MainVM()
        {
            OnItemInvoked(null);
        }

        private void OnItemInvoked(NavigationViewItemInvokedEventArgs args)
        {
            if (args != null) 
            {
                var item = args.InvokedItemContainer.Tag.ToString();

                switch (item)
                {
                    case "shop": frame.Navigate(typeof(StoreView)); break;
                    case "cart": frame.Navigate(typeof(CartView)); break;
                    case "exit": App.Current.Exit(); break;
                }
            }
            else frame.Navigate(typeof(StoreView));
        }
    }
}
   