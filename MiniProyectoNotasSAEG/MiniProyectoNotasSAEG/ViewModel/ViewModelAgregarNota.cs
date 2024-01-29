using MiniProyectoNotasSAEG.Datos;
using MiniProyectoNotasSAEG.Model;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MiniProyectoNotasSAEG.ViewModel
{
    public class ViewModelAgregarNota : BaseViewModel
    {
        #region VARIABLES
        private string _titulo;
        private string _nota;
        #endregion

        #region COSNTRUCTOR
        public ViewModelAgregarNota(INavigation navigation)
        {
            Navigation = navigation;
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
        #endregion
        #region PROCESOS
        public async Task AgregarNota()
        {
            var funcion = new DatosNotas();
            ModelNotas nota = new ModelNotas()
            {
                TituloNota = _titulo,
                Nota = _nota
            };
            await funcion.AgregarNota(nota);
            await VolverAlMenu();
        }
        public async Task VolverAlMenu()
        {
            await Navigation.PopAsync();
        }
        #endregion
        #region COMANDOS
        public ICommand AgregarNotaCommand => new Command(async () => await AgregarNota());
        public ICommand AlMenuCommnad => new Command(async  () => await VolverAlMenu());
        #endregion
    }
}
