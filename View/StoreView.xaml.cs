using StoreApp.ViewModel;
using Windows.UI.Xaml.Controls;

namespace StoreApp.View
{
    public sealed partial class StoreView : Page
    {
        public StoreVM storeVM { get; set; }
        public StoreView()
        {
            this.InitializeComponent();
            storeVM = new StoreVM();
        }
    }
}
