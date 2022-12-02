using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MudBlazorTest.Shared
{
    public class Historia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HistoriaId { get; set; }
        public virtual ICollection<Visita>? Visitas { get; set; }

        public DateTime fechaApertura { get; set; }
    }
}
