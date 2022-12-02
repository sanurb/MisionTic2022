using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MudBlazorTest.Shared
{
    /// <summary>Class <c>Persona</c>
    /// Modela una Persona en general en el sistema
    /// </summary>
    public class Persona
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonaId { get; set; }
        [Required(ErrorMessage = "El nombre es requerido!")]
        public string Nombres { get; set; } = string.Empty;
        [Required(ErrorMessage = "El apellido es requerido!")]
        public string Apellidos { get; set; } = string.Empty;
        [Required(ErrorMessage = "El telefono es requerido!")]
        public string Telefono { get; set; } = string.Empty;

    }
}
