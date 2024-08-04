using StoreApp.ViewModel;
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
        }
    }
}
