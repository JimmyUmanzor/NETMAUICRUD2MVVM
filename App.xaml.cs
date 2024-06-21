using NETMAUICRUD2MVVM.Views;

namespace NETMAUICRUD2MVVM
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ProveedorMain());
        }
    }
}
