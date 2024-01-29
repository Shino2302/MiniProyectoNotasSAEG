using MiniProyectoNotasSAEG.Datos;
using MiniProyectoNotasSAEG.Model;
using MiniProyectoNotasSAEG.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        #endregion

        #region COMANDOS
        public ICommand CambioAVentanaAgregarCommand => new Command(async () => await CambioAVentanaAgregar());
        public ICommand CambioAVentanaModificarCommand => new Command(async () => await CambioAVentanaModificar());
        #endregion

    }
}
