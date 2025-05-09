using Directorio.UI.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Configuration;

namespace Directorio.UI.Services
{
    public class PersonaService
    {
        private readonly HttpClient _client;

        public PersonaService()
        {
            _client = new HttpClient();
            string baseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"];
            _client.BaseAddress = new Uri(baseUrl);
        }

        public async Task<bool> RegistrarPersona(Persona persona)
        {
            var response = await _client.PostAsJsonAsync("personas", persona);
            return response.IsSuccessStatusCode;
        }

        public async Task<List<Persona>> ObtenerPersonas()
        {
            var response = await _client.GetAsync("personas");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<Persona>>();
            }

            return new List<Persona>();
        }

        public async Task<bool> EliminarPersona(int id)
        {
            var response = await _client.DeleteAsync($"personas/{id}"); 
            return response.IsSuccessStatusCode;
        }
    }
}
