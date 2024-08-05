using StoreApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.ServiceModel.Channels;
using Windows.System;
using Windows.UI.Core.Preview;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace StoreApp.View
{
    public sealed partial class MainView : Page
    {
        public MainVM mainVM { get; set; }
        public MainView()
        {
            this.InitializeComponent();
            mainVM = new MainVM();

            SystemNavigationManagerPreview.GetForCurrentView().CloseRequested += CloseHandle;
        }

        private async void CloseHandle(object sender, SystemNavigationCloseRequestedPreviewEventArgs e)
        {
            e.Handled = true;
            MessageDialog dialog = new MessageDialog("Вы уверены, что хотите выйти?", "Выход из приложения");
            dialog.Commands.Add(new UICommand("Да", null));
            dialog.Commands.Add(new UICommand("Нет", null));
            dialog.DefaultCommandIndex = 1;
            dialog.CancelCommandIndex = 0;
            var cmd = await dialog.ShowAsync();

            if (cmd.Label == "Да")
            {
                App.Current.Exit();
            }
        }
    }
}
