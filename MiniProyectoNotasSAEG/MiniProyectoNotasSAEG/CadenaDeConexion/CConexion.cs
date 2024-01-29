using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniProyectoNotasSAEG.CadenaDeConexion
{
    public class CConexion
    {
        public static FirebaseClient firebase = new FirebaseClient("https://miniproyectonotas-default-rtdb.firebaseio.com/");
    }
}