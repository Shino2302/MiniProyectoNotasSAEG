using Firebase.Database;
using Firebase.Database.Query;
using MiniProyectoNotasSAEG.CadenaDeConexion;
using MiniProyectoNotasSAEG.Model;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProyectoNotasSAEG.Datos
{
    public class DatosNotas
    {
        public async Task AgregarNota(ModelNotas notaAgregada)
        {
            await CConexion.firebase.Child("Notas")
                  .PostAsync(new ModelNotas()
                  {
                      IdNota = Guid.NewGuid(),
                      TituloNota = notaAgregada.TituloNota,
                      Nota = notaAgregada.Nota
                  });
        }
        public async Task ModificarNota(ModelNotas notaActualizada)
        {
            var actualizar = (await CConexion
                .firebase.Child("Notas")
                .OnceAsync<ModelNotas>())
                .Where(a => a.Object.IdNota == notaActualizada.IdNota)
                .FirstOrDefault();

            await CConexion.firebase
                  .Child("Notas")
                  .Child(actualizar.Key)
                  .PutAsync(new ModelNotas()
                  {
                      IdNota = notaActualizada.IdNota,
                      TituloNota = notaActualizada.TituloNota,
                      Nota = notaActualizada.Nota
                  });
        }
        public async Task EliminarNota(Guid idNota)
        {
            var notaAEliminar = (await CConexion.firebase
                .Child("Notas")
                .OnceAsync<ModelNotas>())
                .Where(a => a.Object.IdNota == idNota).FirstOrDefault();
            await CConexion.firebase.Child("Notas").Child(notaAEliminar.Key).DeleteAsync();
        }
        public async Task<ObservableCollection<ModelNotas>> ListarNotas()
        {
            var data = await Task.Run(() => CConexion.firebase
            .Child("Notas")
            .AsObservable<ModelNotas>()
            .AsObservableCollection());
            return data;
        }
    }
}
