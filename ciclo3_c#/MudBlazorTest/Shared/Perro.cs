using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MudBlazorTest.Shared
{
    /// <summary>Class <c>Perro</c>
    /// Modela un Perro en el sistema
    /// </summary>
    public class Perro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PerroId { get; set; }
        public bool Afiliacion { get; set; }
        [Required(ErrorMessage = "El nombre es requerido!")]
        public string Nombre { get; set; } = String.Empty;
        [Required(ErrorMessage = "El color es requerido!")]
        public string Color { get; set; } = String.Empty;
        [Required(ErrorMessage = "La Raza del perro es requerida!")]
        public string Raza { get; set; } = String.Empty;
        [Required(ErrorMessage = "El Sexo es requerido!")]
        public string Sexo { get; set; } = String.Empty;
        public Propietario? Propietario { get; set; }
        public int PropietarioId { get; set; }

    }
}


