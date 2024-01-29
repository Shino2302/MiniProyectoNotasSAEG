using MiniProyectoNotasSAEG.Datos;
using MiniProyectoNotasSAEG.Model;
using MiniProyectoNotasSAEG.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MiniProyectoNotasSAEG.ViewModel
{
    public class ViewModelMainPage : BaseViewModel
    {
        #region VARIABLES
        private ObservableCollection<ModelNotas> _tusNotas;
        private ModelNotas _notaSeleccionada;
        private bool _activador;
        #endregion
        #region CONSTRUCTOR
        public ViewModelMainPage(INavigation navigation)
        {
            Navigation = navigation;
            MostrarNotas();
        }
        #endregion
        #region OBJETOS
        public ObservableCollection<ModelNotas> TusNotas
        {
            get { return _tusNotas;}
            set { SetValue(ref _tusNotas, value);
                OnPropertyChanged();
                }
        }
        public ModelNotas NotaSeleccionada
        {
            get { return _notaSeleccionada; }
            set { SetValue(ref _notaSeleccionada, value); }
        }
        public bool Activador
        {
            get { return _activador; }
            set { SetValue(ref _activador, value); }
        }
        #endregion
        #region PROCESOS
        public async Task CambioAVentanaAgregar()
        {
            await Navigation.PushAsync(new AgregarNota());
        }
        public async Task CambioAVentanaModificar()
        {
            await Navigation.PushAsync(new ModificarEliminarNota(NotaSeleccionada));
        }
        public async void MostrarNotas()
        {
            var funcion = new DatosNotas();
            TusNotas = await funcion.ListarNotas();
        }
        public async Task EliminarNota()
        {
            _activador = true;
            var funcion = new DatosNotas();
            await funcion.EliminarNota(NotaSeleccionada.IdNota);
            await DisplayAlert("Listo!", "Su Nota a sido eliminada exitosamente", "continuar");
        }
        #endregion

        #region COMANDOS
        public ICommand CambioAVentanaAgregarCommand => new Command(async () => await CambioAVentanaAgregar());
        public ICommand CambioAVentanaModificarCommand => new Command(async () => await CambioAVentanaModificar());
        public ICommand EliminarCommand => new Command(async () => await EliminarNota());
        #endregion

    }
}
