using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZadanieApp.Api.Models
{
    [Table("zadania")]
    public class Zadanie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Tytul { get; set; } = string.Empty;

        [MaxLength(2000)]
        public string? Opis { get; set; }

        public DateTime? Deadline { get; set; }

        // priorytet: 1..5
        [Range(1, 5)]
        public int Priorytet { get; set; } = 3;

        [Required]
        [MaxLength(50)]
        public string Status { get; set; } = "todo";

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}