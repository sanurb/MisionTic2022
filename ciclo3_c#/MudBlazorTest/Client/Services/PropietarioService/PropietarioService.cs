using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace MudBlazorTest.Client.Services.PropietarioService
{
    public class PropietarioService : IPropietarioService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public PropietarioService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }

        public List<Propietario> Propietarios { get; set; } = new List<Propietario>();
        public async Task GetPropietarios()
        {
            var result = await _http.GetFromJsonAsync<List<Propietario>>("api/propietario");
            if (result != null)
                Propietarios = result;
        }
        public async Task<Propietario> GetSinglePropietario(int id)
        {
            var result = await _http.GetFromJsonAsync<Propietario>($"api/propietario/{id}");
            if (result != null)
                return result;
            throw new Exception("propietario no encontrado");
        }
        public async Task CreatePropietario(Propietario propietario)
        {
            var result = await _http.PostAsJsonAsync("api/propietario", propietario);
            await SetPropietarios(result);
        }

        private async Task SetPropietarios(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Propietario>>();
            Propietarios = response;
            _navigationManager.NavigateTo("gestionar-propietarios");
        }

        public async Task DeletePropietario(int id)
        {
            var result = await _http.DeleteAsync($"api/propietario/{id}");
            await SetPropietarios(result);
        }



        public async Task UpdatePropietario(Propietario propietario)
        {
            var result = await _http.PutAsJsonAsync($"api/propietario/{propietario.PersonaId}", propietario);
            await SetPropietarios(result);

        }
    }
}
