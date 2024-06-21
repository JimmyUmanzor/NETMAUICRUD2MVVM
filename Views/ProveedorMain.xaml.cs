using NETMAUICRUD2MVVM.ViewModels;

namespace NETMAUICRUD2MVVM.Views;

public partial class ProveedorMain : ContentPage
{
    public ProveedorMainViewModel viewModel;

    public ProveedorMain()
    {
        InitializeComponent();
        viewModel = new ProveedorMainViewModel();
        this.BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        viewModel.GetAll();
    }
}