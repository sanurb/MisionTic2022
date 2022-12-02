using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace MudBlazorTest.Client.Services.PerroService
{
    public class PerroService : IPerroService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public PerroService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;

        }
        public List<Perro> Perros { get; set; } = new List<Perro>();
        public List<Propietario> Propietarios { get; set; } = new List<Propietario>();

        public async Task GetPerros()
        {
            var result = await _http.GetFromJsonAsync<List<Perro>>("api/perro");
            if (result != null)
                Perros = result;
        }
        public async Task<Perro> GetSinglePerro(int id)
        {
            var result = await _http.GetFromJsonAsync<Perro>($"api/perro/{id}");
            if (result != null)
                return result;
            throw new Exception("Perro no encontrado");
        }
        public async Task GetPropietarios()
        {
            var result = await _http.GetFromJsonAsync<List<Propietario>>($"api/perro/propietarios");
            if (result != null)
                Propietarios = result;
        }

        public async Task CreatePerro(Perro perro)
        {
            var result = await _http.PostAsJsonAsync("api/perro", perro);
            await SetPerros(result);
        }
        private async Task SetPerros(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Perro>>();
            Perros = response;
            _navigationManager.NavigateTo("gestionar-mascotas");
        }

        public async Task UpdatePerro(Perro perro)
        {
            var result = await _http.PutAsJsonAsync($"api/perro/{perro.PerroId}", perro);
            await SetPerros(result);
        }

        public async Task DeletePerro(int id)
        {
            var result = await _http.DeleteAsync($"api/perro/{id}");
            await SetPerros(result);
        }
    }
}
