using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MiniProyectoNotasSAEG.Triggers
{
    public class TriggerDeEventos : TriggerAction<Frame>
    {
        public bool activacion { get; set; }
        protected override async void Invoke(Frame frame)
        {
            if (activacion)
            {
                frame.BackgroundColor = Color.Red;
                await frame.RelScaleTo(40,250,Easing.BounceOut);
            }
            else
            {
                frame.BackgroundColor = new Frame().BackgroundColor;
                frame.Scale = new Frame().Scale;
            }
        }
    }
}
