using System.ComponentModel.DataAnnotations;

namespace MudBlazorTest.Shared
{
    /// <summary>Class <c>Veterinario</c>
    /// Modela un Veterinario en el sistema
    /// </summary>
    public class Veterinario : Persona
    {
        [Required(ErrorMessage = "La Tarjeta Profesional es requerida!")]
        public string TarjetaProfesional { get; set; } = String.Empty;
    }
}