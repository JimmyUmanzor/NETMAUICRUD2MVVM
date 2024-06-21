
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NETMAUICRUD2MVVM.Models;
using NETMAUICRUD2MVVM.Services;

namespace NETMAUICRUD2MVVM.ViewModels
{
    public partial class AddProveedorFormViewModel : ObservableObject
    {
        [ObservableProperty]
        private int idProperty;

        [ObservableProperty]
        private string nombreProperty;

        [ObservableProperty]
        private string direccionProperty;

        [ObservableProperty]
        private string telefonoProperty;

        [ObservableProperty]
        private string correoProperty;


        private readonly ProveedorService proveedorService;

        public AddProveedorFormViewModel()
        {
            proveedorService = new ProveedorService();
        }

        public AddProveedorFormViewModel(Proveedor proveedor)
        {
            IdProperty = proveedor.Id;
            NombreProperty = proveedor.Nombre;
            DireccionProperty = proveedor.Direccion;
            TelefonoProperty = proveedor.Telefono;
            CorreoProperty = proveedor.Correo;


            proveedorService = new ProveedorService();
        }

        private void Alerta(String Titulo, String Mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Titulo, Mensaje, "Aceptar"));
        }

        [RelayCommand]
        private async Task AddUpdate()
        {
            try
            {
                Proveedor proveedor = new Proveedor
                {
                    Id = idProperty,
                    Nombre = nombreProperty,
                    Direccion = direccionProperty,
                    Telefono = telefonoProperty,
                    Correo = correoProperty
                };

                if (Validar(proveedor))
                {
                    if (IdProperty == 0)
                    {
                        proveedorService.Insert(proveedor);
                    }
                    else
                    {
                        proveedorService.Update(proveedor);
                    }
                    await App.Current!.MainPage!.Navigation.PopAsync();

                }


            }
            catch (Exception ex)
            {
                Alerta("ERROR", ex.Message);
            }
        }

        private bool Validar(Proveedor proveedor)
        {
            if (proveedor.Nombre == null || proveedor.Nombre == "")
            {
                Alerta("ADVERTENCIA", "Ingrese el nombre del proveedor");
                return false;
            }
            else if (proveedor.Direccion == null || proveedor.Direccion == "")
            {
                Alerta("ADVERTENCIA", "Ingrese la dirección del proveedor");
                return false;
            }
            else if (proveedor.Telefono == null || proveedor.Telefono == "")
            {
                Alerta("ADVERTENCIA", "Ingrese el teléfono del proveedor");
                return false;
            }else if (proveedor.Correo == null || proveedor.Correo == "")
            {
                Alerta("ADVERTENCIA", "Ingrese el teléfono del proveedor");
                return false;
            }
            else
            {
                return true;
            }

        }
    }
}

