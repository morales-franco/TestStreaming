using Clima.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Clima.Services
{
    public static class ClimaService
    {
        private static string _key = "2aa1e40c04564c2bf967069f127bf0a8";

        public static async Task<ClimaModel> ConsultarClima(string ciudad)
        {
            var connection = $"http://api.openweathermap.org/data/2.5/weather?q={ciudad}&appid={_key}";

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(connection);

                if(response != null)
                {
                    var json = response.Content.ReadAsStringAsync().Result; 
                    //Equivalente: var json = await response.Content.ReadAsStringAsync();

                    var data = (JContainer)JsonConvert.DeserializeObject(json);

                    if (data["weather"] != null)
                    {
                        ClimaModel clima = new ClimaModel();
                        clima.Titulo = (string)data["name"];
                        clima.Temperatura = ((float)data["main"]["temp"] - 273.15).ToString("N2") + " °C";
                        clima.Viento = (string)data["wind"]["speed"] + " mph";
                        clima.Humedad = (string)data["main"]["humidity"] + " %";
                        clima.Visibilidad = (string)data["weather"][0]["main"];
                        var fechaBase = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                        var amanecer = fechaBase.AddSeconds((double)data["sys"]["sunrise"]);
                        var ocaso = fechaBase.AddSeconds((double)data["sys"]["sunset"]);
                        clima.Amanecer = amanecer.ToString() + " UTC";
                        clima.Ocaso = ocaso.ToString() + " UTC";
                        return clima;
                    }
                }
                return default(ClimaModel);
            }

        }

    }
}
