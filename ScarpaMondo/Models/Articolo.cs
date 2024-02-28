using System.ComponentModel.DataAnnotations;

namespace ScarpaMondo.Models
{
    public class Articolo
    {
        [Key]
        public int ArticoloId { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public decimal Prezzo { get; set; }

        [Required]
        public string Descrizione { get; set; }

        [Required]
        public string ImmagineCopertinaUrl { get; set; }

        public string ImmagineAggiuntiva1Url { get; set; }

        public string ImmagineAggiuntiva2Url { get; set; }

        [Required]
        public bool InVetrina { get; set; }
        public bool IsDeleted { get; set; }
    }
}