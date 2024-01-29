using MiniProyectoNotasSAEG.Model;
using MiniProyectoNotasSAEG.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using MiniProyectoNotasSAEG.Datos;

namespace MiniProyectoNotasSAEG.ViewModel
{
    public class ViewModelModificarEliminarNota : BaseViewModel
    {
        #region VARIABLES
        private string _titulo;
        private string _nota;
        private ModelNotas _notaElegida;
        #endregion
        #region CONSTRUCTOR
        public ViewModelModificarEliminarNota(INavigation navigation, ModelNotas notaSeleccionada)
        {
            Navigation = navigation;
            _titulo = notaSeleccionada.TituloNota;
            _nota = notaSeleccionada.Nota;
            _notaElegida = notaSeleccionada;
        }
        #endregion
        #region OBJETOS
        public string Titulo
        {
            get { return _titulo; }
            set { SetValue(ref _titulo, value); }
        }
        public string Nota
        {
            get { return _nota; }
            set { SetValue(ref _nota, value); }
        }
        public ModelNotas NotaElegida 
        {
            get { return _notaElegida; }
            set { SetValue(ref _notaElegida, value); }
        }
        #endregion
        #region PROCESOS
        public async Task CambiarNota()
        {
            var funcion = new DatosNotas();
            NotaElegida.TituloNota = Titulo;
            NotaElegida.Nota = Nota;
            await funcion.ModificarNota(NotaElegida);
            await VolverAlMenuPrincipal();
        }
        public async Task EliminarNota()
        {
            var funcion = new DatosNotas();
            await funcion.EliminarNota(NotaElegida.IdNota);
            await DisplayAlert("Listo!", "Su Nota a sido eliminada exitosamente", "continuar");
            await VolverAlMenuPrincipal();
        }
        public async Task VolverAlMenuPrincipal()
        {
            await Navigation.PopAsync();
        }
        #endregion
        #region COMANDOS
        public ICommand VolverAlMenuCommand => new Command(async () => await VolverAlMenuPrincipal());
        public ICommand EliminarCommnad => new Command(async () => await EliminarNota());
        public ICommand CambiarCommnad => new Command(async () => await CambiarNota());
        #endregion
    }
}
