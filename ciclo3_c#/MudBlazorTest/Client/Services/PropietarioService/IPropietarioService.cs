namespace MudBlazorTest.Client.Services.PropietarioService
{
    public interface IPropietarioService
    {
        List<Propietario> Propietarios { get; set; }
        Task GetPropietarios();
        Task<Propietario> GetSinglePropietario(int id);
        Task CreatePropietario(Propietario propietario);
        Task UpdatePropietario(Propietario propietario);
        Task DeletePropietario(int id);
    }
}
