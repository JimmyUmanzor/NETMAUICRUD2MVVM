
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using NETMAUICRUD2MVVM.Models;
using NETMAUICRUD2MVVM.Services;
using NETMAUICRUD2MVVM.Views;
using CommunityToolkit.Mvvm.Input;


namespace NETMAUICRUD2MVVM.ViewModels
{
    public partial class ProveedorMainViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Proveedor> proveedorCollection = new ObservableCollection<Proveedor>();

        private readonly ProveedorService proveedorService;
        public ProveedorMainViewModel()
        {
            proveedorService = new ProveedorService();
        }

        public void GetAll()
        {
            var getAll = proveedorService.GetAll();

            if (getAll?.Count() > 0)
            {
                ProveedorCollection.Clear();
                foreach (var proveedor in getAll)
                {
                    ProveedorCollection.Add(proveedor);
                }

            }
        }

        [RelayCommand]
        private async Task goToAddProveedorForm()
        {
            await App.Current!.MainPage!.Navigation.PushAsync(new AddProveedorForm());
        }

        [RelayCommand]
        private async Task SelectProveedor(Proveedor proveedor)
        {
            try
            {
                string res = await App.Current!.MainPage!.DisplayActionSheet("Opciones", "Cancelar", null, "Actualizar", "Eliminar");
                switch (res)
                {
                    case "Actualizar":
                        await App.Current!.MainPage.Navigation.PushAsync(new AddProveedorForm(proveedor));
                        break;
                    case "Eliminar":
                        bool respuesta = await App.Current!.MainPage!.DisplayAlert("ELIMINAR PROVEEDOR", "¿Desea eliminar el registro del proveedor?", "Si", "No");
                        if (respuesta)
                        {
                            int del = proveedorService.Delete(proveedor);
                            if (del > 0)
                            {
                                ProveedorCollection.Remove(proveedor);

                            }
                        }

                        break;
                }

            }
            catch (Exception ex)
            {
                Alerta("Error", ex.Message);
            }
        }
        private void Alerta(String Titulo, String Mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Titulo, Mensaje, "Aceptar"));
        }
    }
}
