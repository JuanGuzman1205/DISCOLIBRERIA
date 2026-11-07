using Newtonsoft.Json;
using Presentaciones_Discoteca.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentaciones_Discoteca.Implementaciones
{
    public class Comunicaciones : IComunicaciones
    {
        public async Task<T> Ejecutar<T>(string url, object entidad) 
        {
            url = "http://localhost:5247/" + url;
            var body = new StringContent(
                JsonConvert.SerializeObject(entidad),
                Encoding.UTF8, "application/json");

            using var cliente_http = new HttpClient
            {
                Timeout = new TimeSpan(0, 4, 0)
            };

            using var message = await cliente_http.PostAsync(url, body);
            var respuesta = await message.Content.ReadAsStringAsync();

            if (!message.IsSuccessStatusCode)
                throw new Exception(
                    $"Error HTTP {(int)message.StatusCode}: {respuesta}");

            return JsonConvert.DeserializeObject<T>(respuesta)
                ?? throw new JsonSerializationException(
                    "La API devolvió una respuesta vacía.");
        }
    }
}
