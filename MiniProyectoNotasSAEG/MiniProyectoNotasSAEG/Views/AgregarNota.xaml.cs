﻿using MiniProyectoNotasSAEG.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MiniProyectoNotasSAEG.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgregarNota : ContentPage
    {
        public AgregarNota()
        {
            InitializeComponent();
            BindingContext = new ViewModelAgregarNota(Navigation);
        }
    }
}