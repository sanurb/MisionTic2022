namespace MudBlazorTest.Client.Services.PerroService
{
    public interface IPerroService
    {
        List<Perro> Perros { get; set; }
        List<Propietario> Propietarios { get; set; }
        Task GetPropietarios();
        Task GetPerros();
        Task<Perro> GetSinglePerro(int id);
        Task CreatePerro(Perro perro);
        Task UpdatePerro(Perro perro);
        Task DeletePerro(int id);

    }
}
