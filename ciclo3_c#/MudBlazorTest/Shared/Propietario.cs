using System.ComponentModel.DataAnnotations;

namespace MudBlazorTest.Shared
{
    public class Propietario : Persona
    {
        [Required(ErrorMessage = "La Direccion es requerida!")]
        public string Direccion { get; set; } = string.Empty;

    }
}
