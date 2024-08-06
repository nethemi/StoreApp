using StoreApp.ViewModel;
using Windows.UI.Xaml.Controls;

namespace StoreApp.View
{
    public sealed partial class CartView : Page
    {
        public CartVM cartVM { get; set; }
        public CartView()
        {
            this.InitializeComponent();
            DataContext = cartVM = new CartVM();
        }
    }
}
