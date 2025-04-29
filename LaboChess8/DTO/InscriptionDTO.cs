using System.ComponentModel.DataAnnotations;

namespace LaboChess8.DTO
{
    public class InscriptionDTO
    {
        [Required]
        public int TournamentId { get; set; }

        [Required]
        public int PlayerId { get; set; }
    }
}
