// Krav 2 - Oppretter klasse Organisasjon:
using System.ComponentModel.DataAnnotations;

namespace Gruppe20App.Models
{
    public class Organisasjon
    {
        // Implementerer domener:
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Navn { get; set; } = string.Empty;

        [Required]
        [StringLength(9)]
        public string Organisasjonsnummer { get; set; } = string.Empty;

        [StringLength(50)]
        public string? Organisasjonsform {  get; set; }

        public ICollection<RollePerson> RollePersoner { get; set; } = new List<RollePerson>();
        
    }
}
