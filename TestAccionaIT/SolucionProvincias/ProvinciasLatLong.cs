using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace TestAccionaIT
{
    public class Provincias
    {

        private const string URL = "https://apis.datos.gob.ar/georef/api/provincias";


        //El metodo GetProvincias es el encargado de realizar la call a la api para obtener toda la informacion
        public string GetProvincias()
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(URL);

                request.Method = "GET";

                var content = string.Empty;


                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    using (var stream = response.GetResponseStream())
                    {
                        using (var sr = new StreamReader(stream))
                        {
                            content = sr.ReadToEnd();
                        }
                    }
                }

                return content;
            }
            catch (Exception ex)
            {
                return "Error";
            }
        }

        public string GetLatLongProvincia(string provRequest)
        {

            var respuesta = "";
            var content = string.Empty;
            bool encontro = false;
            try
            {
                content = GetProvincias(); //content tendrá la información de la API
                if (content != "Error")
                {
                    var data = (JObject)JsonConvert.DeserializeObject(content);
                    var provincias = data["provincias"]; // Guardo solamente la parte de provincias

                    foreach (var item in provincias) // Loop en provincias para buscar la deseada, y luego obtener los datos solicitados
                    {

                        if (item["nombre"].ToString().ToUpper() == provRequest.ToUpper())
                        {
                            var nombre = item["nombre"].ToString();
                            var centroide = item["centroide"];
                            var lat = centroide["lat"].ToString();
                            var lon = centroide["lon"].ToString();
                            respuesta = "La provincia " + nombre + " tiene de lon: " + lon + " y tiene de lat: " + lat;
                            encontro = true;
                        }
                    }

                    if (!encontro)
                    {
                        respuesta = "No se encontró la provincia en cuestión, por favor verificar los datos buscados";
                    }

                }
                else
                {
                    respuesta = "No se pudo buscar las provincias, hubo un problema con la URL solicitada";
                }
                return respuesta;

            }
            catch (Exception ex)
            {
                return "Error en la peticion de las provincias";
            }
        }
    }
}
