// Krav 2 - Oppretter klasse RollePerson:
using System.ComponentModel.DataAnnotations;

namespace Gruppe20App.Models
{
    public class RollePerson
    {
        // Implementerer domener:
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Navn { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Rolle { get; set; } = string.Empty;

        public int OrganisasjonId { get; set; }

        public Organisasjon? Organisasjon { get; set; }
    }
}
