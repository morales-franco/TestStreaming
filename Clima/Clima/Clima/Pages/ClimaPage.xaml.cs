using Clima.Model;
using Clima.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Clima.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClimaPage : ContentPage
    {
        public ClimaPage()
        {
            InitializeComponent();
        }

        public async void btnBuscar_Clicked()
        {
            if (!string.IsNullOrEmpty(this.txtCiudad.Text))
            {
                ClimaModel model = await ClimaService.ConsultarClima(this.txtCiudad.Text);

                if(model != null)
                {
                    this.BindingContext = model;
                    btnBuscar.Text = "Buscar de Nuevo";
                }

            }
        }

    }
}