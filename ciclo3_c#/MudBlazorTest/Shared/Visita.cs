using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MudBlazorTest.Shared
{
    public class Visita
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VisitaId { get; set; }
        public string Temperatura { get; set; } = String.Empty;
        public double Peso { get; set; }
        public string FrecuenciaRespiratoria { get; set; } = String.Empty;
        public string FrecuenciaCardiaca { get; set; } = String.Empty;
        public string Estado { get; set; } = String.Empty;
        public DateTime FechaDeVisita { get; set; } = DateTime.Now;
        public int VeterinarioId { get; set; }
        public Veterinario? Veterinario { get; set; }
        public string Recomendaciones { get; set; } = String.Empty;
        public int HistoriaId { get; set; }
        [ForeignKey("HistoriaID")]
        public virtual Historia? Historia { get; set; }
    }
}
