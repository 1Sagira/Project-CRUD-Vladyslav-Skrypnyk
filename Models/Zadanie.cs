using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZadanieApp.Api.Models
{
    public class Zadanie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        // Rule: required, length 3-50
        [Required(ErrorMessage = "Tytuł jest wymagany.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Tytuł musi mieć od 3 do 50 znaków.")]
        public string Tytul { get; set; } = null!;

        // Rule: Opis length 4-2000
        [StringLength(2000, MinimumLength = 4, ErrorMessage = "Opis musi mieć od 4 до 2000 znaków.")]
        public string Opis { get; set; } = null!;

        // Rule: required, length 50 max (Status)
        [Required(ErrorMessage = "Status jest wymagany.")]
        [StringLength(50, ErrorMessage = "Status może mieć maksymalnie 50 znaków.")]
        public string Status { get; set; } = null!;

        // Rule: Priorytet must be between 1 and 5.
        [Range(1, 5, ErrorMessage = "Priorytet musi być w zakresie od 1 do 5.")]
        public int Priorytet { get; set; }

        public string? Wykonawca { get; set; }

        public int SzacowanyCzas { get; set; } 

        public DateTime? Deadline { get; set; }
        
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}