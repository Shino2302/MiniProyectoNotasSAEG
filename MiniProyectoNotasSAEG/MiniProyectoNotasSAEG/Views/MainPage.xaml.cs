using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MiniProyectoNotasSAEG.ViewModel;

namespace MiniProyectoNotasSAEG
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new ViewModelMainPage(Navigation);
        }
    }
}
