using NETMAUICRUD2MVVM.Models;
using NETMAUICRUD2MVVM.ViewModels;

namespace NETMAUICRUD2MVVM.Views;

public partial class AddProveedorForm : ContentPage
{

    private AddProveedorFormViewModel viewModel;
    public AddProveedorForm()
    {
        InitializeComponent();
        viewModel = new AddProveedorFormViewModel();
        BindingContext = viewModel;
    }

    public AddProveedorForm(Proveedor proveedor)
    {
        InitializeComponent();
        viewModel = new AddProveedorFormViewModel(proveedor);
        BindingContext = viewModel;
    }
}