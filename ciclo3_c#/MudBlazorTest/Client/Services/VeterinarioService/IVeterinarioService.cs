namespace MudBlazorTest.Client.Services.VeterinarioService
{
    public interface IVeterinarioService
    {
        List<Veterinario> Veterinarios { get; set; }
        Task GetVeterinarios();
        Task<Veterinario> GetSingleVeterinario(int id);
        Task CreateVeterinario(Veterinario veterinario);
        Task UpdateVeterinario(Veterinario veterinario);
        Task DeleteVeterinario(int id);
    }
}
