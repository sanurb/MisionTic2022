using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace MudBlazorTest.Client.Services.VeterinarioService
{
    public class VeterinarioService : IVeterinarioService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;
        public VeterinarioService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public List<Veterinario> Veterinarios { get; set; } = new List<Veterinario>();

        public async Task GetVeterinarios()
        {
            var result = await _http.GetFromJsonAsync<List<Veterinario>>("api/veterinario");
            if (result != null)
                Veterinarios = result;
        }

        public async Task<Veterinario> GetSingleVeterinario(int id)
        {
            var result = await _http.GetFromJsonAsync<Veterinario>($"api/veterinario/{id}");
            if (result != null)
                return result;
            throw new Exception("veterinario no encontrado");
        }

        public async Task CreateVeterinario(Veterinario veterinario)
        {
            var result = await _http.PostAsJsonAsync("api/veterinario", veterinario);
            await SetVeterinarios(result);
        }
        private async Task SetVeterinarios(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Veterinario>>();
            Veterinarios = response;
            _navigationManager.NavigateTo("gestionar-veterinarios");
        }

        public async Task DeleteVeterinario(int id)
        {
            var result = await _http.DeleteAsync($"api/veterinario/{id}");
            await SetVeterinarios(result);
        }

        public async Task UpdateVeterinario(Veterinario veterinario)
        {
            var result = await _http.PutAsJsonAsync($"api/veterinario/{veterinario.PersonaId}", veterinario);
            await SetVeterinarios(result);
        }
    }
}
